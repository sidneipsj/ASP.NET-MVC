using LibraryWebSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LibraryWebSystem.DAO
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
            : base("BibliotecaContext")
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Editora>().ToTable("Editora");
            modelBuilder.Entity<Livro>().ToTable("Livro");

        }

    }
}