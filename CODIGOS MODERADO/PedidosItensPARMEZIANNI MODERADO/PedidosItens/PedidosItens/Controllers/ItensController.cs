using PedidosItens.Contexto;
using PedidosItens.Models;
using System.Linq;
using System.Web.Mvc;

namespace PedidosItens.Controllers
{
    public class ItensController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult ListarItens(int id)
        {
            var lista = db.Itens.Where(m => m.Pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }


        public ActionResult SalvarItens(int quantidade
            , string produto
            , int valorunitario
            , int idPedido)
        {

            var item = new Itens()
            {

                Quantidade = quantidade
                , Produto = produto
                , ValorUnitartio = valorunitario
                , Pedido = db.Pedidos.Find(idPedido)
            };

            db.Itens.Add(item);
            db.SaveChanges();

            return Json(new { Resultado = item.Id }, JsonRequestBehavior.AllowGet);
        }
    }
}