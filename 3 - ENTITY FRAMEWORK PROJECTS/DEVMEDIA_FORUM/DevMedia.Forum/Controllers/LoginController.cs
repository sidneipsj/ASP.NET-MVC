﻿using DevMedia.Forum.Models;
using DevMedia.Forum.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
<<<<<<< HEAD
using DevMedia.Forum.Models;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
=======
>>>>>>> fd44b46a213c449fde28313844062b17055ebe19

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
            autenticarUsuario = AutenticarUsuario.autenticarUsuario(login, senha);
            if (autenticarUsuario != null)
            {
                Session.Add("usuario", autenticarUsuario);
                return Redirect("/Postagem/Index");
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
            EntityFrameworkProfiler.Initialize();

            DB_FORUMEntities ctx = new DB_FORUMEntities();

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