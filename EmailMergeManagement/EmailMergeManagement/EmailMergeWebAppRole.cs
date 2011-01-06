using System;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace EmailMergeManagement
{
    public class EmailMergeManagementRole
    {
        public class WebRole : RoleEntryPoint
        {
            public override bool OnStart()
            {
                RoleEnvironment.Changing += RoleEnvironmentChanging;

                CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
               {
                   try
                   {
                       configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
                   }
                   catch
                   {
                   }

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
}