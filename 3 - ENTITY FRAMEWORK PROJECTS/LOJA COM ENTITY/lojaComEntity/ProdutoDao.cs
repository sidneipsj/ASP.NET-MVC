using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lojaComEntity.Entidades;

namespace lojaComEntity
{
    public class ProdutoDao
    {
        private EntidadesContext ctx;
        public ProdutoDao(EntidadesContext contexto)
        {
            ctx = contexto;
        }

        public void Adicionar(Produto p)
        {
            ctx.Produtos.Add(p);
            ctx.SaveChanges();
            ctx.Dispose();
        }

        public void Remove(Produto p)
        {
            ctx.Produtos.Remove(p);
            ctx.SaveChanges();
        }

        public Produto BuscaPorId(int id)
        {
            return this.ctx.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public IList<Produto> BuscaPorNomePrecoCategoria(string nome, decimal preco, string categoria)
        {
            var busca = from p in ctx.Produtos
                        select p;

            if (!string.IsNullOrEmpty(nome))
            {
                busca = busca.Where(p => p.Nome == nome);
            }

            if (preco > 0)
            {
                busca = busca.Where(p => p.preco == preco);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                busca = busca.Where(p => p.Categoria.Nome == categoria);
            }

            return busca.ToList();

        }
    }
}
