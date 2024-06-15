using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.model
{
    internal class Funcionario
    {
        public int Cod { get; set; }
        public String Nome { get; set; }
        public String Numerocasa { get; set; }

        public Rua Rua { get; set; }
        public Bairro Bairro { get; set; }
        public Cep Cep { get; set; }
        public Cidade Cidade { get; set; }
        public Funcao Funcao { get; set; }
        public double Salario { get; set; }

        public Loja Loja { get; set; }
    }
}
