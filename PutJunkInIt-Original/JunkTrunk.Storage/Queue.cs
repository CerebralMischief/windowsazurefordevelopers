using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public class Queue : JunkTrunkBase
    {
        public static void Add(CloudQueueMessage msg)
        {
            Queue.AddMessage(msg);
        }

        public static CloudQueueMessage GetNextMessage()
        {
            return Queue.PeekMessage() != null ? Queue.GetMessage() : null;
        }

        public static List<CloudQueueMessage> GetAllMessages()
        {
            var count = Queue.RetrieveApproximateMessageCount();
            return Queue.GetMessages(count).ToList();
        }

        public static void DeleteMessage(CloudQueueMessage msg)
        {
            Queue.DeleteMessage(msg);
        }
    }
}