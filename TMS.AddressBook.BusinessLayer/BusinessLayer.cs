using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.AddressBook.CommonLayer;
using TMS.AddressBook.DataLayer;

namespace TMS.AddressBook.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        
        static Dictionary<string, string> _dictUsers = new Dictionary<string, string>();
        static Dictionary<string, List<Contact>> _dictContacts = new Dictionary<string, List<Contact>>();

        static BusinessLayer()
        {
            _dictUsers.Add("test@test.com", "test");
            _dictContacts["test@test.com"] = new List<Contact>();
        }

        public static bool Login(string username, string password)
        {
            if (_dictUsers.ContainsKey(username) && _dictUsers[username] == password)
                return true;
            return false;
        }

        IDataLayer _dal;
        
        public BusinessLayer(IDataLayer dal)
        {
            _dal = dal;
        }        

        public bool AddContact(Contact contact, string username)
        {
            _dictContacts[username].Add(contact);
            return true;
        }

        public List<Contact> GetAllContacts(string username)
        {
            return _dictContacts[username];
            DataSet ds = _dal.GetAllContacts();
            DataTable dt = ds.Tables[0];

            List<Contact> result = new List<Contact>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Contact
                {
                    FirstName = row[0].ToString(),
                    LastName = row[1].ToString(),
                    PhoneNumber = row[2].ToString(),
                    EmailAddress = row[3].ToString(),
                    StreetAddress = row[4].ToString(),
                    City = row[5].ToString(),
                    State = row[6].ToString(),
                    Country = row[7].ToString(),
                    Zipcode = row[8].ToString(),
                    Notes = row[9].ToString(),
                });
            }
            return result;
        }

        public Contact GetContact(int id, string user)
        {
            return _dictContacts[user].Find(x => x.ID == id);
        }

        public bool DeleteContact(int id, string user)
        {
            return _dictContacts[user].Remove(_dictContacts[user].Find(x => x.ID == id));
        }
    }
}
