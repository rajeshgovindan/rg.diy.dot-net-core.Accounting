using System.Collections.Generic;
using System.Linq;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository ){
        this._accountRepository = accountRepository;

    }

    public AccountModel AddAccount(AccountModel account)
    {
        AccountEntity entity = new AccountEntity();
        entity.AccountNumber= account.AccountNumber;
        entity.BalanceAmount = account.BalanceAmount;
        this._accountRepository.AddAccount(entity);
        return account;

    }

    public IList<AccountModel> FetchAccounts()
    {
        var accountEntities = this._accountRepository.FetchAccounts();
        IList<AccountModel> accounts = new List<AccountModel>();
        ///TODO: need to replace the below loop to Automapper
        foreach(var accountEntity in accountEntities){
            var account = new AccountModel();
            account.AccountNumber = accountEntity.AccountNumber;
            account.BalanceAmount = accountEntity.BalanceAmount;
            accounts.Add(account);
        }

        return accounts;
        
    }

    public AccountModel GetAccount(string accountNumber)
    {
        throw new System.NotImplementedException();
    }

    public AccountModel UpdateAccount(AccountModel account)
    {
        throw new System.NotImplementedException();
    }
}
