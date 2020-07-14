public class Ledger {
    private string _accountNumber;
    private decimal _amount;
    private string _description;

    public Ledger(string accountNumber, decimal amount, string description ){
        this._accountNumber= accountNumber;
        this._amount = amount;
        this._description = description;

    }
    public void Save(){

    }
}