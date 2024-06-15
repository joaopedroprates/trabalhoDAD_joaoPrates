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
    internal class C_Telefone
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable telefones;

        string sqlApagar = "delete from telefone where cod = @Cod";
        string sqlInsere = @"insert into telefone(numero, codoperadora_fk) 
values (@Numero, @Operadora)";
        string sqlEditar = @"UPDATE telefone
       SET Numero = @Numero
      ,Codoperadora_fk = @Operadora
       WHERE Cod = @Cod;";
        string sqlTodos = @"SELECT 
    t.Cod,
    t.Numero,
    op.Nome AS Operadora
FROM TELEFONE t
INNER JOIN OPERADORA op ON t.CODOPERADORA_FK = op.Cod";

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
                    MessageBox.Show("Telefone deletada com Sucesso!!!\n" +
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
            Telefone telefone = new Telefone();
            telefone = (Telefone)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);

            cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
            cmd.Parameters.AddWithValue("@Operadora", telefone.Operadora.Cod);
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
        public void editaDados(object obj)
        {
            Telefone telefone = new Telefone();
            telefone = (Telefone)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            try
            {
                cmd.Parameters.AddWithValue("@Cod", telefone.Cod);
                cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
                cmd.Parameters.AddWithValue("@Operadora", telefone.Operadora.Cod);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Registro editado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                telefones = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(telefones);
            }
            catch
            {
                telefones = null;
            }
            return telefones;
        }

        public List<Telefone> carregaDados()
        {
            List<Telefone> lista_telefone = new List<Telefone>();

            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);

            cmd.CommandType = CommandType.Text;

            SqlDataReader tabTelefone; //Representa uma Tabela Virtual para a leitura de dados
            con.Open();


            try
            {
                tabTelefone = cmd.ExecuteReader();
                while (tabTelefone.Read())
                {
                    Telefone aux = new Telefone();

                    aux.Cod = Int32.Parse(tabTelefone["cod"].ToString());
                    aux.Numero = tabTelefone["numero"].ToString();

                    lista_telefone.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vazio: \n {ex.ToString()}");
            }
            finally { con.Close(); }

            return lista_telefone;
        }
    }
}
