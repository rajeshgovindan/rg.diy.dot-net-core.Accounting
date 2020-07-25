using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccountsApi.Repository
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id;

        public string CustomerCode { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public AddressValueObject Address { get; set; }
        
        public IList<AccountEntity> BankAccounts { get; set; }

        public bool IsActive { get; set; }
    }
}
