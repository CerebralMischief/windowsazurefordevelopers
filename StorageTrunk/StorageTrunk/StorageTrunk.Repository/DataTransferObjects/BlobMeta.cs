using System;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageTrunk.Repository.DataTransferObjects
{
public class BlobMeta : TableServiceEntity
{
    public BlobMeta()
    {
        PartitionKey = Table.PartitionKey;
    }

    public DateTime Date { get; set; }
    public string ResourceUri { get; set; }
}
}
