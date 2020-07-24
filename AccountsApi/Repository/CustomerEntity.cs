using System;
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
        
       // public AccountEntity BankAccount { get; set; }

        public bool IsActive { get; set; }
    }
}
