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
    internal class C_Funcionario : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable funcionarios;
        string sqlApagar = "DELETE FROM funcionario WHERE cod = @Cod";
        string sqlInsere = @"insert into funcionario(NOME, NUMEROCASA, CODRUA_FK, CODBAIRRO_FK, CODCEP_FK, CODCIDADE_FK, CODFUNCAO_FK, SALARIO, CODLOJA_FK) 
        values (@Nome, @Numerocasa, @Codrua_fk, @Codbairro_fk, @Codcep_fk, @Codcidade_fk, @Codfuncao_fk, @Salario, @Codloja_fk)";
        string sqlEditar = @"UPDATE FUNCIONARIO
   SET NOME = @Nome
      ,NUMEROCASA = @Numerocasa
      ,CODRUA_FK = @Codrua_fk
      ,CODBAIRRO_FK = @Codbairro_fk
      ,CODCEP_FK = @CodCep_fk
      ,CODCIDADE_FK = @CodCidade_fk
      ,CODFUNCAO_FK = @Codfuncao_fk
      ,SALARIO = @Salario
      ,CODLOJA_FK = @Codloja_fk
       WHERE COD = @Cod;";
        string sqlTodos = @"SELECT 
    f.COD,
    f.Nome,
    f.Numerocasa,
    rua.NOME AS Rua,
    bairro.NOME AS Bairro,
    cep.NUMERO AS CEP,
    cidade.NOME AS Cidade,
    funcao.NOME AS Funcao,
    f.Salario,
    loja.NOME AS Loja
FROM FUNCIONARIO f
INNER JOIN RUA rua ON f.CODRUA_FK = rua.COD
INNER JOIN BAIRRO bairro ON f.CODBAIRRO_FK = bairro.COD
INNER JOIN CEP cep ON f.CODCEP_FK = cep.COD
INNER JOIN CIDADE cidade ON f.CODCIDADE_FK = cidade.COD
INNER JOIN FUNCAO funcao ON f.CODFUNCAO_FK = funcao.COD
INNER JOIN LOJA loja ON f.CODLOJA_FK = loja.COD;";
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
                    MessageBox.Show("Funcionario deletada com Sucesso!!!\n" +
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
            Funcionario funcionario = new Funcionario();
            funcionario = (Funcionario)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            try
            {
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Numerocasa", funcionario.Numerocasa);
                cmd.Parameters.AddWithValue("@Codrua_fk", funcionario.Rua.Cod);
                cmd.Parameters.AddWithValue("@Codbairro_fk", funcionario.Bairro.Cod);
                cmd.Parameters.AddWithValue("@CodCep_fk", funcionario.Cep.Cod);
                cmd.Parameters.AddWithValue("@CodCidade_fk", funcionario.Cidade.Cod);
                cmd.Parameters.AddWithValue("@CodFuncao_fk", funcionario.Funcao.Cod);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@CodLoja_fk", funcionario.Loja.Cod);
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
            Funcionario funcionario = new Funcionario();
            funcionario = (Funcionario)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            try
            {
                cmd.Parameters.AddWithValue("@Cod", funcionario.Cod);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Numerocasa", funcionario.Numerocasa);
                cmd.Parameters.AddWithValue("@Codrua_fk", funcionario.Rua.Cod);
                cmd.Parameters.AddWithValue("@Codbairro_fk", funcionario.Bairro.Cod);
                cmd.Parameters.AddWithValue("@CodCep_fk", funcionario.Cep.Cod);
                cmd.Parameters.AddWithValue("@CodCidade_fk", funcionario.Cidade.Cod);
                cmd.Parameters.AddWithValue("@CodFuncao_fk", funcionario.Funcao.Cod);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@CodLoja_fk", funcionario.Loja.Cod);
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
                funcionarios = new DataTable();
                da.Fill(funcionarios);
            }
            catch
            {
                funcionarios = null;
            }
            return funcionarios;
        }
        public List<Funcionario> carregaDados()
        {
            List<Funcionario> lista_funcionario = new List<Funcionario>();
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader tabFuncionario;
            con.Open();
            try
            {
                tabFuncionario = cmd.ExecuteReader();
                while (tabFuncionario.Read())
                {
                    Funcionario aux = new Funcionario();
                    aux.Cod = Int32.Parse(tabFuncionario["cod"].ToString());
                    aux.Nome = tabFuncionario["nome"].ToString();
                    lista_funcionario.Add(aux);
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
            return lista_funcionario;
        }
    }
}
