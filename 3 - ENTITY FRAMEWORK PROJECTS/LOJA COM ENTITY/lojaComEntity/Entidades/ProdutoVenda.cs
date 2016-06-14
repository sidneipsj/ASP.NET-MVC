using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Entidades
{
    public class ProdutoVenda
    {
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
        public int Id { get; set; }

    }
}
