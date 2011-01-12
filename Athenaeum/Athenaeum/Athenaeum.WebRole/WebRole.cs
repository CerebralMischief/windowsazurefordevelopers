using System.Net;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace Athenaeum.WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            try
            {
                EnsureContainerExists();
            }
            catch (WebException we)
            {
                if (we.Status == WebExceptionStatus.ConnectFailure)
                {
                    // TODO: Add diag/logging here.
                }
            }
            catch (StorageException se)
            {
                // TODO: Add diag/logging here.
            }

            return base.OnStart();
        }

        private static void EnsureContainerExists()
        {
            CloudBlobContainer container = GetContainer();
            container.CreateIfNotExist();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }

        private static CloudBlobContainer GetContainer()
        {
CloudStorageAccount.SetConfigurationSettingPublisher(
    (configName, configSetter) => configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)));
CloudStorageAccount account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            CloudBlobClient client = account.CreateCloudBlobClient();

            return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName"));
        }
    }
}