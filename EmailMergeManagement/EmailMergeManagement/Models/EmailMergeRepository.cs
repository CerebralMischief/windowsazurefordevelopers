using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace EmailMergeManagement.Models
{
    public class EmailMergeRepository
    {
        private readonly EmailMergeDataServiceContext _serviceContext;

        public EmailMergeRepository()
        {
            var storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("DiagnosticsConnectionString"));

            //var storageAccount = CloudStorageAccount.
            //    FromConfigurationSetting("DiagnosticsConnectionString");
            _serviceContext =
                new EmailMergeDataServiceContext(
                    storageAccount.TableEndpoint.ToString(),
                    storageAccount.Credentials);

            storageAccount.CreateCloudTableClient().
                CreateTableIfNotExist(
                    EmailMergeDataServiceContext.EmailMergeTableName);
        }

        public IEnumerable<EmailMergeModel> Select()
        {
            var results = from c in _serviceContext.EmailMergeTable
                          select c;

            var query = results.AsTableServiceQuery();
            var queryResults = query.Execute();

            return queryResults;
        }

        public EmailMergeModel GetEmailMergeModel(string rowKey)
        {
            var result = (from c in _serviceContext.EmailMergeTable
                          where c.RowKey == rowKey
                          select c).FirstOrDefault();
            return result;
        }

        public void Delete(EmailMergeModel emailMergeModelToDelete)
        {
            _serviceContext.Detach(emailMergeModelToDelete);
            _serviceContext.AttachTo(EmailMergeDataServiceContext.EmailMergeTableName,
                emailMergeModelToDelete, "*");
            _serviceContext.DeleteObject(emailMergeModelToDelete);
            _serviceContext.SaveChanges();
        }

        public void Insert(EmailMergeModel emailMergeModel)
        {
            _serviceContext.AddObject(EmailMergeDataServiceContext.EmailMergeTableName, StampIt(emailMergeModel));
            _serviceContext.SaveChanges();
        }

        public void Update(EmailMergeModel emailMergeModelUpdate)
        {
            var emailMergeModelOld = GetEmailMergeModel(emailMergeModelUpdate.RowKey);
            Delete(emailMergeModelOld);
            Insert(StampIt(emailMergeModelUpdate));
        }

        private static EmailMergeModel StampIt(EmailMergeModel emailMergeModel)
        {
            // This is a sample of adding a cross cutting concern or similar functionality.
            emailMergeModel.LastEditStamp = DateTime.Now;
            return emailMergeModel;
        }
    }
}