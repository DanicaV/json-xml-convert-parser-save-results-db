using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonXmlConvertParserToDB.Database
{
    public class CustomerDB : DbContext
    {
        public DbSet<CustomerSet> CustomerSet { get; set; }
        public DbSet<PhoneNumber> Phones { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
