using System;
using System.Collections.Generic;

namespace AccountsApi.Repository
{
    public interface ICustomerRepository
    {
        public IList<CustomerEntity> FetchCustomers();
        public CustomerEntity SaveCustomer(CustomerEntity customer);
        public CustomerEntity GetCustomer(string customerCode);
        
    }

    
}
