using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_caua_joao.controller
{
    internal interface I_CRUD
    {
        void insereDados(Object obj);
        void editaDados(Object obj);
        void apagaDados(int cod);
        DataTable buscarTodos();
    }
}
