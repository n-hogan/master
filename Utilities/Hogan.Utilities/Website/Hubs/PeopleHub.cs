using System.Collections.Generic;
using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace Website.Hubs
{
    public class PeopleHub : Hub
    {
        private readonly IRepository<Person> _repo;

        
        public PeopleHub(IRepository<Person> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Person> GetAll()
        {
            return _repo.Get(x => true);
        }

        public IEnumerable<Person> FindPerson(string name)
        {
            return _repo.Get(x => x.Name == name);
        }

        public string Activate()
        {
            return "Monitor Activated";
        }

        public void PushMessage()
        {
            IConnectionManager connections =
                GlobalHost.DependencyResolver.GetService(typeof (IConnectionManager)) as IConnectionManager;
            connections.GetHubContext<PeopleHub>().Clients.All.Activate();
        }


    }
}

    
 
