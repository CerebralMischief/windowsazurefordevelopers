using System.Linq;
using JunkTrunk.Storage.DataTransferObjects;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public class BlobMetaContext : TableServiceContext
    {
        public BlobMetaContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
            IgnoreResourceNotFoundException = true;
        }

        public IQueryable<BlobMeta> Data
        {
            get { return CreateQuery<BlobMeta>(JunkTrunkBase.TableName); }
        }

        public void Add(BlobMeta data)
        {
            data.RowKey = data.RowKey.Replace("/", "_");

            BlobMeta original = (from e in Data
                                 where e.RowKey == data.RowKey
                                       && e.PartitionKey == Table.PartitionKey
                                 select e).FirstOrDefault();

            if (original != null)
            {
                Update(original, data);
            }
            else
            {
                AddObject(JunkTrunkBase.TableName, data);
            }

            SaveChanges();
        }

        public void Update(BlobMeta original, BlobMeta data)
        {
            original.Date = data.Date;
            original.ResourceUri = data.ResourceUri;
            UpdateObject(original);

            SaveChanges();
        }
    }
}