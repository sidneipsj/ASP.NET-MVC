using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantaoAPI.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public string CodCartao { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}