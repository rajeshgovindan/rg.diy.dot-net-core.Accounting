using System;
using System.Collections.Generic;
using AccountsApi.Model;
using AccountsApi.Repository;
using AccountsApi.Services.contract;
using AutoMapper;

namespace AccountsApi.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,  IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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

            CustomerEntity entity = _mapper.Map<CustomerEntity>(newCustomer);
            _customerRepository.SaveCustomer(entity);

            //newCustomer.CustomerCode = "C001";
            //newCustomer.BankAccount.AccountNumber = "A001";
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
