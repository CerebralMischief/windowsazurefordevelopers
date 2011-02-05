using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageTrunk.Repository
{
    //public class Queue : RepositoryBase
    //{
    //    public static void Add(CloudQueueMessage msg)
    //    {
    //        Queue.AddMessage(msg);
    //    }

    //    public static CloudQueueMessage GetNextMessage()
    //    {
    //        return Queue.PeekMessage() != null ? Queue.GetMessage() : null;
    //    }

    //    public static List<CloudQueueMessage> GetAllMessages()
    //    {
    //        int count = Queue.RetrieveApproximateMessageCount();
    //        return Queue.GetMessages(count).ToList();
    //    }

    //    public static void DeleteMessage(CloudQueueMessage msg)
    //    {
    //        Queue.DeleteMessage(msg);
    //    }
    //}
}
