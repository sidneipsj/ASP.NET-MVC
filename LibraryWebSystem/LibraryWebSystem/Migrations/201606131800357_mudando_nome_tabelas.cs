namespace LibraryWebSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudando_nome_tabelas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Autors", newName: "Autor");
            RenameTable(name: "dbo.Livroes", newName: "Livro");
            RenameTable(name: "dbo.Editoras", newName: "Editora");
            RenameTable(name: "dbo.LivroAutors", newName: "LivroAutor");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LivroAutor", newName: "LivroAutors");
            RenameTable(name: "dbo.Editora", newName: "Editoras");
            RenameTable(name: "dbo.Livro", newName: "Livroes");
            RenameTable(name: "dbo.Autor", newName: "Autors");
        }
    }
}
