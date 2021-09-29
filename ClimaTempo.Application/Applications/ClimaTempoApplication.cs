using ClimaTempo.Application.Models;
using ClimaTempo.Core.Entities;
using ClimaTempo.Core.Enums;
using ClimaTempo.Core.Interfaces;
using ClimaTempo.Data.Core;
using ClimaTempo.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClimaTempo.Application.Applications
{
    public class ClimaTempoApplication
    {
        private readonly IPrevisaoClimaService _previsaoClimaService;
        private readonly IRepository<Cidade> _cidadeRepository;

        public ClimaTempoApplication(IPrevisaoClimaService previsaoClimaService, IRepository<Cidade> cidadeRepository)
        {
            this._previsaoClimaService = previsaoClimaService;
            this._cidadeRepository = cidadeRepository;
        }

        public async Task<ClimaTempoModel> GetClimaTempo()
        {
            var maisQuente = await this._previsaoClimaService.CidadesMaisQuentes();
            var maisFrio = await this._previsaoClimaService.CidadesMaisFrias();
            var previsao = await this._previsaoClimaService.ProximosDiasCidade(0, 0);

            return await Task.FromResult(
                new ClimaTempoModel() 
                { 
                    MaisFrias = ClimaTempoApplication.GetPrevisoes(maisFrio), 
                    MaisQuentes = ClimaTempoApplication.GetPrevisoes(maisQuente),
                });
        }

        public async Task<ICollection<CidadeModel>> GetCidades()
        {
            var order = new OrderField<Cidade, string>() { Field = x => x.Nome, Order = Order.asc };
            var cidades = this._cidadeRepository.GetData(x => true, order, 0).Select(x => new CidadeModel() { Id = x.Id, Text = x.Nome }).ToList();

            return await Task.FromResult(cidades);
        }

        public async Task<PrevisaoClimaModel> GetPrevisao(int cidadeId)
        {
            var previsoes = ClimaTempoApplication.GetPrevisoes(await this._previsaoClimaService.ProximosDiasCidade(cidadeId, 7));
            var previsao = new PrevisaoClimaModel() 
            { 
                Previsoes = previsoes,
                NomeCidade = HttpUtility.HtmlEncode(previsoes.FirstOrDefault()?.Cidade),
            };

            return await Task.FromResult(previsao);
        }

        private static ICollection<TemperaturaCidade> GetPrevisoes(ICollection<PrevisaoClima> previsaoClima)
        {
            return previsaoClima.Select(x => new TemperaturaCidade()
            {
                Cidade = x.Cidade.Nome,
                Condicao = (CondicaoTempo)Enum.Parse(typeof(CondicaoTempo), x.Clima),
                Dia = x.DataPrevisao,
                Estado = x.Cidade.Estado.Uf,
                Maxima = Convert.ToInt32(x.TemperaturaMaxima),
                Minima = Convert.ToInt32(x.TemperaturaMinima),
            }).ToList();
        }
    }
}
