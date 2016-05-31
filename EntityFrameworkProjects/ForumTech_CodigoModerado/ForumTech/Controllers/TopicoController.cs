using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ForumTech.Models;
using ForumTech.Repositorio;

namespace ForumTech.Controllers
{
    [VerificaUsuarioLogado]
    public class TopicoController : Controller
    {
        private BD_FORUMEntities db = new BD_FORUMEntities();

        // GET: Topico
        public ActionResult Index()
        {
            return View(db.topico_forum.ToList());
        }

        // GET: Topico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_topico_forum,nome,descricao,data_cadastro")] topico_forum topico_forum)
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
