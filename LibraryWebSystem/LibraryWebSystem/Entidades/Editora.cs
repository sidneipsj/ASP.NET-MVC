using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebSystem.Entidades
{
    public class Editora
    {
        public int EditoraId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}