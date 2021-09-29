using ClimaTempo.Core.Enums;
using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Core.Entities
{
    public class PrevisaoClima : IEntity
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
    }
}
