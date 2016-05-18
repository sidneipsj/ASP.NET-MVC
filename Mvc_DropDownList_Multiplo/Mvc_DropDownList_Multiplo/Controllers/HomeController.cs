using Mvc_DropDownList_Multiplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_DropDownList_Multiplo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new NorthwindEntities())
            {
                var segmentos = db.SEGMENTOS.Select(c => new
                {
                    SegmentoID = c.SEG_ID,
                    segmentoName = c.DESCRICAO
                }).ToList();

                ViewBag.Segmentos = new MultiSelectList(segmentos, "SegmentoID", "SegmentoName");
                ViewBag.Segmentos = new MultiSelectList(segmentos, "SegmentoID", "SegmentoName",new[]{1,3,7});
                return View();
                                 
            }
        }

        [HttpPost]
        public ActionResult Selecao(int[] categoryId)
        {
            return View();
        }
    }
}