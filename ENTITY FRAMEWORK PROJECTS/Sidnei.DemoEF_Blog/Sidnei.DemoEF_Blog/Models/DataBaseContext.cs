using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sidnei.DemoEF_Blog.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Autor> Autors { get; set; }
    }
}