using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.model
{
    internal class Logins
    {
        public int Cod { get;set; }
        public String Nome { get;set; }
        public String Senha { get;set; }

        public Funcionario Funcionario { get;set;}
    }
}
