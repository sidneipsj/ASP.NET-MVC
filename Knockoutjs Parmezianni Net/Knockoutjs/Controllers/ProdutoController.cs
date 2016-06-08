using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockoutjs.Models;

namespace Knockoutjs.Controllers
{
    public class ProdutoController : Controller
    {
        private static readonly IProduto repositorio = new ProdutoRepositorio();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAllProdutos()
        {
            return Json(repositorio.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProduto(Produto item)
        {
            item = repositorio.Add(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProduto(int id, Produto produto)
        {
            produto.Id = id;
            if(repositorio.Update(produto))
                return Json(repositorio.GetAll(), JsonRequestBehavior.AllowGet);

            return Json(null);
        }

        public ActionResult DeleteProduto(int id)
        {
            if(repositorio.Delete(id))
                return Json(new {Status = true}, JsonRequestBehavior.AllowGet);

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

        }

    }
}
