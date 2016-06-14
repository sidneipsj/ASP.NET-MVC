using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentAPI.Models
{
    public class ItemVenda
    {
        public long item_venda_id { get; set; }
        public long venda_id { get; set; }
        public long produto_id { get; set; }
        public decimal quantidade { get; set; }
        public decimal subtotal { get; set; }
        public string status_item { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}