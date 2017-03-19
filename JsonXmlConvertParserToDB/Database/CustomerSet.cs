using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonXmlConvertParserToDB.Database
{

    public class CustomerSet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public virtual List<PhoneNumber> PhoneNumbers { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public CustomerSet()
        {
            this.PhoneNumbers = new List<PhoneNumber>();
            this.Addresses = new List<Address>();
        }

    }
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public virtual CustomerSet Customer { get; set; }

    }

    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public virtual CustomerSet Customer { get; set; }
    }
}
