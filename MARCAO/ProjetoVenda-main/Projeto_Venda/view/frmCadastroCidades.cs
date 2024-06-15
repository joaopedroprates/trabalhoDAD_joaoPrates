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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Venda_caua_joao.view
{
    public partial class frmCadastroCidades : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        List<Uf> aux = new List<Uf>();
        DataTable cidades;
        bool novo = false;
        int posicao = 0;
        //funções
        //Carrega as informações no DatagridView1 com os dados das cidades
        public void carregarTabela()
        {
            C_Cidade cc = new C_Cidade();
            cidades = cc.buscarTodos();
            dataGridView1.DataSource = cidades;
        }
        public void carregaUf()
        {
            C_Uf cs = new C_Uf();
            aux = new List<Uf>();
            aux = cs.carregaDados();
            comboBox1.DataSource = aux;
            comboBox1.DisplayMember = "sigla";
            comboBox1.ValueMember = "cod";
        }
        //Construtor da Classe frmCadastroCliente
        public frmCadastroCidades()
        {
            InitializeComponent();
            carregarTabela();
            carregaUf();
            txtNome.Focus();
            txtNome.Enabled = false;
            comboBox1.Enabled = false;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicao = comboBox1.SelectedIndex;
        }
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            comboBox1.Enabled = true;
            txtId.Text = "";
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            txtNome.Focus();
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                Cidade cidade = new Cidade
                {
                    Nome = txtNome.Text,
                    Uf = aux[posicao]
                };
                C_Cidade cc = new C_Cidade();
                cc.insereDados(cidade);
            }
            else
            {
                Cidade cidade = new Cidade
                {
                    Cod = Int32.Parse(txtId.Text),
                    Nome = txtNome.Text,
                    Uf = aux[posicao]
                };
                C_Cidade c_cidade = new C_Cidade();
                c_cidade.editaDados(cidade);
            }
            carregarTabela();
            txtNome.Enabled = false;
            comboBox1.Enabled = false;
            txtNome.Clear();
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            C_Cidade cc = new C_Cidade();
            cc.apagaDados(Int32.Parse(txtId.Text));
            carregarTabela();
            txtNome.Enabled = false;
            comboBox1.Enabled = false;
            txtNome.Clear();
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            comboBox1.Enabled = false;
            txtNome.Clear();
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            txtId.Text = selectedRow.Cells[0].Value.ToString();
            //txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            tsbNovo.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbSalvar.Enabled = true;
            tsbExcluir.Enabled = true;
            txtNome.Enabled = true;
            comboBox1.Enabled = true;
            novo = false;
            txtNome.Focus();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscar = "SELECT cidade.COD AS Cod, cidade.NOME AS Nome, UF.SIGLA AS Uf" +
                                    " FROM cidade" +
                                    " INNER JOIN UF ON cidade.coduf_fk = UF.COD" +
                                    " WHERE cidade.nome LIKE @nome";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscar, con);
                // Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;
                con.Open();
                //*******carregando datagrid ***************************************8
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
               cidades = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(cidades);

               
                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = cidades;
                //*******************fim do carregamento do datagrid
                // Executar a leitura dos dados da cidade
                SqlDataReader tabcidade = cmd.ExecuteReader();

                if (tabcidade.Read())
                {
                    txtId.Text = tabcidade["Cod"].ToString();
                    txtNome.Text = tabcidade["Nome"].ToString();
                    comboBox1.Text = tabcidade["Uf"].ToString();

                    // Ativar controle dos botões
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    comboBox1.Enabled = true;
                    txtNome.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Cidade não encontrada!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Certifique-se de fechar a conexão depois de utilizar
                con.Close();
            }
            txtBuscar.Text = string.Empty;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //DataTable rlt = cidades;
            //FrmPrincipal frm = new FrmPrincipal(rlt);
            rltCadastroCidade frm = new rltCadastroCidade(cidades);
            frm.ShowDialog();
        }
    }
}
