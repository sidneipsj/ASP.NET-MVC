using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentAPI.Models
{
    public class Cliente
    {

        public Cliente()
        {
            this.Vendas = new List<Venda>();
        }
        public long cliente_id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_cadastro { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}