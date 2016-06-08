using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Fluent_API
{
    public class VendasContexto : DbContext
    {
        public DbSet <Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public VendasContexto()
            : base("name=VendasConnectionString")
        {}

        /// <summary>
        /// O método OnModelCreating, aceita o objeto  DbModelBuilder como parâmetro. 
        /// Esta classe é usada para mapear as classes CLR para o esquema do banco de dados.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.ClienteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // tamanho máximo para as propriedades Nome,Endereco,Telefone e Cidade
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(80);
            modelBuilder.Entity<Cliente>().Property(c => c.Endereco).HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(c => c.Telefone).HasMaxLength(20);
            modelBuilder.Entity<Cliente>().Property(c => c.Cidade).HasMaxLength(50);
            //Mapeamento para a tabela Pedido
            //S1: Chave Primaria para a tabela Pedido
            modelBuilder.Entity<Pedido>().HasKey(p => p.PedidoId);
            //S2: Uma chave identity para o PedidoId
            modelBuilder.Entity<Pedido>().Property(p => p.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //S2: O tamanho máximo para o item
            modelBuilder.Entity<Pedido>().Property(p => p.Item).HasMaxLength(50);
            //S3: A chave estrangeira para a tabela Pedido - ClienteId
            modelBuilder.Entity<Pedido>().HasRequired(c => c.Cliente)
             .WithMany(p => p.Pedidos).HasForeignKey(p => p.ClienteId);
            // A deleção em cascata a partir de Cliente para Pedidos
            modelBuilder.Entity<Pedido>()
                .HasRequired(c => c.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
