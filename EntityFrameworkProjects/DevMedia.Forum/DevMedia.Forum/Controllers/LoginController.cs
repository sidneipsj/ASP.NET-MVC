using DevMedia.Forum.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevMedia.Forum.Controllers
{
    public class LoginController : Controller
    {

        private usuario autenticarUsuario;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String login, String senha)
        {
            if (autenticarUsuario != null)
            {
                Session.Add("usuario", autenticarUsuario);
                return Redirect("/Posts/Index");
            }
            else
            {
                ViewBag.ErroAutenticacao = "Usuário ou senha inválidos.";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(usuario usuario)
        {

            BD_FORUMEntities ctx = new BD_FORUMEntities();

            var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.senha, "MD5");

            usuario.senha = senhaCriptografada;
            usuario.data_cadastro = DateTime.Now;
            usuario.adm = "N";
            ctx.usuario.Add(usuario);
            ctx.SaveChanges();

            ViewBag.StatusCadastro = "Cadastro realizado com sucesso.";

            return View("Index");
        }
    }
}