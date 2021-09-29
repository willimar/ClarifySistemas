using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Provider
{
    public class DataProvider : IDataProvider
    {
        private DataContext _dbContext;

        public DataProvider(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Dispose()
        {
            this._dbContext?.Dispose();
            this._dbContext = null;
        }

        public IDataSet<TEntity> GetDataSet<TEntity>() where TEntity : class, IEntity
        {
            return new DataSet<TEntity>(this._dbContext);
        }
    }
}
