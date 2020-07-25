using System.Collections.Generic;

public interface IAccountRepository
{
    public IList<AccountEntity> FetchAccounts();
    public AccountEntity GetAccount(string accountNumber);
    public void AddAccount(AccountEntity accountEntity);
    public AccountEntity AddAccount(string customerCode, AccountEntity accountEntity);

    public void UpdateAccount(AccountEntity accountEntity);

    public void RemoveAccount(string accountNumber);
}