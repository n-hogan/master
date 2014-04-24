using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Data.OData;
using Website.Hubs;

namespace Website.Controllers
{
    
    public class PeopleController : ODataControllerWithHub<PeopleHub>
    {
        private static readonly ODataValidationSettings ValidationSettings = new ODataValidationSettings();

        private readonly IRepository<Person> _repo;
        

        public PeopleController(IRepository<Person> repo)
        {
            _repo = repo;

        }

        // GET: odata/People
        public IHttpActionResult GetPeople(ODataQueryOptions<Person> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(ValidationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            //Hub.Clients.All.addPersonToPage(7, "Ahmed");

            return Ok(_repo.Get(x=>true));
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/People(5)
        public IHttpActionResult GetPerson([FromODataUri] long key, ODataQueryOptions<Person> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(ValidationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_repo.Get(key));
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/People(5)
        public IHttpActionResult Put([FromODataUri] long key, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != person.Id)
            {
                return BadRequest();
            }

            _repo.CreateOrUpdate(person);
            return Updated(person);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/People
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.
            _repo.CreateOrUpdate(person);

            Hub.Clients.All.addPersonToPage(person.Id, person.Name);

            return Created(person);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/People(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<Person> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            var person =_repo.Get(key);

            delta.Patch(person);

            

            // TODO: Save the patched entity.

            _repo.CreateOrUpdate(person);

            return Updated(person);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.
            _repo.Delete(key);

            return StatusCode(HttpStatusCode.NoContent);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
