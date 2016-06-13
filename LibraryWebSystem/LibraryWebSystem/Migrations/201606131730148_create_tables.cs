namespace LibraryWebSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        EditoraId = c.Int(nullable: false),
                        ISBN = c.String(),
                        Paginas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Editoras", t => t.EditoraId, cascadeDelete: true)
                .Index(t => t.EditoraId);
            
            CreateTable(
                "dbo.Editoras",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EditoraId);
            
            CreateTable(
                "dbo.LivroAutors",
                c => new
                    {
                        Livro_LivroId = c.Int(nullable: false),
                        Autor_AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Livro_LivroId, t.Autor_AutorId })
                .ForeignKey("dbo.Livroes", t => t.Livro_LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.Autor_AutorId, cascadeDelete: true)
                .Index(t => t.Livro_LivroId)
                .Index(t => t.Autor_AutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "EditoraId", "dbo.Editoras");
            DropForeignKey("dbo.LivroAutors", "Autor_AutorId", "dbo.Autors");
            DropForeignKey("dbo.LivroAutors", "Livro_LivroId", "dbo.Livroes");
            DropIndex("dbo.LivroAutors", new[] { "Autor_AutorId" });
            DropIndex("dbo.LivroAutors", new[] { "Livro_LivroId" });
            DropIndex("dbo.Livroes", new[] { "EditoraId" });
            DropTable("dbo.LivroAutors");
            DropTable("dbo.Editoras");
            DropTable("dbo.Livroes");
            DropTable("dbo.Autors");
        }
    }
}
