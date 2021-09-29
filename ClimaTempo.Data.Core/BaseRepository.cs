using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Core
{
    public class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class, IEntity
    {
        protected readonly IDataSet<TEntity> _dataset = null;

        public BaseRepository(IDataProvider provider)
        {
            this._dataset = provider.GetDataSet<TEntity>();
        }

        public IQueryable<TEntity> GetData<TKey>(Expression<Func<TEntity, bool>> predicate, OrderField<TEntity, TKey> orderField, int top)
        {
            var result = this._dataset.GetEntities(predicate, orderField, top);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool v)
        {
            this._dataset.Dispose();
        }
    }
}
