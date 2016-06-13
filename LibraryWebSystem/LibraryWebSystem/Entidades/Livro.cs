using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebSystem.Entidades
{
    public class Livro
    {
        public int LivroId { get; set; }
        public int EditoraId { get; set; }
        public virtual Editora Editora{ get; set; }
        public virtual ICollection<Autor> Autor { get; set; }
        public string ISBN { get; set; }
        public int Paginas { get; set; }

    }
}