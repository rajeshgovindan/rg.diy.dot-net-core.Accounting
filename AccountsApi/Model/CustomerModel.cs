using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountsApi.Model
{
    public class CustomerModel
    {
        public CustomerModel()
        {
        }


        public string CustomerCode { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public IList<AccountModel> BankAccounts{ get; set; }

        public bool IsActive { get; set; }
    }
}
