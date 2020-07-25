using System;
using System.Collections.Generic;
using AccountsApi.Config.properties;
using MongoDB.Driver;

namespace AccountsApi.Repository
{
    public class CustomerMongoDbRepository : ICustomerRepository
    {
        private readonly IMongoCollection<CustomerEntity> _customers;
        public CustomerMongoDbRepository(IAccountDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _customers = database.GetCollection<CustomerEntity>(dbSettings.CustomerCollectionName);
        }

        public IList<CustomerEntity> FetchCustomers()
        {
            return _customers.Find<CustomerEntity>(CustomerEntity => true).ToList<CustomerEntity>();
        }

        public CustomerEntity GetCustomer(string customerCode)
        {
            var customers =  _customers.Find<CustomerEntity>(customer =>
            customer.CustomerCode == customerCode).ToList<CustomerEntity>();

            if(null != customers &&  customers.Count > 0)
            {
                return customers[0];
            }
            return null;
        }

        public CustomerEntity SaveCustomer(CustomerEntity customer)
        {
            if(null == customer)
            {
                throw new ArgumentNullException("Customer entity is null");
            }

            _customers.InsertOne(customer);

            return customer;
        }


    }
}
