using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Net.Sockets;
using System.IO;

namespace EchoWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly AutoResetEvent _connectionWaitHandle = new AutoResetEvent(false); 

        public override void Run()
        {
            Trace.WriteLine("Starting echo server...", "Information");

            TcpListener listener = null;
            try
            { 
                listener = new TcpListener(
                    RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["EchoEndpoint"].IPEndpoint);
                listener.ExclusiveAddressUse = false;
                listener.Start();

                Trace.WriteLine("Started echo server.", "Information");
            }
            catch (SocketException se)
            {
                Trace.Write("Echo server could not start.", "Error");
                return;
            }

            while (true)
            {
                IAsyncResult result =  listener.BeginAcceptTcpClient(HandleAsyncConnection, listener); 
                _connectionWaitHandle.WaitOne();
            }
        }

        private void HandleAsyncConnection(IAsyncResult result)
        {
            // Accept connection
            TcpListener listener = (TcpListener)result.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(result);
            _connectionWaitHandle.Set(); 

            // Accepted connection
            Guid clientId = Guid.NewGuid();
            Trace.WriteLine("Accepted connection with ID " + clientId.ToString(), "Information");

            // Setup reader/writer
            NetworkStream netStream = client.GetStream();
            StreamReader reader = new StreamReader(netStream);
            StreamWriter writer = new StreamWriter(netStream);
            writer.AutoFlush = true;

            // Show application
            string input = string.Empty;
            while (input != "9")
            {
                // Show menu
                writer.WriteLine("Menu:");
                writer.WriteLine("-----");
                writer.WriteLine("  1) Display date");
                writer.WriteLine("  2) Display time");
                writer.WriteLine("  3) Role ID");
                writer.WriteLine("  4) Connection ID");
                writer.WriteLine("  8) Recycle");
                writer.WriteLine("  9) Quit");
                writer.WriteLine();
                writer.Write("Your choice: ");

                input = reader.ReadLine();
                writer.WriteLine();

                // Do something
                if (input == "1")
                {
                    writer.WriteLine("Current date: " + DateTime.Now.ToShortDateString());
                }
                else if (input == "2")
                {
                    writer.WriteLine("Current time: " + DateTime.Now.ToShortTimeString());
                }
                else if (input == "3")
                {
                    writer.WriteLine("Role ID: " + RoleEnvironment.CurrentRoleInstance.Id);
                }
                else if (input == "4")
                {
                    writer.WriteLine("Connection ID: " + clientId.ToString());
                }
                else if (input == "8")
                {
                    RoleEnvironment.RequestRecycle();
                }

                writer.WriteLine();
            }

            // Done!
            client.Close();
        } 


        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            DiagnosticMonitor.Start("DiagnosticsConnectionString");

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            RoleEnvironment.Changing += RoleEnvironmentChanging;

            return base.OnStart();
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            // If a configuration setting is changing
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
            {
                // Set e.Cancel to true to restart this role instance
                e.Cancel = true;
            }
        }
    }
}
