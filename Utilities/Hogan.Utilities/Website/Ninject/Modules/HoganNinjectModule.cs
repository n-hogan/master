using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using NHibernate;
using Ninject.Modules;
using Website.Controllers;
using Website.Hubs;

namespace Website.NinjectModules
{
    public class HoganNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Person>>().To<Repository<Person>>();

            Bind<ISession>().ToMethod(context => NHibernateSessionPerRequest.GetCurrentSession());
            
            
            Bind<IHub>().To<PeopleHub>().WhenInjectedInto<PeopleController>();


            Bind<IHubConnectionContext>().ToMethod(context =>
                GlobalHost.DependencyResolver.Resolve<IConnectionManager>().
                    GetHubContext<PeopleHub>().Clients
                ).WhenInjectedInto<PeopleHub>();

            
        }


    }
}