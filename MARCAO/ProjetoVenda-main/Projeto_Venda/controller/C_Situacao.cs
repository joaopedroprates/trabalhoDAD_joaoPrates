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
    internal class C_Situacao : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable situacaos;

        string sqlApagar = "delete from situacao where cod = @Cod";
        string sqlInsere = "insert into situacao (nome) values (@Nome)";
        string sqlEditar = "update situacao set nome = @Nome where cod = @Cod";
        string sqlTodos = "select * from situacao order by nome";

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
            Situacao situacao = new Situacao();
            situacao = (Situacao)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", situacao.Nome);
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
            Situacao situacao = new Situacao();
            situacao = (Situacao)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", situacao.Cod);
            cmd.Parameters.AddWithValue("@Nome", situacao.Nome);
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
                situacaos = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(situacaos);
            }
            catch
            {
                situacaos = null;
            }
            return situacaos;
        }
        public List<Situacao> carregaDados()
        {
            List<Situacao> lista_Situacao = new List<Situacao>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabSituacao; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabSituacao = cmd.ExecuteReader();
                while (tabSituacao.Read())
                {
                    Situacao aux = new Situacao();
                    aux.Cod = Int32.Parse(tabSituacao["cod"].ToString());
                    aux.Nome = tabSituacao["nome"].ToString();
                    lista_Situacao.Add(aux);
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
            return lista_Situacao;
        }
    }
}
