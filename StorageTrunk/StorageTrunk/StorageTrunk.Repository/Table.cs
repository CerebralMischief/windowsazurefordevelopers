using System;
using System.Collections.Generic;
using System.Linq;
using StorageTrunk.Repository.DataTransferObjects;

namespace StorageTrunk.Repository
{
public class Table : RepositoryBase
{
    public const string PartitionKey = "BlobMeta";

    public static void Add(BlobMeta data)
    {
        Context.Add(data);
    }

    public static BlobMeta GetMetaData(Guid key)
    {
        return (from e in Context.Data
                where e.RowKey == key.ToString() &&
                e.PartitionKey == PartitionKey
                select e).SingleOrDefault();
    }

    public static void DeleteMetaDataAndBlob(Guid key)
    {
        var ctxt = new BlobMetaContext(
            Account.TableEndpoint.AbsoluteUri,
            Account.Credentials);
        var entity = (from e in ctxt.Data
                        where e.RowKey == key.ToString() &&
                        e.PartitionKey == PartitionKey
                        select e).SingleOrDefault();
        ctxt.DeleteObject(entity);
        Repository.Blob.DeleteBlob(entity.ResourceUri);
        ctxt.SaveChanges();
    }

    public static List<BlobMeta> GetAll()
    {
        return (from e in Context.Data
                select e).ToList();
    }

    public static BlobMetaContext Context
    {
        get
        {
            return new BlobMetaContext(
                Account.TableEndpoint.AbsoluteUri,
                Account.Credentials);
        }
    }
}
}
