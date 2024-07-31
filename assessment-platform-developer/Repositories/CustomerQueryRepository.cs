using assessment_platform_developer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerQueryRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
    }

    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly LocalDb localDb;

        public CustomerQueryRepository(LocalDb localDb)
        {
            this.localDb = localDb;
        }
        public IEnumerable<Customer> GetAll()
        {
            return localDb.GetCustomerCollection("Customers").AsQueryable().ToList();
        }

        public Customer Get(int id)
        {
            //return customers.FirstOrDefault(c => c.ID == id);
            return localDb.GetCustomerCollection("Customers").AsQueryable().First(x => x.ID == id);
        }
    }
}