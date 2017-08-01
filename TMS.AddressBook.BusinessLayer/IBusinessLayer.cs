using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.AddressBook.CommonLayer;

namespace TMS.AddressBook.BusinessLayer
{
    public interface IBusinessLayer
    {
        //bool Login(string username, string password);
        List<Contact> GetAllContacts(string username);
        bool AddContact(Contact contact, string username);
        Contact GetContact(int id, string user);
        bool DeleteContact(int id, string user);
    }
}
