using System.Data.Entity;

namespace Filmoteca.Models
{
    public class FilmeDb : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
    }
}