using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.controller
{

    
    internal class C_Cidade : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable cidades;

        string sqlApagar = "delete from cidade where cod = @Cod";
        string sqlInsere = "insert into cidade(nome, coduf_fk) values (@Nome, @Cod)";
        string sqlEditar = "update cidade set nome = @Nome, coduf_fk = @Cod where cod = @Cod";
        string sqlTodos = "select c.cod, c.nome," +
                          " u.sigla as uf from cidade c, " +
                          "uf u where c.coduf_fk = u.cod";

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
                    MessageBox.Show("Cidade deletada com Sucesso!!!\n" +
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
            Cidade cidade = new Cidade();
            cidade = (Cidade)obj;

            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);

            cmd.Parameters.AddWithValue("@Nome", cidade.Nome);
            cmd.Parameters.AddWithValue("@Cod", cidade.Uf.Cod);
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
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void editaDados(object obj)
        {
            Cidade cidade = new Cidade();
            cidade = (Cidade)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", cidade.Cod);
            cmd.Parameters.AddWithValue("@Nome", cidade.Nome);
            cmd.Parameters.AddWithValue("@Cod",cidade.Uf.Cod);
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
                cidades = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(cidades);
            }
            catch
            {
                cidades = null;
            }
            return cidades;
        }

        public List<Cidade> carregaDados()
        {
            List<Cidade> lista_cidade = new List<Cidade>();

            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);

            cmd.CommandType = CommandType.Text;

            SqlDataReader tabCidade; //Representa uma Tabela Virtual para a leitura de dados
            con.Open();


            try
            {
                tabCidade = cmd.ExecuteReader();
                while (tabCidade.Read())
                {
                    Cidade aux = new Cidade();

                    aux.Cod = Int32.Parse(tabCidade["cod"].ToString());
                    aux.Nome = tabCidade["nome"].ToString();

                    lista_cidade.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vazio: \n {ex.ToString()}");
            }
            finally { con.Close(); }

            return lista_cidade;
        }
    }
    
}
