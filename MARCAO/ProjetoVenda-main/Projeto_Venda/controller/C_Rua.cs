using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.controller
{
    internal class C_Rua : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable ruas;

        string sqlApagar = "delete from rua where cod = @Cod";
        string sqlInsere = "insert into rua (nome) values (@Nome)";
        string sqlEditar = "update rua set nome = @Nome where cod = @Cod";
        string sqlTodos = "select * from rua order by nome";

        public void apagaDados(int cod)
        {
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlApagar, con);
            //Passando parâmetros para a sentença SQL
            cmd.Parameters.AddWithValue("@Cod", cod);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show($"Deletado com sucesso!!!\n Código: {cod}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao apagar!!!\n Erro: {ex.ToString()}");
            }
            finally
            {
                con.Close();
            }
        }
        public void insereDados(object obj)
        {
            Rua rua = new Rua();
            rua = (Rua)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", rua.Nome);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Registro incluído com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }
        public void editaDados(object obj)
        {
            Rua rua = new Rua();
            rua = (Rua)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", rua.Cod);
            cmd.Parameters.AddWithValue("@Nome", rua.Nome);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Registro editado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable buscarTodos()
        {

            ConectaBanco conectaBanco = new ConectaBanco();
            con = conectaBanco.conectaSqlServer();



            //cria o objeto command para executar a instruçao sql
            cmd = new SqlCommand(sqlTodos, con);
            //abre a conexao
            con.Open();
            //define o tipo do comando
            cmd.CommandType = CommandType.Text;
            try
            {
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                ruas = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(ruas);
            }
            catch
            {
                ruas = null;
            }
            return ruas;
        }
        public List<Rua> carregaDados()
        {
            List<Rua> lista_Rua = new List<Rua>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabRua; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabRua = cmd.ExecuteReader();
                while (tabRua.Read())
                {
                    Rua aux = new Rua();
                    aux.Cod = Int32.Parse(tabRua["cod"].ToString());
                    aux.Nome = tabRua["nome"].ToString();
                    lista_Rua.Add(aux);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados!\nErro:" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return lista_Rua;
        }
    }
}
