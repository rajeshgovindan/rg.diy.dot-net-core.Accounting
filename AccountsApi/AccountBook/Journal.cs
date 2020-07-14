using System.Collections.Generic;

public class Journal{

    public  string Description {get; private set;}
    
    public  IList<Entry> DebitEntries {get; private set;}
    public  IList<Entry> CreditEntries {get; private set;}

    public Journal(string description, IList<Entry> debitEntries, IList<Entry> creditEntries){

        this.Description = description;
        this.DebitEntries = debitEntries;
        this.CreditEntries = creditEntries;


    }
    
    
    


    public void AddEntry(){
        ///Validate Journal Entries

        /// Call Leader to create transactions

        

    }

    public class Entry{
        public string AccountNumber {get; set;}

        public decimal Amount {get; set;}
    }
}