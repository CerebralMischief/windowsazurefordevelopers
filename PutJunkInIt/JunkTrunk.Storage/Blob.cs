using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public class Blob : StorageBase
    {
        public static string PutBlob(Stream stream, string fileName)
        {
            var blobRef = Blob.GetBlobReference(fileName);
            blobRef.UploadFromStream(stream);
            return blobRef.Uri.ToString();
        }

        public static Stream GetBlob(string blobAddress)
        {
            var stream = new MemoryStream();
            Blob.GetBlobReference(blobAddress)
                .DownloadToStream(stream);
            return stream;
        }

        public static Dictionary<string, string> GetBlobList()
        {
            var blobs = Blob.ListBlobs();
            var blobDictionary = blobs.ToDictionary(listBlobItem => listBlobItem.Uri.ToString(), listBlobItem => listBlobItem.Uri.ToString());

            return blobDictionary;
        }
    }
}