using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace EmailMergeManagement.Models
{
    public class EmailMergeDataServiceContext : TableServiceContext
    {
        public const string EmailMergeTableName = "EmailMergeTable";

        public EmailMergeDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<EmailMergeModel> EmailMergeTable
        {
            get { return CreateQuery<EmailMergeModel>(EmailMergeTableName); }
        }
    }
}