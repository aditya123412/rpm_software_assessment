using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using JsonFlatFileDataStore;

namespace assessment_platform_developer.Models
{
    public class LocalDb
    {
        JsonFlatFileDataStore.DataStore store;
        public LocalDb(string path) {
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}
            store = new DataStore(path);
        }

        public IDocumentCollection<Customer> GetCustomerCollection(string name)
        {
            return store.GetCollection<Customer>(name);
        }
    }
}