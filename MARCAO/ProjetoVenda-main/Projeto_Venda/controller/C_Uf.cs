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
    internal class C_Uf : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable ufs;

        string sqlApagar = "delete from uf where cod = @Id";
        string sqlInsere = "insert into uf (nome, sigla) values (@Nome, @Sigla)";
        string sqlEditar = "update uf set nome = @Nome where cod = @Cod";
        string sqlTodos = "select * from uf order by nome";



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
            Uf uf = new Uf();
            uf = (Uf)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", uf.Nome);
            cmd.Parameters.AddWithValue("@Sigla", uf.Sigla);
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
            Uf uf = new Uf();
            uf = (Uf)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", uf.Cod);
            cmd.Parameters.AddWithValue("@Nome", uf.Nome);
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
                ufs = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(ufs);
            }
            catch
            {
                ufs = null;
            }
            return ufs;
        }
        public List<Uf> carregaDados()
        {
            List<Uf> lista_Uf = new List<Uf>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabUf; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabUf = cmd.ExecuteReader();
                while (tabUf.Read())
                {
                    Uf aux = new Uf();
                    aux.Cod = Int32.Parse(tabUf["cod"].ToString());
                    aux.Nome = tabUf["nome"].ToString();
                    aux.Sigla = tabUf["sigla"].ToString();
                    lista_Uf.Add(aux);
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
            return lista_Uf;
        }
    }
}
