using System.Collections.Generic;

public class MockBookRepository{
    public  IList<LedgerEntity> FetchLeadgers(){
        return new List<LedgerEntity>();
    }

    public IList<TransactionEntity> FetchTransactions(){
        return new List<TransactionEntity>();
    }

    public IList<JournalEntryEntity> FetchJournal(){
        return new List<JournalEntryEntity>();
    }


}