using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
public class TransactionsController : ControllerBase{

    
    [HttpPost]
    
    public IActionResult Save(TransactionModel transaction)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult FetchTransactions()
    {
        throw new NotImplementedException();
    }

}