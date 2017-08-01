using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS.AddressBook.BusinessLayer;
using TMS.AddressBook.CommonLayer;
using TMS.AddressBook.WebApplication.App_Start;
using System.Threading;
using System.Web.Http.Cors;

namespace TMS.AddressBook.WebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [BasicAuthentication]
    public class ContactsController : ApiController
    {
        IBusinessLayer _bal;
        public ContactsController(IBusinessLayer bl)
        {
            _bal = bl;
        }
        
        public List<Contact> Get()
        {
            return _bal.GetAllContacts(Thread.CurrentPrincipal.Identity.Name);
        }

        public Contact Get(int id)
        {
            return _bal.GetContact(id,Thread.CurrentPrincipal.Identity.Name);
        }

        public bool Post([FromBody] Contact contact)
        {
            return _bal.AddContact(contact, Thread.CurrentPrincipal.Identity.Name);
        }

        public bool Delete(int id)
        {
            return _bal.DeleteContact(id, Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
