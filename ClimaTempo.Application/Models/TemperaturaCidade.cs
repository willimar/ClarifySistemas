using ClimaTempo.Core.Enums;
using System;
using System.Globalization;
using ClimaTempo.Core.Extensions;

namespace ClimaTempo.Application.Models
{
    public class TemperaturaCidade
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Maxima { get; set; }
        public int Minima { get; set; }
        public CondicaoTempo Condicao {get; set;}
        public DateTime Dia { get; set; }
        public string DiaSemana => this.Dia.ToString("dddd", CultureInfo.CreateSpecificCulture("pt-BR"));
        public string Icon => this.Condicao.GetNomeTempo();
        public string CondicaoNome => this.Condicao.GetName();
    }
}