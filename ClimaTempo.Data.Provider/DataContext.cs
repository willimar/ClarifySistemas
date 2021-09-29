using ClimaTempo.Data.Provider.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Provider
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }

    public class DataContext: DbContext
    {
        public DataContext() : base(DataContext.GetConnection())
        {
            Database.SetInitializer<DataContext>(null);
        }

        private static string GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            return connection;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            CidadeConfiguration.Configure(modelBuilder);
            EstadoConfiguration.Configure(modelBuilder);
            PrevisaoClimaConfiguration.Configure(modelBuilder);
        }
    }
}
