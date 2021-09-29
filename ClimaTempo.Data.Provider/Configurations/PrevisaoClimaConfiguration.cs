using ClimaTempo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Data.Provider.Configurations
{
    internal class PrevisaoClimaConfiguration
    {
        public static void Configure(DbModelBuilder dbModelBuilder)
        {
            var entity = dbModelBuilder.Entity<PrevisaoClima>();

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired().HasColumnName("Id");
            entity.Property(x => x.CidadeId).IsRequired().HasColumnName("CidadeId");
            entity.Property(x => x.Clima).IsRequired().HasColumnName("Clima");
            entity.Property(x => x.DataPrevisao).IsRequired().HasColumnName("DataPrevisao");
            entity.Property(x => x.TemperaturaMaxima).IsRequired().HasColumnName("TemperaturaMaxima");
            entity.Property(x => x.TemperaturaMinima).IsRequired().HasColumnName("TemperaturaMinima");

            entity.ToTable("PrevisaoClima");
        }
    }
}
