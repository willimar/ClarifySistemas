using ClimaTempo.Data.Core;
using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Provider
{
    public class DataSet<TEntity> : IDataSet<TEntity> where TEntity : class, IEntity
    {
        private readonly DataContext _context;
        protected DbSet<TEntity> _dbSet;

        public DataSet(DataContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public void Dispose()
        {
            this._dbSet = null;
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetEntities<TKey>(Expression<Func<TEntity, bool>> predicate, OrderField<TEntity, TKey> orderField, int limit = 0)
        {
            var find = this._dbSet.Where(predicate);

            if (orderField.Order == Order.asc)
            {
                find = find.OrderBy(orderField.Field);
            }
            else
            {
                find = find.OrderByDescending(orderField.Field);
            }

            if (limit > 0)
            {
                find = find.Take(limit);
            }

            return find;
        }
    }
}
