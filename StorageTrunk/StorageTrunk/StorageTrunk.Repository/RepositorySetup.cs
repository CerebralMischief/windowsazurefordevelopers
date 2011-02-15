namespace StorageTrunk.Repository
{
    public class RepositorySetup : RepositoryBase
    {
        public static void CreateContainersQueuesTables()
        {
            Blob.CreateIfNotExist();
            Queue.CreateIfNotExist();
            Table.CreateTableIfNotExist(TableName);
        }
    }
}
