using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ForumTech.Repositorio
{
    public class VerificaUsuarioLogado : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Boolean usuarioLogado = AutenticarUsuario.verificarSessaoUsuario();

            if (!usuarioLogado)
            {
                filterContext.Result = new RedirectToRouteResult(
                 new RouteValueDictionary(
                     new { action = "Index", Controller = "Login", area = "" }));
            }

        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}