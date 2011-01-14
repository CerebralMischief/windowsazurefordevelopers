using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace SampleWorkerRole
{

    public class WorkerRole : RoleEntryPoint
    {
        private readonly AutoResetEvent _connectionWait = new AutoResetEvent(false);

        public override void Run()
        {
            Trace.WriteLine("Starting Telnet Service...", "Information");

            TcpListener listener;
            try
            {
                listener = new TcpListener(
                    RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TelnetServiceEndpoint"].IPEndpoint)
                               {ExclusiveAddressUse = false};
                listener.Start();

                Trace.WriteLine("Started Telnet Service.", "Information");
            }
            catch (SocketException se)
            {
                Trace.Write("Telnet Service could not start.", "Error");
                return;
            }

            while (true)
            {
                listener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
                _connectionWait.WaitOne();
            }
        }

        private void HandleAsyncConnection(IAsyncResult result)
        {
            var listener = (TcpListener)result.AsyncState;
            var client = listener.EndAcceptTcpClient(result);
            _connectionWait.Set();

            var clientId = Guid.NewGuid();
            Trace.WriteLine("Connection ID: " + clientId, "Information");

            var netStream = client.GetStream();
            var reader = new StreamReader(netStream);
            var writer = new StreamWriter(netStream);
            writer.AutoFlush = true;

            var input = string.Empty;
            while (input != "3")
            {
                writer.WriteLine(" 1) Display Worker Role Information");
                writer.WriteLine(" 2) Recycle");
                writer.WriteLine(" 3) Quit");
                writer.Write("Enter your choice: ");

                input = reader.ReadLine();
                writer.WriteLine();

                switch (input)
                {
                    case "1":
                        writer.WriteLine("Current date: " + DateTime.Now.ToShortDateString());
                        writer.WriteLine("Current time: " + DateTime.Now.ToShortTimeString());
                        writer.WriteLine("Role ID: " + RoleEnvironment.CurrentRoleInstance.Id);
                        writer.WriteLine("Connection ID: " + clientId);
                        break;
                    case "2":
                        RoleEnvironment.RequestRecycle();
                        break;
                }

                writer.WriteLine();
            }

            client.Close();
        }


        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            DiagnosticMonitor.Start("DiagnosticsConnectionString");

            RoleEnvironment.Changing += RoleEnvironmentChanging;

            return base.OnStart();
        }

        private static void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
            {
                e.Cancel = true;
            }
        }
    }
}
