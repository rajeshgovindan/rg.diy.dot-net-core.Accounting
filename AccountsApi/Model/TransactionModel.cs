using System;

public class TransactionModel{

    public DateTime Date { get; set; } 
    public string Type { get; set; }
    public AccountModel BankAccount { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }



}