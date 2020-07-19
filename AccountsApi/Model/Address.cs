using System;
namespace AccountsApi.Model
{
    public class Address
    {
        public Address()
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
