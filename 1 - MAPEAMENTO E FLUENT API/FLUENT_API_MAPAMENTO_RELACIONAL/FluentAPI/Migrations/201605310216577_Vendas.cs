namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BD_Vendas_fluent.tb_cliente",
                c => new
                    {
                        cliente_id = c.Long(nullable: false, identity: true),
                        nome_col = c.String(maxLength: 100),
                        cpf = c.String(maxLength: 11),
                        data_cad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cliente_id);
            
            CreateTable(
                "BD_Vendas_fluent.tb_venda",
                c => new
                    {
                        venda_id = c.Long(nullable: false, identity: true),
                        cliente_id = c.Long(nullable: false),
                        total_venda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status_venda = c.String(maxLength: 1),
                        data_venda = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.venda_id)
                .ForeignKey("BD_Vendas_fluent.tb_cliente", t => t.cliente_id, cascadeDelete: true)
                .Index(t => t.cliente_id);
            
            CreateTable(
                "BD_Vendas_fluent.tb_item_venda",
                c => new
                    {
                        item_venda_id = c.Long(nullable: false, identity: true),
                        venda_id = c.Long(nullable: false),
                        produto_id = c.Long(nullable: false),
                        quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status_item = c.String(),
                    })
                .PrimaryKey(t => t.item_venda_id)
                .ForeignKey("BD_Vendas_fluent.tb_produto", t => t.produto_id, cascadeDelete: true)
                .ForeignKey("BD_Vendas_fluent.tb_venda", t => t.venda_id, cascadeDelete: true)
                .Index(t => t.venda_id)
                .Index(t => t.produto_id);
            
            CreateTable(
                "BD_Vendas_fluent.tb_produto",
                c => new
                    {
                        produto_id = c.Long(nullable: false, identity: true),
                        nome = c.String(maxLength: 50),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.produto_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("BD_Vendas_fluent.tb_item_venda", "venda_id", "BD_Vendas_fluent.tb_venda");
            DropForeignKey("BD_Vendas_fluent.tb_item_venda", "produto_id", "BD_Vendas_fluent.tb_produto");
            DropForeignKey("BD_Vendas_fluent.tb_venda", "cliente_id", "BD_Vendas_fluent.tb_cliente");
            DropIndex("BD_Vendas_fluent.tb_item_venda", new[] { "produto_id" });
            DropIndex("BD_Vendas_fluent.tb_item_venda", new[] { "venda_id" });
            DropIndex("BD_Vendas_fluent.tb_venda", new[] { "cliente_id" });
            DropTable("BD_Vendas_fluent.tb_produto");
            DropTable("BD_Vendas_fluent.tb_item_venda");
            DropTable("BD_Vendas_fluent.tb_venda");
            DropTable("BD_Vendas_fluent.tb_cliente");
        }
    }
}
