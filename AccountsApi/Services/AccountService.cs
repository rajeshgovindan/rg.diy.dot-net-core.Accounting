using System.Collections.Generic;
using System.Linq;
using AutoMapper;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    public AccountService(IAccountRepository accountRepository, IMapper mapper ){
        this._accountRepository = accountRepository;
        this._mapper = mapper;

    }

    public AccountModel AddAccount(AccountModel account)
    {
        
        AccountEntity entity = _mapper.Map<AccountEntity>(account);
        this._accountRepository.AddAccount(entity);
        return account;

    }

    public IList<AccountModel> FetchAccounts()
    {
        var accountEntities = this._accountRepository.FetchAccounts();
        IList<AccountModel> accounts = new List<AccountModel>();
        ///TODO: need to replace the below loop to Automapper
        foreach(var accountEntity in accountEntities){
            
            AccountModel account= _mapper.Map<AccountModel>(accountEntity);
            accounts.Add(account);
        }

        return accounts;
        
    }

    public AccountModel GetAccount(string accountNumber)
    {
        var accountEntity= this._accountRepository.GetAccount(accountNumber);
        return this._mapper.Map<AccountModel>(accountEntity);
    }

    public AccountModel UpdateAccount(AccountModel account)
    {
        throw new System.NotImplementedException();
    }
}
