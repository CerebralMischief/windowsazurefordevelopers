﻿using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace JunkTrunk.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            Trace.WriteLine("Junk Trunk Worker entry point called", "Information");

            while (true)
            {
                PhotoProcessing.Run();

                Thread.Sleep(60000);
                Trace.WriteLine("Working", "Junk Trunk Worker Role is active and running.");
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");
            RoleEnvironment.Changing += RoleEnvironmentChanging;

            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
                RoleEnvironment.Changed += (sender, arg) =>
                {
                    if (arg.Changes.OfType<RoleEnvironmentConfigurationSettingChange>()
                        .Any((change) => (change.ConfigurationSettingName == configName)))
                    {
                        if (!configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))
                        {
                            RoleEnvironment.RequestRecycle();
                        }
                    }
                };
            });

            Storage.JunkTrunkSetup.CreateContainersQueuesTables();

            return base.OnStart();
        }

        private static void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (!e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange)) return;

            Trace.WriteLine("Working", "Environment Change: " + e.Changes.ToList());
            e.Cancel = true;
        }

    }
}