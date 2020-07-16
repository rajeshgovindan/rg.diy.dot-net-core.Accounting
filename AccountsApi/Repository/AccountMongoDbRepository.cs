﻿using System;
using System.Collections.Generic;
using AccountsApi.Config.properties;
using MongoDB.Driver;

namespace AccountsApi.Repository
{
    public class AccountMongoDbRepository : IAccountRepository
    {
        private readonly IMongoCollection<AccountEntity> _ledgerAccounts ;

        public AccountMongoDbRepository(IAccountDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _ledgerAccounts = database.GetCollection<AccountEntity>(dbSettings.AccountCollectionName);
        }

        public void AddAccount(AccountEntity accountEntity)
        {
            _ledgerAccounts.InsertOne(accountEntity);
        }

        public IList<AccountEntity> FetchAccounts()
        {
           return  _ledgerAccounts.Find<AccountEntity>(account=>true).ToList<AccountEntity>();        }

        public AccountEntity GetAccount(string accountNumber)
        {
            var accounts =  _ledgerAccounts.Find<AccountEntity>(
                account => account.AccountNumber == accountNumber)
                .ToList<AccountEntity>();
            if(accounts != null || accounts.Count >0 ){
                return accounts[0];
            }

            return null;
        }

        public void RemoveAccount(String accountNumber)
        {
            _ledgerAccounts.DeleteOne(
                account => account.AccountNumber == accountNumber);
                
        }

        public void UpdateAccount(AccountEntity accountEntity)
        {
            _ledgerAccounts.ReplaceOne(
                account => account.AccountNumber == accountEntity.AccountNumber, accountEntity);
        }
    }
}
