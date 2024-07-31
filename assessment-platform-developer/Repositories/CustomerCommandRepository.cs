using assessment_platform_developer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerCommandRepository
    {
        Customer Add(Customer customer);    //We are changing the method signature as the method mutates the object before persisting it
        void Update(Customer customer);
        void Delete(int id);
    }

    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly LocalDb localDb;

        public CustomerCommandRepository(LocalDb localDb)
        {
            this.localDb = localDb;
        }

        public Customer Add(Customer customer)
        {
            if (customer.ID == 0)
            {
                customer.ID = (localDb.GetCustomerCollection("Customers").Count > 0 ? localDb.GetCustomerCollection("Customers").AsQueryable().Max(x => x.ID) : 0) + 1;
            }
            localDb.GetCustomerCollection("Customers").InsertOne(customer);
            return customer;
        }

        public void Update(Customer customer)
        {
            localDb.GetCustomerCollection("Customers").UpdateOne(customer.ID, customer);
        }

        public void Delete(int id)
        {
            localDb.GetCustomerCollection("Customers").DeleteOne(x => x.ID == id);
        }
    }
}