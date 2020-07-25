using System;
using AccountsApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AccountsApi.Services.contract;

namespace AccountsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {

        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet()]
        public IActionResult FetchCustomers()
        {

            var customers = _customerService.FetchCustomers();
            //var customer = new CustomerModel
            //{
            //    FirstName = "Rajesh",
            //    LastName = "Govindan",
            //    DateOfBirth = new DateTime(2000, 04, 25),
            //    Address = new Address()
            //    {
            //        DoorNo = "D1",
            //        Street = "Jaswanth Nagar",
            //        Area = "Mogappair",
            //        City = "Chennai"
            //    },
            //    BankAccounts = new List<AccountModel>()
                
            //};

            //customer.BankAccounts.Add(new AccountModel()
            //{
            //    Description = "Saving Account"
            //});

            return Ok(customers);
        }

        [HttpGet]
        [Route("{customerId}",Name ="GetCustomer")]
        public IActionResult GetCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        [HttpPost()]
        public IActionResult CreateCustomer(CustomerModel customerModel)
        {
            if(null == customerModel)
            {
                return BadRequest("Invalid argument");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newCustomer = this._customerService.CreateCustomer(customerModel);
            newCustomer.CustomerCode = "C001";


            return CreatedAtRoute("GetCustomer", new { customerId = customerModel.CustomerCode }, newCustomer);
        }

        [HttpGet]
        [Route("/{customerId}/ledger/transactions")]
        public IActionResult GetLedgerTransactions(string customerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/{customerId}/accounts/balance")]
        public IActionResult GetAccountBalance(string customerId)
        {
            throw new NotImplementedException();
        }

    }


}
