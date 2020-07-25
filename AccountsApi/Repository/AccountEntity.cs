using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class AccountEntity{
    //[BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    //public string Id;
    public string AccountNumber {get; set;}
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal BalanceAmount {get; set;}

}