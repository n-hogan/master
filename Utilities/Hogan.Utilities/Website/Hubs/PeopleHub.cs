using System.Security.Cryptography.X509Certificates;
using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;

namespace Website.Hubs
{
    public class PeopleHub : DataHubBase<Person>
    {
        

        public PeopleHub(IRepository<Person> repo) : base(repo)
        {
            
        }

        public void Push()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<PeopleHub>();
            context.Clients.All.addPersonToPage(4, "Alex");
        }




    }
}

    
 
