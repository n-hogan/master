using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hcs.Data.Entities;
using Hcs.Data.Repository;

namespace WebApiNinjectTest.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IRepository<Person> _repository; 

        public PeopleController(IRepository<Person> repository)
        {
            _repository = repository;
        }

        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return new List<Person>();
        }

        // GET: api/People/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
