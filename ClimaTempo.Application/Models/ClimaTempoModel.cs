using ClimaTempo.Core.Enums;
using System;
using System.Collections.Generic;

namespace ClimaTempo.Application.Models
{
    public class ClimaTempoModel
    {
        public ICollection<TemperaturaCidade> MaisQuentes { get; set; }

        public ICollection<TemperaturaCidade> MaisFrias { get; set; }
    }
}