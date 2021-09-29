using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Core.Entities
{
    public class Estado : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
    }
}
