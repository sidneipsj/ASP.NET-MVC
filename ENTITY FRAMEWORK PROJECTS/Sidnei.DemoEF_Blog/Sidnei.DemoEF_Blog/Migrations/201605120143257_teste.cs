namespace Sidnei.DemoEF_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Autor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autors", t => t.Autor_Id)
                .Index(t => t.Autor_Id);
            
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artigo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artigoes", t => t.Artigo_Id)
                .Index(t => t.Artigo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Artigo_Id", "dbo.Artigoes");
            DropForeignKey("dbo.Artigoes", "Autor_Id", "dbo.Autors");
            DropIndex("dbo.Tags", new[] { "Artigo_Id" });
            DropIndex("dbo.Artigoes", new[] { "Autor_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Autors");
            DropTable("dbo.Artigoes");
        }
    }
}
