using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using SpazioServer.Models;

namespace SpazioServer.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            User  u = new User();
            return  u.getUsers();
        }

        // GET api/<controller>/5

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>



        public User Post([FromBody]User user)
        {

            user.insert();
            return user;

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}