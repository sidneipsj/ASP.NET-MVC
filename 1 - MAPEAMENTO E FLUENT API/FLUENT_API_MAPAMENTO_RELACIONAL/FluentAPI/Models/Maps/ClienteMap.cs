using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FluentAPI.Models.Maps
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            this.HasKey(c => c.cliente_id);
            this.Property(c => c.nome).HasMaxLength(100);
            this.Property(c => c.nome).HasColumnName("nome_col");
            this.Property(c => c.data_cadastro).HasColumnName("data_cad");
            this.Property(c => c.cpf).HasMaxLength(11);
            this.ToTable("tb_cliente", "BD_Vendas_fluent");
        }
    }
}