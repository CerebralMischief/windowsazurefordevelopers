using System.Drawing;

namespace JunkTrunk.Worker
{
    public class PhotoProcessing
    {
        public static void Run()
        {
            var msg = Storage.Queue.GetNextMessage();

            while (msg != null)
            {
                string[] message = msg.AsString.Split('$');
                if (message.Length == 2)
                {
                    AddWatermark(message[0], message[1]);
                }

                Storage.Queue.DeleteMessage(msg);

                msg = Storage.Queue.GetNextMessage();
            }
        }

        private static void AddWatermark(string blobUri, string fileName)
        {
            var stream = Storage.Blob.GetBlob(blobUri);
            var img = Image.FromStream(stream);

            var g = Graphics.FromImage(img);

            var font = new Font("Arial", 24);
            var brush = new SolidBrush(Color.Red);

            g.DrawString("WATERMARK", font, brush, new PointF(100, 100));

            Storage.Blob.PutBlob(stream, fileName);
        }
    }
}
