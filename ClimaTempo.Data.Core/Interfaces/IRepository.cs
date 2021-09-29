using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetData<TKey>(Expression<Func<TEntity, bool>> predicate, OrderField<TEntity, TKey> orderField, int top);
        void Dispose();
    }
}
