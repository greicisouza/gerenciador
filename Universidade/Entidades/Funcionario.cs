using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidade.Entidades
{
    class Funcionario : Pessoa
    {
        public int Setor_id { get; set; }
        public int Cargo_id { get; set; }
    }
}
