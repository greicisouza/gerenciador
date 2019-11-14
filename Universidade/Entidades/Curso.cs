﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidade.Entidades
{
    public class Curso
    {
        public int Codigo { get; set; }

        public int QuantidadePeriodo { get; set; }

        public string Nome { get; set; }

        public List<Materias> Materias { get; set; }

        public int Coordernador_id { get; set; }
    }
}
