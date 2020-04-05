using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpazioServer.Models;

namespace SpazioServer.Controllers
{
    public class SpaceController : ApiController
    {
        // GET api/<controller>
        public List<Space> Get()
        {
            Space s = new Space();
            return s.getSpaces();
        }

        // GET api/<controller>/5

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>



        public Space Post([FromBody]Space space)
        {

            space.insert();
            return space;

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