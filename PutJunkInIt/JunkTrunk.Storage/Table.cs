using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace JunkTrunk.Storage
{
    public class Table : StorageBase
    {
        public const string PartitionKey = "MetaData";

        /// <summary>
        /// Add object to table
        /// </summary>
        /// <param name="data">MetaData object to add</param>
        public static void Add(MetaData data)
        {
            Context.Add(data);
        }

        /// <summary>
        /// Get MetaData object matching key
        /// </summary>
        /// <param name="key">Key of object to retrieve</param>
        /// <returns>MetaData if found</returns>
        public static MetaData GetMetaData(string key)
        {
            return (from e in Context.Data
                    where e.RowKey == key && e.PartitionKey == PartitionKey
                    select e).SingleOrDefault();
        }

        /// <summary>
        /// Get all MetaData object in storage
        /// </summary>
        /// <returns></returns>
        public static List<MetaData> GetAll()
        {
            return (from e in Context.Data
                    select e).ToList();
        }

        static MetaDataContext Context
        {
            get { return new MetaDataContext(Account.TableEndpoint.AbsoluteUri, Account.Credentials); }
        }
    }

    public class MetaData : TableServiceEntity
    {
        public MetaData()
        {
            PartitionKey = Table.PartitionKey;
            RowKey = "Not Set";
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImageURL { get; set; }
    }

    public class MetaDataContext : TableServiceContext
    {
        public MetaDataContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
            IgnoreResourceNotFoundException = true;
        }

        public IQueryable<MetaData> Data
        {
            get { return CreateQuery<MetaData>(StorageBase.TableName); }
        }

        /// <summary>
        /// Add object to table
        /// </summary>
        /// <param name="data">MetaData object to add</param>
        public void Add(MetaData data)
        {
            data.RowKey = data.RowKey.Replace("/", "_");

            MetaData original = (from e in Data
                                 where e.RowKey == data.RowKey
                                       && e.PartitionKey == Table.PartitionKey
                                 select e).FirstOrDefault();

            if (original != null)
            {
                Update(original, data);
            }
            else
            {
                AddObject(StorageBase.TableName, data);
            }

            SaveChanges();
        }

        /// <summary>
        /// Update object
        /// </summary>
        /// <param name="original">Original MetaData object</param>
        /// <param name="data">Updated object</param>
        public void Update(MetaData original, MetaData data)
        {
            original.Description = data.Description;
            original.Date = data.Date;
            original.ImageURL = data.ImageURL;
            UpdateObject(original);

            SaveChanges();
        }
    }
}