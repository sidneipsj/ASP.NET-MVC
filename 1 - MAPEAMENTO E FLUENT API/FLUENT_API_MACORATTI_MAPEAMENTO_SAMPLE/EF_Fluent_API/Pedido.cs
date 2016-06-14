using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Fluent_API
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string Item { get; set; }
        public int Quantidade { get; set; }
        public int Preco { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
