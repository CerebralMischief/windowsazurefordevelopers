using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace JunkTrunk.WorkerRole
{
    public class PhotoProcessing
    {
        public static void Run()
        {
            var queueMessage = Storage.Queue.GetNextMessage();

            while (queueMessage != null)
            {
                var message = queueMessage.AsString.Split('$');
                if (message.Length == 2)
                {
                    AddThumbnail(message[0], message[1]);
                }

                Storage.Queue.DeleteMessage(queueMessage);
                queueMessage = Storage.Queue.GetNextMessage();
            }
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }

        private static void AddThumbnail(string blobUri, string fileName)
        {
            try
            {
                var stream = Storage.Blob.GetBlob(blobUri);

                if (blobUri.EndsWith(".jpg"))
                {
                    var image = Image.FromStream(stream);
                    var myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    var thumbnailImage = image.GetThumbnailImage(42, 32, myCallback, IntPtr.Zero);
                    thumbnailImage.Save(stream, ImageFormat.Jpeg);
                    Storage.Blob.PutBlob(stream, "thumbnail-" + fileName);
                }
                else
                {
                    Storage.Blob.PutBlob(stream, fileName);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error", ex.ToString());
            }
        }
    }
}