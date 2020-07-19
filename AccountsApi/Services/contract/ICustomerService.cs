using System;
using System.Collections.Generic;
using AccountsApi.Model;

namespace AccountsApi.Services.contract
{
    public interface ICustomerService
    {
        CustomerModel CreateCustomer(CustomerModel newCustomer);

        IList<CustomerModel> FetchCustomers();

        CustomerModel GetCustomer(string customerCode);
    }
}
