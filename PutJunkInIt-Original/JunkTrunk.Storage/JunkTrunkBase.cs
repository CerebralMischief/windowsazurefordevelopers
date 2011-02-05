using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public abstract class JunkTrunkBase
    {
        public const string QueueName = "metadataqueue";
        public const string BlobContainerName = "photos";
        public const string TableName = "BlobMeta";

        static JunkTrunkBase()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
                RoleEnvironment.Changed
                    += (sender, arg) =>
                            {
                                if (!arg.Changes.OfType<RoleEnvironmentConfigurationSettingChange>()
                                        .Any(change => (change.ConfigurationSettingName == configName)))
                                    return;
                                if (!configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))
                                {
                                    RoleEnvironment.RequestRecycle();
                                }
                            };
            });
        }

        protected static CloudBlobContainer Blob
        {
            get { return BlobClient.GetContainerReference(BlobContainerName); }
        }

        private static CloudBlobClient BlobClient
        {
            get
            {
                return Account.CreateCloudBlobClient();
            }
        }

        /// <summary>
        /// Start over method.
        /// </summary>
        public static void ClearAllData()
        {
            var container = JunkTrunkBase.BlobClient.ListContainers();

            foreach (var cloudBlobContainer in container)
            {
                cloudBlobContainer.Delete();
            }

            var table = JunkTrunkBase.Table.ListTables();

            foreach (var tableName in table)
            {
                Table.DeleteTable(tableName);
            }
        }

protected static CloudQueue Queue
{
    get { return QueueClient.GetQueueReference(QueueName); }
}

private static CloudQueueClient QueueClient
{
    get { return Account.CreateCloudQueueClient(); }
}

protected static CloudTableClient Table
{
    get { return Account.CreateCloudTableClient(); }
}

protected static CloudStorageAccount Account
{
    get
    {
        return
            CloudStorageAccount
            .FromConfigurationSetting("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");
    }
}
    }
}
