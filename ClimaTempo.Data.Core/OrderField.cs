using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Linq.Expressions;

namespace ClimaTempo.Data.Core
{
    public enum Order
    {
        asc,
        dsc
    }

    public class OrderField<TEntity, TKey> where TEntity : IEntity
    {
        public Expression<Func<TEntity, TKey>> Field { get; set; } 
        public Order Order { get; set; }
    }
}