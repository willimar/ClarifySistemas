using ClimaTempo.Application.Applications;
using ClimaTempo.Core.Entities;
using ClimaTempo.Core.Interfaces;
using ClimaTempo.Core.Repositories;
using ClimaTempo.Core.Services;
using ClimaTempo.Data.Core.Interfaces;
using ClimaTempo.Data.Provider;
using Ninject;
using System.Web.Http;

namespace ClimaTempo.Application.Setups
{
    public class ApplicationResolver
    {
        public static void Resolver(IKernel kernel)
        {            
            kernel.Bind<ClimaTempoApplication>().To<ClimaTempoApplication>();
            kernel.Bind<IPrevisaoClimaService>().To<PrevisaoClimaService>();

            kernel.Bind<IRepository<PrevisaoClima>>().To<PrevisaoClimaRepository>();
            kernel.Bind<IRepository<Cidade>>().To<CidadeRepository>();

            kernel.Bind<IDataProvider>().To<DataProvider>();
            kernel.Bind<DataContext>().To<DataContext>();
        }
    }
}
