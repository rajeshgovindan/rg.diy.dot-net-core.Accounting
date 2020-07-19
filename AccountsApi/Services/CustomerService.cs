using System;
using System.Collections.Generic;
using AccountsApi.Model;
using AccountsApi.Services.contract;

namespace AccountsApi.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {
        }

        public CustomerModel CreateCustomer(CustomerModel newCustomer)
        {
            if(null == newCustomer)
            {
                throw new ArgumentException("Invalid Customer data");
            }

            if(null == newCustomer.BankAccount)
            {
                throw new ArgumentException("Bank account not found");
            }

            if(null == newCustomer.BankAccount.Type || null == newCustomer.BankAccount.Description)
            {
                throw new ArgumentException("Invalid bank account data");
            }

            newCustomer.CustomerCode = "C001";
            newCustomer.BankAccount.AccountNumber = "A001";
            return newCustomer;
        }

        public IList<CustomerModel> FetchCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomer(string customerCode)
        {
            throw new NotImplementedException();
        }
    }
}
