using Hcs.Data.Entities;
using Hcs.Data.Repository;

namespace Website.Hubs
{
    public class PeopleHub : DataHubBase<Person>
    {
        public PeopleHub(IRepository<Person> repo) : base(repo)
        {
            
        }
    }
}

    
 
