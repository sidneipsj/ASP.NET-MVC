namespace Filmoteca.Migrations
{
    using System.Data.Entity.Migrations;
    using Filmoteca.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Filmoteca.Models.FilmeDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true ;
        }

        protected override void Seed(FilmeDb context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

                context.Filmes.AddOrUpdate(
                  p => p.Titulo,
                  new Filme { Titulo = "Star Wars", AnoLancamento = 2016, Duracao = 170 },
                  new Filme { Titulo = "Casino Royale ", AnoLancamento = 2006, Duracao = 121 },
                  new Filme { Titulo = "Riddick", AnoLancamento = 2004, Duracao = 130 },
                  new Filme { Titulo = "Identidade Bourne", AnoLancamento = 2002, Duracao = 110 },
                  new Filme { Titulo = "A Ilha", AnoLancamento = 2005, Duracao = 135 }
                );
            
        }
    }
}
