using System;
using System.Diagnostics;
using System.Drawing;

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
                    AddWatermark(message[0], message[1]);
                }

                Storage.Queue.DeleteMessage(queueMessage);
                queueMessage = Storage.Queue.GetNextMessage();
            }
        }

        private static void AddWatermark(string blobUri, string fileName)
        {
            try
            {
                var stream = Storage.Blob.GetBlob(blobUri);

                if (blobUri.EndsWith(".jpg"))
                {
                    var image = Image.FromStream(stream);
                    var graphics = Graphics.FromImage(image);
                    var font = new Font("Arial", 24);
                    var brush = new SolidBrush(Color.Red);
                    graphics.DrawString("WATERMARK", font, brush, new PointF(100, 100));

                    Storage.Blob.PutBlob(stream, fileName);
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