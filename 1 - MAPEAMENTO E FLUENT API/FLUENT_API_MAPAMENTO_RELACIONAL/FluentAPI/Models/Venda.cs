using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentAPI.Models
{
    public class Venda
    {
        public Venda()
        {
            this.ItemVendas = new List<ItemVenda>();
        }

        public long venda_id { get; set; }
        public long cliente_id { get; set; }
        public decimal total_venda { get; set; }
        public string status_venda { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime data_venda { get; set; }

        public virtual ICollection<ItemVenda> ItemVendas { get; set; }
    }
}