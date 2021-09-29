using ClimaTempo.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClimaTempo.Core.Interfaces
{
    public interface IPrevisaoClimaService
    {
        Task<ICollection<PrevisaoClima>> CidadesMaisFrias();
        Task<ICollection<PrevisaoClima>> CidadesMaisQuentes();
        Task<ICollection<PrevisaoClima>> ProximosDiasCidade(int cidade, int dias);
    }
}