using System;

namespace ClimaTempo.Data.Core.Interfaces
{
    public interface IDataProvider : IDisposable
    {
        IDataSet<TEntity> GetDataSet<TEntity>() where TEntity : class, IEntity;
    }
}
