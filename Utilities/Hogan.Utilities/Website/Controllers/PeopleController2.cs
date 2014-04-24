using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website.Controllers
{
    public class PeopleController2 : ApiController
    {
        // GET: api/PeopleController2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PeopleController2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PeopleController2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PeopleController2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PeopleController2/5
        public void Delete(int id)
        {
        }
    }
}
