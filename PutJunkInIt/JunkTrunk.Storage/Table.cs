﻿using System;
using System.Collections.Generic;
using System.Linq;
using JunkTrunk.Storage.DataTransferObjects;

namespace JunkTrunk.Storage
{
    public class Table : StorageBase
    {
        public const string PartitionKey = "MetaData";

        public static void Add(MetaData data)
        {
            Context.Add(data);
        }

        public static MetaData GetMetaData(Guid key)
        {
            return (from e in Context.Data
                    where e.RowKey == key.ToString() && e.PartitionKey == PartitionKey
                    select e).SingleOrDefault();
        }

        public static void DeleteMetaDataAndBlob(Guid key)
        {
            var ctxt = new MetaDataContext(Account.TableEndpoint.AbsoluteUri, Account.Credentials);
            var entity = (from e in ctxt.Data
                          where e.RowKey == key.ToString() && e.PartitionKey == PartitionKey
                          select e).SingleOrDefault();
            ctxt.DeleteObject(entity);
            Storage.Blob.DeleteBlob(entity.ResourceUri);
            ctxt.SaveChanges();
        }

        public static List<MetaData> GetAll()
        {
            return (from e in Context.Data
                    select e).ToList();
        }

        public static MetaDataContext Context
        {
            get { return new MetaDataContext(Account.TableEndpoint.AbsoluteUri, Account.Credentials); }
        }
    }
}