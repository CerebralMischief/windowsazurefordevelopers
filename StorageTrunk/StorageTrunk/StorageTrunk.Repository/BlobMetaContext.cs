using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using StorageTrunk.Repository.DataTransferObjects;

namespace StorageTrunk.Repository
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
        get { return CreateQuery<BlobMeta>(RepositoryBase.TableName); }
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
            AddObject(RepositoryBase.TableName, data);
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
