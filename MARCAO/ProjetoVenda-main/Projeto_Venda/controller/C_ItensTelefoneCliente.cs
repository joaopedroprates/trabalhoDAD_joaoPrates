using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.controller
{
    internal class C_ItensTelefoneCliente
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable ItensTelefoneClientes;

        string sqlApagar = @"DELETE FROM ITENSTELCLIENTE 
                            WHERE CODTELEFONE = @CodTelefone AND CODCLIENTE  = @CodCliente";
        string sqlInsere = @"INSERT INTO ITENSTELCLIENTE(CODTELEFONE, CODCLIENTE)
                            VALUES (@CodTelefone, @CodCliente)";
      //  string sqlEditar = @"UPDATE ItensTelefoneCliente
      // SET CodTelefone = @CodTelefone
      //,CODCLIENTE = @CodCliente
      // WHERE CODTELEFONE = @CodTelefone AND CODCLIENTE  = @CodCliente";
        string sqlTodos = @"SELECT 
    t.Numero,
    c.Nome,
    itc.CodTelefone as CodTelefone,
    itc.CodCliente as CodCliente
FROM ITENSTELCLIENTE itc
INNER JOIN TELEFONE t ON t.COD = itc.CodTelefone
INNER JOIN CLIENTE c ON c.COD = itc.CodCliente
";

        public void apagaDados(int cod, int cod1)
        {
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlApagar, con);
            cmd.Parameters.AddWithValue("@CodTelefone", cod);
            cmd.Parameters.AddWithValue("@CodCliente", cod1);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("ItensTelefoneCliente deletada com Sucesso!!!\n" +
                        "Código: " + cod);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Apagar!\nErro:" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void insereDados(object obj)
        {
            ItensTelefoneCliente ItensTelefoneCliente = new ItensTelefoneCliente();
            ItensTelefoneCliente = (ItensTelefoneCliente)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@CodTelefone", ItensTelefoneCliente.CodTelefone.Cod);
            cmd.Parameters.AddWithValue("@CodCliente", ItensTelefoneCliente.CodCliente.Cod);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registro incluído com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir dados!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        //public void editaDados(object obj)
        //{
        //    ItensTelefoneCliente ItensTelefoneCliente = new ItensTelefoneCliente();
        //    ItensTelefoneCliente = (ItensTelefoneCliente)obj;
        //    ConectaBanco cb = new ConectaBanco();
        //    con = cb.conectaSqlServer();
        //    cmd = new SqlCommand(sqlEditar, con);
        //    try
        //    {
        //        cmd.Parameters.AddWithValue("@CodTelefone", ItensTelefoneCliente.CodTelefone);
        //        cmd.Parameters.AddWithValue("@CodCliente", ItensTelefoneCliente.CodCliente.Cod);
        //        cmd.CommandType = CommandType.Text;
        //        con.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        if (i > 0) MessageBox.Show("Registro editado com sucesso");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao editar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public DataTable buscarTodos()
        {
            ConectaBanco conectaBanco = new ConectaBanco();
            con = conectaBanco.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            try
            {
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                ItensTelefoneClientes = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(ItensTelefoneClientes);
            }
            catch
            {
                ItensTelefoneClientes = null;
            }
            return ItensTelefoneClientes;
        }
        public List<ItensTelefoneCliente> carregaDados()
        {
            List<ItensTelefoneCliente> lista_ItensTelefoneCliente = new List<ItensTelefoneCliente>();

            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);

            cmd.CommandType = CommandType.Text;

            SqlDataReader tabItensTelefoneCliente; //Representa uma Tabela Virtual para a leitura de dados
            con.Open();


            try
            {
                tabItensTelefoneCliente = cmd.ExecuteReader();
                while (tabItensTelefoneCliente.Read())
                {
                    ItensTelefoneCliente aux = new ItensTelefoneCliente();

                    aux.CodTelefone.Cod = Int32.Parse(tabItensTelefoneCliente["CodTelefone"].ToString());
                    aux.CodCliente.Cod = Int32.Parse(tabItensTelefoneCliente["CodCliente"].ToString());

                    lista_ItensTelefoneCliente.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vazio: \n {ex.ToString()}");
            }
            finally { con.Close(); }

            return lista_ItensTelefoneCliente;
        }
    }
}
