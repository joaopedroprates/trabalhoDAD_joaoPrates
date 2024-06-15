using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.model
{
    internal class Cliente
    {
        public int Cod { get; set; }
        public String Nome { get; set; }
        public byte[] Foto { get; set; }
        
        public DateTime Datanasc { get; set; }
        public Sexo Sexo {get; set;}
        public Rua Rua { get; set;}
        public Bairro Bairro { get; set;}
        public Cep Cep { get; set;}
        public Cidade Cidade { get; set;}

        public double Salario { get; set; }
        
        public Trabalho Trabalho { get; set;}
        
        public String Numerocasa { get; set; }  
    }
}
