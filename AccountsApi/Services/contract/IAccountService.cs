using System.Collections.Generic;

public interface IAccountService
{
    public IList<AccountModel> FetchAccounts();

    public AccountModel GetAccount(string accountNumber);

    public AccountModel AddAccount(string customerCode,AccountModel account);

    public AccountModel UpdateAccount(AccountModel account);
    
}