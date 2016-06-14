using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockoutjs.Models
{
    public class ProdutoRepositorio : IProduto
    {

        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;


        public ProdutoRepositorio()
        {
            Add(new Produto {Nome = "Laptop", Categoria = "Eletronicos", Preco = 15.23M});
            Add(new Produto { Nome = "NoteBook", Categoria = "Eletronicos", Preco = 23.23M });
            Add(new Produto { Nome = "UltraBook", Categoria = "Eletronicos", Preco = 32.23M });

        }


        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public Produto Add(Produto item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            item.Id = _nextId++;
            produtos.Add(item);

            return item;
        }

        public bool Update(Produto item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int index = produtos.FindIndex(p => p.Id == item.Id);

            if (index == -1)
                return false;

            produtos.RemoveAt(index);
            produtos.Insert(index,item);

            return true;
        }

        public bool Delete(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}