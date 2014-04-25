using System.Collections.Generic;
using Hcs.Data.Entities;
using Hcs.Data.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using System.Web.Http.Controllers;


namespace Website.Hubs
{
    

    public abstract class DataHubBase<T> : Hub where T: IEntity
    {
        private readonly IRepository<T> _repo;

        protected DataHubBase(IRepository<T> repo)
        {
            _repo = repo;
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.Get(x => true);
        }
    }
}