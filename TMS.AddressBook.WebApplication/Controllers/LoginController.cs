using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TMS.AddressBook.BusinessLayer;

namespace TMS.AddressBook.WebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        IBusinessLayer _bal;
        public LoginController(IBusinessLayer bal)
        {
            _bal = bal;
        }
        public bool Post([FromBody] Object obj)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(obj.ToString());
            var username = dict["username"];
            var password = dict["password"];
           // _bal.Login(username, password);
            return true;
        }
    }
}
