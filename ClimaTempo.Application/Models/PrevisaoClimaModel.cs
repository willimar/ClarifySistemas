using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Application.Models
{
    public class PrevisaoClimaModel
    {
        public ICollection<TemperaturaCidade> Previsoes { get; set; }
        public string NomeCidade { get; set; }
    }
}
