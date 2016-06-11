using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FluentAPI.Models.Maps
{
    public class ItemVendaMap : EntityTypeConfiguration<ItemVenda>
    {
        public ItemVendaMap()
        {
            this.HasKey(i => i.item_venda_id);
            this.ToTable("tb_item_venda", "BD_Vendas_fluent");

            this.HasRequired(i => i.Produto).WithMany(p => p.ItemVenda)
                .HasForeignKey(p => p.produto_id);

            this.HasRequired(i => i.Venda).WithMany(p => p.ItemVendas)
                .HasForeignKey(p => p.venda_id);
        }
    }
}