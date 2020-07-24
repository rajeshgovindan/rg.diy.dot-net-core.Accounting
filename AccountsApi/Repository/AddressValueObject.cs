using System;
namespace AccountsApi.Repository
{
    public class AddressValueObject
    {
        public AddressValueObject()
        {
        }

        public string DoorNo { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
