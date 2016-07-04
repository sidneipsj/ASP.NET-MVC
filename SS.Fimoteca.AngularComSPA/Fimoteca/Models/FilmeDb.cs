using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fimoteca.Models
{
    public class FilmeDb : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
    }
}