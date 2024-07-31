using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using JsonFlatFileDataStore;

namespace assessment_platform_developer.Models
{
    //This is a substitute to connecting to an external database to make it portable and still persistent
    public class LocalDb
    {
        JsonFlatFileDataStore.DataStore store;
        public LocalDb(string path) {
            store = new DataStore(path);
        }

        public IDocumentCollection<Customer> GetCustomerCollection(string name)
        {
            return store.GetCollection<Customer>(name);
        }
    }
}