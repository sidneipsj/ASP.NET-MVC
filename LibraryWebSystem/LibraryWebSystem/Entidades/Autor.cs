using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebSystem.Entidades
{
    public class Autor
    {
        public int AutorId { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
        public string Email { get; set; }
    }
}