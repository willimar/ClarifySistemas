using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Core.Interfaces
{
    public interface IDataSet<TEntity> : IDisposable where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetEntities<TKey>(Expression<Func<TEntity, bool>> predicate, OrderField<TEntity, TKey> orderField, int limit = 0);
    }
}
