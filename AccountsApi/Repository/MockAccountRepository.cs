using System.Collections.Generic;
using System.Linq;

public class MockAccountRepository : IAccountRepository
{
    private IDictionary<string,AccountEntity> _accountsDict;
    public MockAccountRepository(){
        this._accountsDict = new Dictionary<string,AccountEntity>();
        this._accountsDict.Add("10001",new AccountEntity(){
             Id = 1,
             AccountNumber = "10001",
             BalanceAmount = 100
             
        });

    }
    public IList<AccountEntity> FetchAccounts()
    {
        return this._accountsDict.Values.ToList();
        
    }

    public void AddAccount(AccountEntity accountEntity){
        if(this._accountsDict.ContainsKey(accountEntity.AccountNumber)){
            throw new System.Exception("Account already exists");
        }
        this._accountsDict.Add(accountEntity.AccountNumber,accountEntity);
    }

    public void UpdateAccount(AccountEntity accountEntity){
        if(!this._accountsDict.ContainsKey(accountEntity.AccountNumber)){
            throw new System.Exception("Account doesn't exists");
        }
        this._accountsDict[accountEntity.AccountNumber]=accountEntity;
    }
}