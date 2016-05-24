using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sidnei.DemoEF_Blog.Models;

namespace Sidnei.DemoEF_Blog.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inserir()
        {
            var autor = new Autor {Name = "Sidnei Sanches"};

            var artigo = new Artigo()
            {
                Autor = autor,
                Title = "Entity Framework",
                Text = "Uma forma simples e limpa de acessar os dados relacionais."
            };

            artigo.Tags.Add(new Tag { Title = ".NET" });
            artigo.Tags.Add(new Tag { Title = "Desenvolvimento" });
            artigo.Tags.Add(new Tag { Title = "ADO.NET" });
            artigo.Tags.Add(new Tag { Title = "Entity Framework" });

            using (var context = new DataBaseContext())
            {
                context.Artigos.Add(artigo);
                context.SaveChanges();
            }

            return View();

        }

        public ActionResult BuscandoDados()
        {
            using (var dataContext = new DataBaseContext())
            {
                var artigo = dataContext.Artigos
                .Include(a => a.Tags)
                .First(a => a.Title.Contains("Entity"));


            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            using (var dataContext = new DataBaseContext()) { 
                var artigo = dataContext.Artigos.Find(1);
                artigo.Title = "EF";
                dataContext.SaveChanges();
            }

            return View();
        }

        public ActionResult Remover(int id)
        {
            using (var dataContext = new DataBaseContext())
            {
                var artigo = dataContext.Artigos.Find(id);
                dataContext.Artigos.Remove(artigo);
                dataContext.SaveChanges();
            }
            return View();
        }


    }
}