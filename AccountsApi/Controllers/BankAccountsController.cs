using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

 [ApiController]
 [Route("[controller]")]
public class BankAccountsController :ControllerBase{

    private IAccountService _accountService;
    private ILogger<BankAccountsController> logger;
    

    public  BankAccountsController(IAccountService accountService, ILogger<BankAccountsController> logger){
        this._accountService = accountService;
        this.logger = logger;
    }
    

    [HttpGet]
    public IList<AccountModel> GetAccounts(){
        this.logger.LogInformation("Get Accounts Called");
        return this._accountService.FetchAccounts();

    }

    [HttpGet]
    [Route("{accountNumber}",Name ="GetAccount")]
    public AccountModel GetAccount(string accountNumber)
    {
        if(accountNumber == null )
        {
            throw new ArgumentException("Invalid Account number");
        }
        this.logger.LogInformation("Get account details of account {0}",accountNumber);
        return this._accountService.GetAccount(accountNumber);

    }

    [HttpGet("balance/{accountNumber}")]
    public decimal GetBalance(string accountNumber){
        if (accountNumber == null|| accountNumber == "-")
        {
            throw new ArgumentException("Invalid Account number");
        }

        var account = this._accountService.GetAccount(accountNumber);
        if(account == null ){
            return 0M;
        }
        this.logger.LogInformation("Balance of account number {0} is {1}", accountNumber, account.BalanceAmount);
        
        return account.BalanceAmount;
    }

    [HttpPost()]
    public IActionResult OpenNewAccount(AccountModel account){

        this._accountService.AddAccount(account);
        this.logger.LogInformation("New Account created and account number {0}", account.AccountNumber);
        return CreatedAtRoute("GetAccount", new { accountNumber = account.AccountNumber }, account);

    }
}