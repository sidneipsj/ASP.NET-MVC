﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSamples
{
    public class Pessoa
    {
        public Pessoa()
        {

        }

        public int Cod { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Endereco Endereco { get; set; }

    }
}
