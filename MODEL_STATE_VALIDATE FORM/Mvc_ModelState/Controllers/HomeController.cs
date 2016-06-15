using System.Web.Mvc;
using Mvc_ModelState.Models;

namespace Mvc_ModelState.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            Usuario model = new Usuario();
            return View(model);
        }

        [HttpPost]
        public ActionResult Incluir(Usuario model)
        {
            if (model.Nome == model.SobreNome)
            {
                ModelState.AddModelError("Sobrenome", "O sobrenome não pode ser igual ao nome.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}