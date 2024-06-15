using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.controller;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.view
{
    public partial class frmLogins : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable loginss;
        bool novo = false;
        List<Funcionario> auxFuncionario = new List<Funcionario>();
        int posicaoFuncionario = 0;
        //funções
        public void carregaFuncionario()
        {
            C_Funcionario cs = new C_Funcionario();
            auxFuncionario = new List<Funcionario>();
            auxFuncionario = cs.carregaDados();
            cbFuncionario.DataSource = auxFuncionario;
            cbFuncionario.DisplayMember = "nome";
            cbFuncionario.ValueMember = "cod";
        }
        public void carregarTabela()
        {
            C_Logins cc = new C_Logins();
            loginss = cc.buscarTodos();
            dataGridView1.DataSource = loginss;
        }
        //Carrega as informações no DatagridView1 com os dados das loginss
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            if (index > -1)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtSenha.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    cbFuncionario.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    
                    tsbNovo.Enabled = false;
                    tsbCancelar.Enabled = true;
                    tsbSalvar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    cbFuncionario.Enabled = true;
                    txtSenha.Enabled = true;

                    novo = false;
                    txtNome.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Construtor da Classe frmLogins
        public frmLogins()
        {
            InitializeComponent();
            carregarTabela();
            carregaFuncionario();
            txtNome.Focus();
            txtNome.Enabled = false;
            cbFuncionario.Enabled = false;
            txtSenha.Enabled = false;

            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        //Botões
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            cbFuncionario.Enabled = true;
            txtSenha.Enabled = true;

            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            txtId.Clear();
            txtNome.Focus();
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (novo)
                {
                    Logins logins = new Logins
                    {
                        Nome = txtNome.Text,
                        Senha = txtSenha.Text,
                        Funcionario = auxFuncionario[posicaoFuncionario]                      
                    };
                    C_Logins cc = new C_Logins();
                    cc.insereDados(logins);
                }
                else
                {
                    Logins logins = new Logins
                    {
                        Cod = Int32.Parse(txtId.Text),
                        Nome = txtNome.Text,
                        Senha = txtSenha.Text,
                        Funcionario = auxFuncionario[posicaoFuncionario]
                    };
                    C_Logins c_logins = new C_Logins();
                    c_logins.editaDados(logins);
                }
                carregarTabela();
                txtNome.Enabled = false;
                cbFuncionario.Enabled = false;
                txtSenha.Enabled = false;

                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;

                txtNome.Clear();
                txtId.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar!!!\n\nErro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                C_Logins cc = new C_Logins();
                cc.apagaDados(Int32.Parse(txtId.Text));
                carregarTabela();
                txtNome.Enabled = false;
                cbFuncionario.Enabled = false;
                txtSenha.Enabled = false;

                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;

                txtNome.Clear();
                txtId.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            cbFuncionario.Enabled = false;
            txtSenha.Enabled = false;

            txtNome.Clear();
            txtId.Clear();
            txtSenha.Clear();
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscar = @"SELECT 
    l.Cod,
    l.Nome,
    l.Senha,
    funcionario.NOME AS Funcionario
FROM LOGINS l
INNER JOIN FUNCIONARIO funcionario ON l.CODFUNCIONARIO_FK = funcionario.COD
WHERE l.nome LIKE @Nome;";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscar, con);
                cmd.Parameters.AddWithValue("@Nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;
                con.Open();
                da = new SqlDataAdapter(cmd);
                loginss = new DataTable();
                da.Fill(loginss);
                dataGridView1.DataSource = loginss;
                SqlDataReader tablogins = cmd.ExecuteReader();
                if (tablogins.Read())
                {
                    txtId.Text = tablogins["Cod"].ToString();
                    txtNome.Text = tablogins["Nome"].ToString();
                    txtSenha.Text = tablogins["Senha"].ToString();
                    cbFuncionario.Text = tablogins["Funcionario"].ToString();
                   
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    cbFuncionario.Enabled = true;
                    txtSenha.Enabled = true;

                    txtNome.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Logins não encontrada!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            txtBuscar.Text = string.Empty;
        }
        //Relatorio
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //rltLogins frm = new rltLogins(loginss);
            //frm.ShowDialog();
        }
        //ComboBox
        private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoFuncionario = cbFuncionario.SelectedIndex;
        }
    }

}
