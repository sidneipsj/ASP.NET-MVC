using JqueryAjax.AspNetMVC.CRUD.Models.Model;
using JqueryAjax.AspNetMVC.CRUD.Models.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryAjax.AspNetMVC.CRUD.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        public void Cadastrar(PessoaModel pessoa)
        {
            try
            {
                new PessoaNeg().Cadastrar(pessoa);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}