using System.Linq;
using JunkTrunk.Storage.DataTransferObjects;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public class MetaDataContext : TableServiceContext
    {
        public MetaDataContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
            IgnoreResourceNotFoundException = true;
        }

        public IQueryable<MetaData> Data
        {
            get { return CreateQuery<MetaData>(StorageBase.TableName); }
        }

        public void Add(MetaData data)
        {
            data.RowKey = data.RowKey.Replace("/", "_");

            MetaData original = (from e in Data
                                 where e.RowKey == data.RowKey
                                       && e.PartitionKey == Table.PartitionKey
                                 select e).FirstOrDefault();

            if (original != null)
            {
                Update(original, data);
            }
            else
            {
                AddObject(StorageBase.TableName, data);
            }

            SaveChanges();
        }

        public void Update(MetaData original, MetaData data)
        {
            original.Date = data.Date;
            original.ResourceUri = data.ResourceUri;
            UpdateObject(original);

            SaveChanges();
        }

        public void DeleteMetaData(MetaData metaData )
        {
            DeleteObject(metaData);
            SaveChanges();
        }
    }
}