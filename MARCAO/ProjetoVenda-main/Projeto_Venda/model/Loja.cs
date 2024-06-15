using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.model
{
    internal class Loja
    {
        public int Cod { get; set; }
        public String Nome { get; set; }
        public String CNPJ { get; set; }
        public String NomeFantasia { get; set; }
        public String RazaoSocial { get; set; }
        public Loja() { }
    }
}