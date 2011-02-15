using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.StorageClient;
using StorageTrunk.Repository;
using StorageTrunk.Repository.DataTransferObjects;

namespace StorageTrunk.Web.Models
{
    public class FileBlobManager
    {
        public void PutFile(BlobModel blobModel)
        {
            var blobFileName = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), blobModel.ResourceLocation);
            var blobUri = Blob.PutBlob(blobModel.BlobFile, blobFileName);

            Table.Add(
                new BlobMeta
                    {
                        Date = DateTime.Now,
                        ResourceUri = blobUri,
                        RowKey = Guid.NewGuid().ToString()
                    });

            Queue.Add(new CloudQueueMessage(blobUri + "$" + blobFileName));
        }

        public BlobModel GetFile(Guid key)
        {
            var blobMetaData = Table.GetMetaData(key);
            var blobFileModel =
                new BlobModel
                    {
                        UploadedOn = blobMetaData.Date,
                        BlobFile = Blob.GetBlob(blobMetaData.ResourceUri),
                        ResourceLocation = blobMetaData.ResourceUri
                    };
            return blobFileModel;
        }

        public List<FileItemModel> GetBlobFileList()
        {
            var blobList = Table.GetAll();

            return blobList.Select(
                metaData => new FileItemModel
                                {
                                    ResourceId = Guid.Parse(metaData.RowKey),
                                    ResourceLocation = metaData.ResourceUri,
                                    UploadedOn = metaData.Date
                                }).ToList();
        }

        public void Delete(string identifier)
        {
            Table.DeleteMetaDataAndBlob(Guid.Parse(identifier));
        }
    }
}