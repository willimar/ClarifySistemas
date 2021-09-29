using ClimaTempo.Core.Entities;
using ClimaTempo.Core.Interfaces;
using ClimaTempo.Data.Core;
using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Core.Services
{
    public class PrevisaoClimaService : IPrevisaoClimaService
    {
        private readonly IRepository<PrevisaoClima> _repository;

        public PrevisaoClimaService(IRepository<PrevisaoClima> repository)
        {
            this._repository = repository;
        }

        public async Task<ICollection<PrevisaoClima>> CidadesMaisQuentes()
        {
            var inicio = DateTime.UtcNow.AddDays(-1);
            var fim = DateTime.UtcNow.AddDays(1);
            var order = new OrderField<PrevisaoClima, decimal>() { Field = x => x.TemperaturaMaxima, Order = Order.dsc };

            var result = this._repository
                .GetData(x => x.DataPrevisao < fim && x.DataPrevisao > inicio, order, 3).ToList();

            return await Task.FromResult(result);
        }

        public async Task<ICollection<PrevisaoClima>> CidadesMaisFrias()
        {
            var inicio = DateTime.UtcNow.AddDays(-1);
            var fim = DateTime.UtcNow.AddDays(1);
            var order = new OrderField<PrevisaoClima, decimal>() { Field = x => x.TemperaturaMaxima, Order = Order.asc };

            var result = this._repository
                .GetData(x => x.DataPrevisao < fim && x.DataPrevisao > inicio, order, 3).ToList();

            return await Task.FromResult(result);
        }

        public async Task<ICollection<PrevisaoClima>> ProximosDiasCidade(int cidade, int dias)
        {
            var inicio = DateTime.UtcNow.AddDays(-1);
            var order = new OrderField<PrevisaoClima, DateTime>() { Field = x => x.DataPrevisao, Order = Order.asc };

            var result = this._repository
                .GetData(x => x.DataPrevisao > inicio && x.CidadeId == cidade, order, dias).ToList();

            return await Task.FromResult(result);
        }
    }
}
