using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Services
{
	public interface ICustomerService
	{
		IEnumerable<Customer> GetAllCustomers();
		Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
		void UpdateCustomer(Customer customer);
		void DeleteCustomer(int id);
	}

	public class CustomerService : ICustomerService
	{
		private readonly ICustomerCommandRepository customerRepository;
		private readonly ICustomerQueryRepository customerQueryRepository;

        public CustomerService(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository)
		{
			this.customerRepository = customerCommandRepository;
			this.customerQueryRepository = customerQueryRepository;
        }

		public IEnumerable<Customer> GetAllCustomers()
		{
			return customerQueryRepository.GetAll();
		}

		public Customer GetCustomer(int id)
		{
			return customerQueryRepository.Get(id);
		}

		public Customer AddCustomer(Customer customer)
		{
			return customerRepository.Add(customer);
		}

		public void UpdateCustomer(Customer customer)
		{
			customerRepository.Update(customer);
		}

		public void DeleteCustomer(int id)
		{
			customerRepository.Delete(id);
		}
	}

}