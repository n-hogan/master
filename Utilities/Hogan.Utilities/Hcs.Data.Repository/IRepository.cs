using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Hcs.Data.Entities;

namespace Hcs.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Get(long id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> func);
        void Delete(long id);
        void CreateOrUpdate(TEntity tEntity);
        void Dispose();
    }
}