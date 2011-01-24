using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;
using Storage;

namespace Athenaeum.WebRole.Models
{
    public class FileBlobRepository
    {
        public void PutFile(BlobFileModel blobFileModel)
        {
            string blobFileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyy/MM/dd"), blobFileModel.FileName);

            // Upload the blob
            string blobUri = Blob.PutBlob(blobFileModel.BlobFile, blobFileName);

            // Add entry to table
            Table.Add(
                new MetaData
                    {
                        Description = blobFileModel.Description,
                        Date = DateTime.Now,
                        ImageURL = blobUri,
                        RowKey = blobFileName
                    });

            // Add message to queue
            Queue.Add(new CloudQueueMessage(blobUri + "$" + blobFileName));
        }

        public Stream GetFile(string blobFileAddress)
        {
            return Blob.GetBlob(blobFileAddress);
        }

        public List<BlobFileModel> GetBlobFileList()
        {
            return new List<BlobFileModel>();
        }
    }
}