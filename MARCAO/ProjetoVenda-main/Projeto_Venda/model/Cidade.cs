using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.model
{
    internal class Cidade
    {
        public int Cod { get; set; }
        public String Nome { get; set; }
        public Uf Uf { get; set; }

        public Cidade() { }
    }
}
