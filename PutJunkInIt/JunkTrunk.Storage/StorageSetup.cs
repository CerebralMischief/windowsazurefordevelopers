namespace JunkTrunk.Storage
{
    public class StorageSetup : StorageBase
    {
        /// <summary>
        /// Create the blob container, table and queue
        /// necessary for the application
        /// These should only be created once for the application
        /// so consolidate the creation here
        /// </summary>
        public static void CreateContainersQueuesTables()
        {
            Blob.CreateIfNotExist();
            Queue.CreateIfNotExist();
            Table.CreateTableIfNotExist(TableName);
        }
    }
}