using ClimaTempo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Provider.Configurations
{
    internal class EstadoConfiguration
    {
        public static void Configure(DbModelBuilder dbModelBuilder)
        {
            var entity = dbModelBuilder.Entity<Estado>();

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired().HasColumnName("Id");
            entity.Property(x => x.Nome).IsRequired().HasColumnName("Nome");
            entity.Property(x => x.Uf).IsRequired().HasColumnName("Uf");

            entity.ToTable("Estado");
        }
    }
}
