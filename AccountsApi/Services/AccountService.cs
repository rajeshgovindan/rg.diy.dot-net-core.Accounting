using System.Collections.Generic;
using System.Linq;
using AccountsApi.Repository;
using AutoMapper;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;
    private ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public AccountService(IAccountRepository accountRepository,
        ICustomerRepository customerRepository,
        IMapper mapper ){
        this._accountRepository = accountRepository;
        this._customerRepository = customerRepository;
        this._mapper = mapper;

    }

    public AccountModel AddAccount(string customerCode,AccountModel account)
    {
        var customerEntity = _customerRepository.GetCustomer(customerCode);
        //if(null == customerEntity)
        //{
        //    throw new System.Exception("Customer not found");
        //}
        AccountEntity entity = _mapper.Map<AccountEntity>(account);

        var savedAccount = _accountRepository.AddAccount(customerCode, entity);

        if(savedAccount == null)
        {
            throw new System.Exception("Account is not added, please try after sometime");
        }

        return _mapper.Map<AccountModel>(savedAccount);




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
