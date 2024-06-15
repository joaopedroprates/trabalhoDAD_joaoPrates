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
    internal class C_Logins : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable loginss;
        string sqlApagar = "DELETE FROM logins WHERE cod = @Cod";
        string sqlInsere = @"insert into logins(NOME, SENHA, CODFUNCIONARIO_FK) 
        values (@Nome, @Senha, @Codfuncionario_fk)";
        string sqlEditar = @"UPDATE LOGINS
   SET NOME = @Nome
      ,SENHA = @Senha
      ,CODFUNCIONARIO_FK = @Codfuncionario_fk
       WHERE COD = @Cod;";
        string sqlTodos = @"SELECT 
    l.Cod,
    l.Nome,
    l.Senha,
    funcionario.NOME AS Funcionario
FROM LOGINS l
INNER JOIN FUNCIONARIO funcionario ON 
l.CODFUNCIONARIO_FK = funcionario.COD;";
        public void apagaDados(int cod)
        {
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlApagar, con);
            try
            {
                //Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@Cod", cod);
                cmd.CommandType = CommandType.Text;
                con.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Logins deletada com Sucesso!!!\n" +
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
            Logins logins = new Logins();
            logins = (Logins)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            try
            {
                cmd.Parameters.AddWithValue("@Nome", logins.Nome);
                cmd.Parameters.AddWithValue("@Senha", logins.Senha);
                cmd.Parameters.AddWithValue("@Codfuncionario_fk", logins.Funcionario.Cod);
                cmd.CommandType = CommandType.Text;
                con.Open();
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
            Logins logins = new Logins();
            logins = (Logins)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            try
            {
                cmd.Parameters.AddWithValue("@Cod", logins.Cod);
                cmd.Parameters.AddWithValue("@Nome", logins.Nome);
                cmd.Parameters.AddWithValue("@Senha", logins.Senha);
                cmd.Parameters.AddWithValue("@Codfuncionario_fk", logins.Funcionario.Cod);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registro editado com sucesso");
                }
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
            cmd = new SqlCommand(sqlTodos, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            try
            {
                da = new SqlDataAdapter(cmd);
                loginss = new DataTable();
                da.Fill(loginss);
            }
            catch
            {
                loginss = null;
            }
            return loginss;
        }
        public List<Logins> carregaDados()
        {
            List<Logins> lista_logins = new List<Logins>();
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader tabLogins;
            con.Open();
            try
            {
                tabLogins = cmd.ExecuteReader();
                while (tabLogins.Read())
                {
                    Logins aux = new Logins();
                    aux.Cod = Int32.Parse(tabLogins["cod"].ToString());
                    aux.Nome = tabLogins["nome"].ToString();
                    lista_logins.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vazio: \n {ex.ToString()}");
            }
            finally
            {
                con.Close();
            }
            return lista_logins;
        }
    }
}
