using System;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage.DataTransferObjects
{
    public class MetaData : TableServiceEntity
    {
        public MetaData()
        {
            PartitionKey = Table.PartitionKey;
        }

        public DateTime Date { get; set; }
        public string ResourceUri { get; set; }
    }
}