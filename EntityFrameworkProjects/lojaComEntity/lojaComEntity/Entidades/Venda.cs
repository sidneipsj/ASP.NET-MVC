using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Entidades
{
    public class Venda
    {
        public Venda()
        {
            this.ProdutoVendas = new List<ProdutoVenda>();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Cliente { get; set; }
        public virtual IList<ProdutoVenda> ProdutoVendas { get; set; }
    }
}
