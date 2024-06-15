using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.controller;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao.view
{
    public partial class frmFuncionario : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable funcionarios;
        bool novo = false;
        List<Rua> auxRua = new List<Rua>();
        List<Bairro> auxBairro = new List<Bairro>();
        List<Cep> auxCep = new List<Cep>();
        List<Cidade> auxCidade = new List<Cidade>();
        List<Funcao> auxFuncao = new List<Funcao>();
        List<Loja> auxLoja = new List<Loja>();
        int posicaoFuncao = 0;
        int posicaoRua = 0;
        int posicaoBairro = 0;
        int posicaoCep = 0;
        int posicaoCidade = 0;
        int posicaoLoja = 0;
        //funções
        public void carregaRua()
        {
            C_Rua cs = new C_Rua();
            auxRua = new List<Rua>();
            auxRua = cs.carregaDados();
            cbRua.DataSource = auxRua;
            cbRua.DisplayMember = "nome";
            cbRua.ValueMember = "cod";
        }
        public void carregaBairro()
        {
            C_Bairro cs = new C_Bairro();
            auxBairro = new List<Bairro>();
            auxBairro = cs.carregaDados();
            cbBairro.DataSource = auxBairro;
            cbBairro.DisplayMember = "nome";
            cbBairro.ValueMember = "cod";
        }
        public void carregaCep()
        {
            C_Cep cs = new C_Cep();
            auxCep = new List<Cep>();
            auxCep = cs.carregaDados();
            cbCep.DataSource = auxCep;
            cbCep.DisplayMember = "numero";
            cbCep.ValueMember = "cod";
        }
        public void carregaCidade()
        {
            C_Cidade cs = new C_Cidade();
            auxCidade = new List<Cidade>();
            auxCidade = cs.carregaDados();
            cbCidade.DataSource = auxCidade;
            cbCidade.DisplayMember = "nome";
            cbCidade.ValueMember = "cod";
        }
        public void carregaFuncao()
        {
            C_Funcao cs = new C_Funcao();
            auxFuncao = new List<Funcao>();
            auxFuncao = cs.carregaDados();
            cbFuncao.DataSource = auxFuncao;
            cbFuncao.DisplayMember = "nome";
            cbFuncao.ValueMember = "cod";
        }
        public void carregaLoja()
        {
            C_Loja cs = new C_Loja();
            auxLoja = new List<Loja>();
            auxLoja = cs.carregaDados();
            cbLoja.DataSource = auxLoja;
            cbLoja.DisplayMember = "nome";
            cbLoja.ValueMember = "cod";
        }
        public void carregarTabela()
        {
            C_Funcionario cc = new C_Funcionario();
            funcionarios = cc.buscarTodos();
            dataGridView1.DataSource = funcionarios;
        }
        //Carrega as informações no DatagridView1 com os dados das funcionarios
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
                    txtNumerocasa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    cbRua.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    cbBairro.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    cbCep.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    cbCidade.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    cbFuncao.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    txtSalario.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    cbLoja.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                    tsbNovo.Enabled = false;
                    tsbCancelar.Enabled = true;
                    tsbSalvar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    cbFuncao.Enabled = true;
                    cbRua.Enabled = true;
                    cbBairro.Enabled = true;
                    cbCep.Enabled = true;
                    cbCidade.Enabled = true;
                    cbLoja.Enabled = true;
                    txtSalario.Enabled = true;
                    txtNumerocasa.Enabled = true;

                    novo = false;
                    txtNome.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Construtor da Classe frmFuncionario
        public frmFuncionario()
        {
            InitializeComponent();
            carregarTabela();
            carregaRua();
            carregaBairro();
            carregaCep();
            carregaCidade();
            carregaFuncao();
            carregaLoja();
            txtNome.Focus();
            txtNome.Enabled = false;
            cbFuncao.Enabled = false;
            cbRua.Enabled = false;
            cbBairro.Enabled = false;
            cbCep.Enabled = false;
            cbCidade.Enabled = false;
            cbLoja.Enabled = false;
            txtSalario.Enabled = false;
            txtNumerocasa.Enabled = false;

            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        //Botões
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            cbFuncao.Enabled = true;
            cbRua.Enabled = true;
            cbBairro.Enabled = true;
            cbCep.Enabled = true;
            cbCidade.Enabled = true;
            cbLoja.Enabled = true;
            txtSalario.Enabled = true;
            txtNumerocasa.Enabled = true;

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
                    Funcionario funcionario = new Funcionario
                    {
                        Nome = txtNome.Text,
                        Numerocasa = txtNumerocasa.Text,
                        Rua = auxRua[posicaoRua],
                        Bairro = auxBairro[posicaoBairro],
                        Cep = auxCep[posicaoCep],
                        Cidade = auxCidade[posicaoCidade],
                        Funcao = auxFuncao[posicaoFuncao],
                        Salario = Double.Parse(txtSalario.Text),
                        Loja = auxLoja[posicaoLoja]
                    };
                    C_Funcionario cc = new C_Funcionario();
                    cc.insereDados(funcionario);
                }
                else
                {
                        Funcionario funcionario = new Funcionario
                        {
                            Cod = Int32.Parse(txtId.Text),
                            Nome = txtNome.Text,
                            Numerocasa = txtNumerocasa.Text,
                            Rua = auxRua[posicaoRua],
                            Bairro = auxBairro[posicaoBairro],
                            Cep = auxCep[posicaoCep],
                            Cidade = auxCidade[posicaoCidade],
                            Funcao = auxFuncao[posicaoFuncao],
                            Salario = Double.Parse(txtSalario.Text),
                            Loja = auxLoja[posicaoLoja]
                        };
                        C_Funcionario c_funcionario = new C_Funcionario();
                        c_funcionario.editaDados(funcionario);
                }
                carregarTabela();
                txtNome.Enabled = false;
                cbFuncao.Enabled = false;
                cbRua.Enabled = false;
                cbBairro.Enabled = false;
                cbCep.Enabled = false;
                cbCidade.Enabled = false;
                cbLoja.Enabled = false;
                txtSalario.Enabled = false;
                txtNumerocasa.Enabled = false;

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
                C_Funcionario cc = new C_Funcionario();
                cc.apagaDados(Int32.Parse(txtId.Text));
                carregarTabela();
                txtNome.Enabled = false;
                cbFuncao.Enabled = false;
                cbRua.Enabled = false;
                cbBairro.Enabled = false;
                cbCep.Enabled = false;
                cbCidade.Enabled = false;
                cbLoja.Enabled = false;
                txtSalario.Enabled = false;
                txtNumerocasa.Enabled = false;

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
            cbFuncao.Enabled = false;
            cbRua.Enabled = false;
            cbBairro.Enabled = false;
            cbCep.Enabled = false;
            cbCidade.Enabled = false;
            cbLoja.Enabled = false;
            txtSalario.Enabled = false;
            txtNumerocasa.Enabled = false;

            txtNome.Clear();
            txtId.Clear();
            txtNumerocasa.Clear();
            txtSalario.Clear();
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
INNER JOIN LOJA loja ON f.CODLOJA_FK = loja.COD
WHERE f.nome LIKE @Nome;";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscar, con);
                cmd.Parameters.AddWithValue("@Nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;
                con.Open();
                da = new SqlDataAdapter(cmd);
                funcionarios = new DataTable();
                da.Fill(funcionarios);
                dataGridView1.DataSource = funcionarios;
                SqlDataReader tabfuncionario = cmd.ExecuteReader();
                if (tabfuncionario.Read())
                {
                    txtId.Text = tabfuncionario["Cod"].ToString();
                    txtNome.Text = tabfuncionario["Nome"].ToString();
                    txtNumerocasa.Text = tabfuncionario["Numerocasa"].ToString();
                    cbRua.Text = tabfuncionario["Rua"].ToString();
                    cbBairro.Text = tabfuncionario["Bairro"].ToString();
                    cbCep.Text = tabfuncionario["Cep"].ToString();
                    cbCidade.Text = tabfuncionario["Cidade"].ToString();
                    cbFuncao.Text = tabfuncionario["Funcao"].ToString();
                    txtSalario.Text = tabfuncionario["Salario"].ToString();
                    cbLoja.Text = tabfuncionario["Loja"].ToString();

                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    cbFuncao.Enabled = true;
                    cbRua.Enabled = true;
                    cbBairro.Enabled = true;
                    cbCep.Enabled = true;
                    cbCidade.Enabled = true;
                    cbLoja.Enabled = true;
                    txtSalario.Enabled = true;
                    txtNumerocasa.Enabled = true;

                    txtNome.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Funcionario não encontrada!");
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
            //rltFuncionario frm = new rltFuncionario(funcionarios);
            //frm.ShowDialog();
        }
        //ComboBox
        private void cbFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoFuncao = cbFuncao.SelectedIndex;
        }
        private void cbRua_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoRua = cbRua.SelectedIndex;
        }
        private void cbBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoBairro = cbBairro.SelectedIndex;
        }
        private void cbCep_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoCep = cbCep.SelectedIndex;
        }
        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoCidade = cbCidade.SelectedIndex;
        }
        private void cbLoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoLoja = cbLoja.SelectedIndex;
        }
    }

}
