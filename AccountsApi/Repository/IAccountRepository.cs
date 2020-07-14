using System.Collections.Generic;

public interface IAccountRepository
{
    public IList<AccountEntity> FetchAccounts();
    public void AddAccount(AccountEntity accountEntity);

    public void UpdateAccount(AccountEntity accountEntity);
}