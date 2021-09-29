using ClimaTempo.Core.Entities;
using ClimaTempo.Data.Core;
using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Core.Repositories
{
    public class PrevisaoClimaRepository : BaseRepository<PrevisaoClima>
    {
        public PrevisaoClimaRepository(IDataProvider provider) : base(provider)
        {
        }
    }
}
