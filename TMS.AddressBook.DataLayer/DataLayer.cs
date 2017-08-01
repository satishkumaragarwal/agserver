using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.AddressBook.DataLayer
{
    class DataLayer : IDataLayer
    {
        public DataSet GetAllContacts()
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("EmailAddress");
            dt.Columns.Add("StreetAddress");
            dt.Columns.Add("City");
            dt.Columns.Add("State");
            dt.Columns.Add("Country");
            dt.Columns.Add("Zipcode");
            dt.Columns.Add("Notes");

            dt.Rows.Add(new object[] { "James", "Bond", "123 3428749020", "james.bond@gmail.com", "Garrison Neely", "London", "London",
            "UK", "PC-BDG", "first contact"});

            ds.Tables.Add(dt);

            return ds;
        }
    }
}
