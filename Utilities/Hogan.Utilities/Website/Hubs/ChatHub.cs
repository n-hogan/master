using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private IRepository<Person> _repo; 

        public ChatHub(IRepository<Person> repo)
        {
             _repo = repo;
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}