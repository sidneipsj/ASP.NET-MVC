using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fimoteca.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public int Duracao { get; set; }
    }
}