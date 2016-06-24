using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafegandoInformacoesNaView.Models;

namespace TrafegandoInformacoesNaView.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            ViewBag.Categoria = "Informática";
            ViewData["Categoria"] = "Teste";
            TempData["Produto"] = "Notebook";
            Session["Usuario"] = "sidneipsj";

            ViewBag.DadosBrasil = new Pais()
            {
                Nome = "Brasil",
                Continente = "América do Sul",
                Capital = "Brasilia",
                CodigoTelefonico = "55"
            };

            var Brasil = new Pais()
            {
                Nome = "Brasil",
                Continente = "América do Sul",
                Capital = "Brasilia",
                CodigoTelefonico = "55"
            };

            return View(Brasil);
        }

        public JsonResult testejson()
        {
            var Brasil = new Pais()
            {
                Nome = "Brasil",
                Continente = "América do Sul",
                Capital = "Brasilia",
                CodigoTelefonico = "55"
            };

            return Json(Brasil, JsonRequestBehavior.AllowGet);
        }
    }
}