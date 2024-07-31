using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using assessment_platform_developer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace assessment_platform_developer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        string testFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\unitTestData.json";
        [TestMethod]
        public void ServiceAssignsUniqueId()
        {
            try
            {
                var localdb = new LocalDb(testFilePath);
                ICustomerQueryRepository customerQueryRepository = new CustomerQueryRepository(localdb);
                ICustomerCommandRepository customerCommandRepository = new CustomerCommandRepository(localdb);
                var customerService = new CustomerService(customerCommandRepository, customerQueryRepository);

                var customer = new Customer()
                {
                    Name = "John Doe",
                    City = "Paris",
                    Address = "123 Main st",
                    Email = "abc@xyz.com",
                    Phone = "+1 2345678901"
                };
                var id = customer.ID;

                var savedCustomer = customerService.AddCustomer(customer);

                Assert.AreEqual(id, 0);
                Assert.AreNotEqual(savedCustomer.ID, customer.ID);
            }
            finally
            {
                File.Delete(testFilePath);
            }
            //cleanup
        }

        [TestMethod]
        public void ServicesReturnCorrectData()
        {
            try
            {
                var localdb = new LocalDb(testFilePath);
                ICustomerQueryRepository customerQueryRepository = new CustomerQueryRepository(localdb);
                ICustomerCommandRepository customerCommandRepository = new CustomerCommandRepository(localdb);
                var customerService = new CustomerService(customerCommandRepository, customerQueryRepository);

                var customer = new Customer()
                {
                    Name = "John Doe",
                    City = "Paris",
                    Address = "123 Main st",
                    Email = "abc@xyz.com",
                    Phone = "+1 2345678901"
                };

                var savedCustomer = customerService.AddCustomer(customer);

                var retrievedCustomer = customerService.GetCustomer(savedCustomer.ID);

                Assert.AreEqual(savedCustomer.Name, customer.Name);
            }
            finally
            {
                File.Delete(testFilePath);
            }
            //cleanup
        }
    }
}
