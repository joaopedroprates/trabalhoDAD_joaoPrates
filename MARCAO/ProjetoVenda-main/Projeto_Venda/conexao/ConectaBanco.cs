using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.conexao
{
    internal class ConectaBanco
    {
        SqlConnection con;
        string connectionString = @"Server=LAB4-01\SQLEXPRESS;Database=FUNEC24_DAD;
                                    Trusted_Connection=True;";

        public SqlConnection conectaSqlServer()
        {
            con = new SqlConnection(connectionString);

            return con;
        }
    }
}
