using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Hcs.Data.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Hcs.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public TEntity Get(long id)
        {

            return _session.Get<TEntity>(id);

        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> func)
        {
            return _session.Query<TEntity>().Where(func);
        }

        public void Delete(long id)
        {

            var itemToDelete = _session.Get<TEntity>(id);
            _session.Delete(itemToDelete);

        }

        public void CreateOrUpdate(TEntity tEntity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(tEntity);
                transaction.Commit();
            }

        }

        public void Dispose()
        {
            _session.Close();
        }

    }
}
