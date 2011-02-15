using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace StorageTrunk.Worker
{
    public class PhotoProcessing
    {
        public static bool ThumbnailCallback()
        {
            return false;
        }

        private static void AddThumbnail(string blobUri, string fileName)
        {
            try
            {
                var stream = Repository.Blob.GetBlob(blobUri);

                if (blobUri.EndsWith(".jpg"))
                {
                    var image = Image.FromStream(stream);
                    var myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    var thumbnailImage = image.GetThumbnailImage(42, 32, myCallback, IntPtr.Zero);
                    thumbnailImage.Save(stream, ImageFormat.Jpeg);
                    Repository.Blob.PutBlob(stream, "thumbnail-" + fileName);
                }
                else
                {
                    Repository.Blob.PutBlob(stream, fileName);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error", ex.ToString());
            }
        }

        public static void Run()
        {
            var queueMessage = Repository.Queue.GetNextMessage();

            while (queueMessage != null)
            {
                var message = queueMessage.AsString.Split('$');
                if (message.Length == 2)
                {
                    AddThumbnail(message[0], message[1]);
                }

                Repository.Queue.DeleteMessage(queueMessage);
                queueMessage = Repository.Queue.GetNextMessage();
            }
        }
    }
}
