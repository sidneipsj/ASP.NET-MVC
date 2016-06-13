using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAPI.Models
{
    public class Produto
    {
        public Produto()
        {
            this.ItemVenda = new List<ItemVenda>();
        }

        public long produto_id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public DateTime data_cadastro { get; set; }
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}