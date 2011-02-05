using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageTrunk.Repository
{
    public abstract class StorageBase
    {
        public const string QueueName = "metadataqueue";
        public const string BlobContainerName = "photos";
        public const string TableName = "MetaData";

        static StorageBase()
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
                return CloudStorageAccount.FromConfigurationSetting("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");
            }
        }
    }
}
