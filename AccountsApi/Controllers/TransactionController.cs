using Microsoft.AspNetCore.Mvc;

public class TransactionController : ControllerBase{

    public decimal GetCurrentBalance(string accountNumber){
        return 1000.00M;
    }

    public void DebitTransaction(string accountNumber,decimal amount){

    }
}