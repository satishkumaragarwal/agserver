using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.AddressBook.CommonLayer
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Can be a list of phone numbers
        public string PhoneNumber { get; set; }

        //Can be a list of email addresses
        public string EmailAddress { get; set; }

        //Create a Address Object and use it here as a List<Address>
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        public string Notes { get; set; }
    }
}
