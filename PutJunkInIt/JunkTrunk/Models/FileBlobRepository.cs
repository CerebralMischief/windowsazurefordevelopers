using System;
using System.Collections.Generic;
using JunkTrunk.Storage;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Models
{
    public class FileBlobRepository
    {
        public void PutFile(BlobModel blobModel)
        {
            string blobFileName = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), blobModel.FileName);
            string blobUri = Blob.PutBlob(blobModel.BlobFile, blobFileName);

            Table.Add(
                new MetaData
                    {
                        Description = blobModel.Description,
                        Date = DateTime.Now,
                        ImageURL = blobUri,
                        RowKey = blobFileName
                    });
            Queue.Add(new CloudQueueMessage(blobUri + "$" + blobFileName));
        }

        public BlobModel GetFile(string blobFileAddress)
        {
            var blobFileModel =
                new BlobModel
                    {
                        DownloadedOn = DateTime.Now,
                        BlobFile = Blob.GetBlob(blobFileAddress),
                        Description = "Will retrieve soon.",
                        FileName = "Parse file name here."
                    };
            return blobFileModel;
        }

        public List<FileItemModel> GetBlobFileList()
        {
            var fileItemModelList =
                new List<FileItemModel>
                    {
                        new FileItemModel
                            {
                                Description = "stuff",
                                DownloadedOn = DateTime.Now.AddDays(-2),
                                FileName = "1test.jpg"
                            },
                        new FileItemModel
                            {
                                Description = "stuff2",
                                DownloadedOn = DateTime.Now.AddDays(-2),
                                FileName = "2test.jpg"
                            },
                        new FileItemModel
                            {
                                Description = "stuff3",
                                DownloadedOn = DateTime.Now.AddDays(-2),
                                FileName = "3test.jpg"
                            }
                    };
            return new List<FileItemModel>();
        }
    }
}