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

        public void Lock(Person person)
        {
            Clients.Others.lockForEdit(person);
        }

        public void Unlock(Person person)
        {
            Clients.All.unlock(person);
        }

        public void Push()
        {
            Clients.All.addPersonToPage(4, "Alex");
        }




    }
}

    
 
