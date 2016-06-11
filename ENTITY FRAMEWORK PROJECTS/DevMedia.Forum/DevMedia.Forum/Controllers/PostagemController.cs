using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevMedia.Forum.Models;
using DevMedia.Forum.Repositorio;

namespace DevMedia.Forum.Controllers
{
    [VerificaUsuarioLogado]
    public class PostagemController : Controller
    {
        private DB_FORUMEntities db = new DB_FORUMEntities();

        // GET: Postagem
        public ActionResult Index(int? id_topico_forum)
        {
            var nomeTopico = db.topico_forum.Find(id_topico_forum);
            var postagem = db.postagem.Where(p => p.topico_forum.id_topico_forum == id_topico_forum).Include(p => p.topico_forum).Include(p => p.usuario);

            ViewBag.nomeTopico = nomeTopico.nome;
            return View(postagem.ToList());
        }

        // GET: Postagem/Create
        public ActionResult Create()
        {
            ViewBag.id_topico_forum = new SelectList(db.topico_forum, "id_topico_forum", "nome");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "nome");
            return View();
        }

        // POST: Postagem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_postagem,id_topico_forum,id_usuario,id_resposta,mensagem,data_publicacao")] postagem postagem)
        {
            if (ModelState.IsValid)
            {
                usuario usuarioLogado = AutenticarUsuario.retornarUsuarioDaSessao();

                postagem.id_usuario = usuarioLogado.id_usuario;
                postagem.data_publicacao = DateTime.Now;

                db.postagem.Add(postagem);
                db.SaveChanges();

                return RedirectToAction("Index", new { id_topico_forum = postagem.id_topico_forum });
            }

            ViewBag.id_topico_forum = new SelectList(db.topico_forum, "id_topico_forum", "nome", postagem.id_topico_forum);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "nome", postagem.id_usuario);
            return View(postagem);
        }

        protected override void Dispose(bool disposing)
        {
            
        }
        
    }

}