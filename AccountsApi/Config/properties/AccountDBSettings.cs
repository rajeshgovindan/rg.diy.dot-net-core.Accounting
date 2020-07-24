using System;
namespace AccountsApi.Config.properties
{

    public interface IAccountDatabaseSettings
    {
        public string AccountCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }



    public class AccountDatabaseSettings : IAccountDatabaseSettings
    {
        public string AccountCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
