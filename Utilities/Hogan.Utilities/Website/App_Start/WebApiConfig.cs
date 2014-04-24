using System.Web.Http;
using System.Web.Http.OData.Builder;
    using Hcs.Data.Entities;
    

namespace Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("People");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}