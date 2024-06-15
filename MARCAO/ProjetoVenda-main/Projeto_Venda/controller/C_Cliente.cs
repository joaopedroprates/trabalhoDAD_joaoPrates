using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.controller
{
    internal class C_Cliente : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable clientes;

        string sqlApagar = "delete from cliente where cod = @Cod";
        string sqlInsere = @"insert into cliente(nome, foto, datanasc, codsexo_fk, codrua_fk, codbairro_fk, codcep_fk, codcidade_fk, salario, codtrabalho_fk, numerocasa) 
values (@Nome, @Foto, @Datanasc, @Codsexo_fk, @Codrua_fk, @Codbairro_fk, @Codcep_fk, @Codcidade_fk, @Salario, @Codtrabalho_fk, @Numerocasa)";
        string sqlEditar = @"UPDATE CLIENTE
   SET NOME = @Nome
      ,FOTO = @Foto
      ,DATANASC = @Datanasc
      ,CODSEXO_FK = @Codsexo_fk
      ,CODRUA_FK = @Codrua_fk
      ,CODBAIRRO_FK = @Codbairro_fk
      ,CODCEP_FK = @CodCep_fk
      ,CODCIDADE_FK = @CodCidade_fk
      ,SALARIO = @Salario
      ,CODTRABALHO_FK = @CodTrabalho_fk
      ,NUMEROCASA = @Numerocasa
       WHERE COD = @Cod;";
        string sqlEditar2 = @"UPDATE CLIENTE
   SET NOME = @Nome
      ,DATANASC = @Datanasc
      ,CODSEXO_FK = @Codsexo_fk
      ,CODRUA_FK = @Codrua_fk
      ,CODBAIRRO_FK = @Codbairro_fk
      ,CODCEP_FK = @CodCep_fk
      ,CODCIDADE_FK = @CodCidade_fk
      ,SALARIO = @Salario
      ,CODTRABALHO_FK = @CodTrabalho_fk
      ,NUMEROCASA = @Numerocasa
       WHERE COD = @Cod;";
        string sqlTodos = @"SELECT 
    c.COD,
    c.NOME,
    c.FOTO,
    c.DATANASC,
    sx.Nome AS Sexo,
    rua.Nome AS Rua,
    bairro.Nome AS Bairro,
    cep.NUMERO AS CEP,
    cidade.Nome AS Cidade,
    c.Salario,
    trabalho.Nome AS Trabalho,
    c.Numerocasa
FROM CLIENTE c
INNER JOIN SEXO sx ON c.CODSEXO_FK = sx.COD
INNER JOIN RUA rua ON c.CODRUA_FK = rua.COD
INNER JOIN BAIRRO bairro ON c.CODBAIRRO_FK = bairro.COD
INNER JOIN CEP cep ON c.CODCEP_FK = cep.COD
INNER JOIN CIDADE cidade ON c.CODCIDADE_FK = cidade.COD
INNER JOIN TRABALHO trabalho ON c.CODTRABALHO_FK = trabalho.COD;";
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
                    MessageBox.Show("Cliente deletada com Sucesso!!!\n" +
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
            Cliente cliente = new Cliente();
            cliente = (Cliente)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);

            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Foto", cliente.Foto);
            cmd.Parameters.AddWithValue("@Datanasc", cliente.Datanasc);
            cmd.Parameters.AddWithValue("@Codsexo_fk", cliente.Sexo.Cod);
            cmd.Parameters.AddWithValue("@Codrua_fk", cliente.Rua.Cod);
            cmd.Parameters.AddWithValue("@Codbairro_fk", cliente.Bairro.Cod);
            cmd.Parameters.AddWithValue("@CodCep_fk", cliente.Cep.Cod);
            cmd.Parameters.AddWithValue("@CodCidade_fk", cliente.Cidade.Cod);
            cmd.Parameters.AddWithValue("@Salario", cliente.Salario);
            cmd.Parameters.AddWithValue("@CodTrabalho_fk", cliente.Trabalho.Cod);
            cmd.Parameters.AddWithValue("@Numerocasa", cliente.Numerocasa);
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
            Cliente cliente = new Cliente();
            cliente = (Cliente)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            try
            {
                cmd.Parameters.AddWithValue("@Cod", cliente.Cod);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Foto", cliente.Foto);
                cmd.Parameters.AddWithValue("@Datanasc", cliente.Datanasc);
                cmd.Parameters.AddWithValue("@Codsexo_fk", cliente.Sexo.Cod);
                cmd.Parameters.AddWithValue("@Codrua_fk", cliente.Rua.Cod);
                cmd.Parameters.AddWithValue("@Codbairro_fk", cliente.Bairro.Cod);
                cmd.Parameters.AddWithValue("@CodCep_fk", cliente.Cep.Cod);
                cmd.Parameters.AddWithValue("@CodCidade_fk", cliente.Cidade.Cod);
                cmd.Parameters.AddWithValue("@Salario", cliente.Salario);
                cmd.Parameters.AddWithValue("@CodTrabalho_fk", cliente.Trabalho.Cod);
                cmd.Parameters.AddWithValue("@Numerocasa", cliente.Numerocasa);
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
        public void editaDados2(object obj)
        {
            Cliente cliente = new Cliente();
            cliente = (Cliente)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar2, con);
            try
            {
                cmd.Parameters.AddWithValue("@Cod", cliente.Cod);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Datanasc", cliente.Datanasc);
                cmd.Parameters.AddWithValue("@Codsexo_fk", cliente.Sexo.Cod);
                cmd.Parameters.AddWithValue("@Codrua_fk", cliente.Rua.Cod);
                cmd.Parameters.AddWithValue("@Codbairro_fk", cliente.Bairro.Cod);
                cmd.Parameters.AddWithValue("@CodCep_fk", cliente.Cep.Cod);
                cmd.Parameters.AddWithValue("@CodCidade_fk", cliente.Cidade.Cod);
                cmd.Parameters.AddWithValue("@Salario", cliente.Salario);
                cmd.Parameters.AddWithValue("@CodTrabalho_fk", cliente.Trabalho.Cod);
                cmd.Parameters.AddWithValue("@Numerocasa", cliente.Numerocasa);
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
                clientes = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(clientes);
            }
            catch
            {
                clientes = null;
            }
            return clientes;
        }
        public List<Cliente> carregaDados()
        {
            List<Cliente> lista_cliente = new List<Cliente>();

            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);

            cmd.CommandType = CommandType.Text;

            SqlDataReader tabCliente; //Representa uma Tabela Virtual para a leitura de dados
            con.Open();


            try
            {
                tabCliente = cmd.ExecuteReader();
                while (tabCliente.Read())
                {
                    Cliente aux = new Cliente();

                    aux.Cod = Int32.Parse(tabCliente["cod"].ToString());
                    aux.Nome = tabCliente["nome"].ToString();

                    lista_cliente.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vazio: \n {ex.ToString()}");
            }
            finally { con.Close(); }

            return lista_cliente;
        }
    }
}
