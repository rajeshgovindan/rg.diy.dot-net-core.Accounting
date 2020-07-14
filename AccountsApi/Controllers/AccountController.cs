using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

 [ApiController]
 [Route("[controller]")]
public class AccountController :ControllerBase{

    private IAccountService _accountService;

    public  AccountController(IAccountService accountService){
        this._accountService = accountService;
    }

    [HttpGet]
    public IList<AccountModel> GetAccounts(){
        return this._accountService.FetchAccounts();

    } 

    [HttpGet("balance")]
    public decimal GetBalance(string accountNumber){
        var account = this._accountService.GetAccount(accountNumber);
        if(account == null ){
            return 0M;
        }

        return account.BalanceAmount;
    }

    [HttpPost()]
    public void Create(AccountModel account){
        this._accountService.AddAccount(account);       

    }
}