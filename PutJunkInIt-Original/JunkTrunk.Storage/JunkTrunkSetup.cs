namespace JunkTrunk.Storage
{
public class JunkTrunkSetup : JunkTrunkBase
{
    public static void CreateContainersQueuesTables()
    {
        Blob.CreateIfNotExist();
        Queue.CreateIfNotExist();
        Table.CreateTableIfNotExist(TableName);
    }
}
}