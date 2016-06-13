using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevMedia.Forum.Models;
using DevMedia.Forum.Repositorio;

namespace DevMedia.Forum.Controllers
{
    [VerificaUsuarioLogado]
    public class TopicoController : Controller
    {

        private DB_FORUMEntities db = new DB_FORUMEntities();
        // GET: Topico
        public ActionResult Index()
        {
            return View(db.topico_forum.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Topico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_topico,nome,descricao,data_cadastro")] topico_forum topico_forum)
        {
            if (ModelState.IsValid)
            {
                db.topico_forum.Add(topico_forum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topico_forum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}