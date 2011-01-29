using System;
using System.Collections.Generic;
using System.IO;
using JunkTrunk.Storage;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Models
{
    public class FileBlobRepository
    {
        public void PutFile(BlobFileModel blobFileModel)
        {
            string blobFileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyy/MM/dd"), blobFileModel.FileName);
            string blobUri = Blob.PutBlob(blobFileModel.BlobFile, blobFileName);

            Table.Add(
                new MetaData
                    {
                        Description = blobFileModel.Description,
                        Date = DateTime.Now,
                        ImageURL = blobUri,
                        RowKey = blobFileName
                    });

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