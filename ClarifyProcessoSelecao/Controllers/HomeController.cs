using ClimaTempo.Application.Applications;
using ClimaTempo.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ClarifyProcessoSelecao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClimaTempoApplication _climaTempoApplication;
        private static ICollection<CidadeModel> cidades;

        public HomeController(ClimaTempoApplication climaTempoApplication)
        {
            this._climaTempoApplication = climaTempoApplication;

            // Não é a forma recomendada de se fazer cache.
            if (HomeController.cidades is null)
            {
                HomeController.cidades = this._climaTempoApplication.GetCidades().Result;
            }
        }

        public async Task<ActionResult> Index()
        {
            ClimaTempoModel climaTempoModel = await this._climaTempoApplication.GetClimaTempo();

            ViewBag.MaisQuentes = climaTempoModel.MaisQuentes;
            ViewBag.MaisFrias = climaTempoModel.MaisFrias;

            return View();
        }

        public async Task<JsonResult> GetCidades(string query)
        {
            var result = HomeController.cidades;

            if (!string.IsNullOrWhiteSpace(query))
            {
                result = result.Where(x => x.Text.ToLower().Contains(query.ToLower())).ToList();
            }

            return await Task.FromResult(Json(new { items = result }, JsonRequestBehavior.AllowGet));
        }

        public async Task<JsonResult> GetPrevisao(int cidadeId)
        {
            var result = await this._climaTempoApplication.GetPrevisao(cidadeId);

            return await Task.FromResult(Json(new { result = result }, JsonRequestBehavior.AllowGet));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}