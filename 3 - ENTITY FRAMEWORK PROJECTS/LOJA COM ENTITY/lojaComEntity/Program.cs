using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using lojaComEntity.Entidades;

namespace lojaComEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntidadesContext ctx = new EntidadesContext();
            //var usuarioDao = new UsuarioDao(ctx);
            //var produtoDao = new ProdutoDao(ctx);

            //var sidnei = usuarioDao.BuscaPorId(1);
            //var venda = new Venda()
            //{
            //    Cliente = sidnei
            //};

            //ctx.Vendas.Add(venda);

            //var produto1 = produtoDao.BuscaPorId(1);
            //var produto2 = produtoDao.BuscaPorId(2);

            //var produtoVenda1 = new ProdutoVenda()
            //{
            //    Venda = venda,
            //    Produto = produto1
            //};
            //ctx.ProdutoVendas.Add(produtoVenda1);

            //var produtoVenda2 = new ProdutoVenda()
            //{
            //    Venda = venda,
            //    Produto = produto2
            //};

            //ctx.ProdutoVendas.Add(produtoVenda2);

            //ctx.SaveChanges();

            //ctx.Dispose();

            EntidadesContext ctx = new EntidadesContext();
            Venda venda = ctx.Vendas.FirstOrDefault(v => v.Id == 1).Include(v => v.ProdutoVendas).ThenInclude(pv => pv.Produto);

            foreach (var pv in venda.ProdutoVendas)
            {
                Console.WriteLine(pv.Produto.Nome);
            }

            ctx.Dispose();
            Console.ReadLine();

        }

    }
}
