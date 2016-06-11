using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FluentAPI.Models.Maps;

namespace FluentAPI.Models
{
    public class BD_Vendas_fluent : DbContext
    {
        static BD_Vendas_fluent()
        { 
            Database.SetInitializer<BD_Vendas_fluent>(null);
        }

        public BD_Vendas_fluent()
            : base("BD_Vendas_fluent")
        {
            
        }

        //Propriedade que define os modelos do DB que deve ser criado
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<ItemVenda> ItemVendas { get; set; }
        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ItemVendaMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new VendaMap());

        }
    }
}