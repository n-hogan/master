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
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Hcs.Data.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Person>("People");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
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

            Hub.Clients.All.addPersonToPage(7, "Ahmed");

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

            // return Ok<Person>(person);
            return StatusCode(HttpStatusCode.NotImplemented);
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

            // TODO: Add replace logic here.

            // return Updated(person);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/People
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(person);
            return StatusCode(HttpStatusCode.NotImplemented);
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

            // delta.Patch(person);

            // TODO: Save the patched entity.

            // return Updated(person);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
