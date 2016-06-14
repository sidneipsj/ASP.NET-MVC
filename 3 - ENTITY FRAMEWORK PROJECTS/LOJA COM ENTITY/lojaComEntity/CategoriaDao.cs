using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lojaComEntity.Entidades;

namespace lojaComEntity
{
    public class CategoriaDao
    {
        private EntidadesContext ctx;

        public CategoriaDao(EntidadesContext ctx)
        {
            this.ctx = ctx;
        }

        public void Adicionar(Categoria c)
        {
            this.ctx.Categorias.Add(c);
            this.ctx.SaveChanges();
        }

        public void Remove(Categoria c)
        {
            this.ctx.Categorias.Remove(c);
            this.ctx.SaveChanges();
        }

        public Categoria BuscaPorId(int id)
        {
            return this.ctx.Categorias.FirstOrDefault(c => c.Id == id);
        }
    }
}
