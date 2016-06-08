using PedidosItens.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PedidosItens.Contexto
{
    public class DBContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Itens> Itens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}