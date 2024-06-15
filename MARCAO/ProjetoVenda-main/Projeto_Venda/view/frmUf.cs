using Projeto_Venda_caua_joao.conexao;
using Projeto_Venda_caua_joao.controller;
using Projeto_Venda_caua_joao.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Venda_caua_joao.view
{
    public partial class frmUf : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        DataTable ufs;
        bool novo = false;
        //funções
        public void carregarTabela()
        {
            C_Uf cc = new C_Uf();
            DataTable aux = new DataTable();
            aux = cc.buscarTodos();
            ufs = aux;
            dataGridView1.DataSource = aux;
        }
        //
        public frmUf()
        {
            InitializeComponent();
            carregarTabela();
            txtNome.Focus();
            txtNome.Enabled = false;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
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
                Uf uf = new Uf
                {
                    Nome = txtNome.Text,
                    Sigla = txtSigla.Text
                };
                C_Uf cc = new C_Uf();
                cc.insereDados(uf);
            }
            else
            {
                Uf uf = new Uf();
                uf.Cod = Int32.Parse(txtId.Text);
                uf.Nome = txtNome.Text;
                uf.Sigla = txtSigla.Text;

                C_Uf c_uf = new C_Uf();
                c_uf.editaDados(uf);
            }
            carregarTabela();
            txtNome.Enabled = false;
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
            txtNome.Clear();
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            C_Uf cc = new C_Uf();
            cc.apagaDados(int.Parse(txtId.Text));
            carregarTabela();
            txtNome.Enabled = false;
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
            txtSigla.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tsbNovo.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbSalvar.Enabled = true;
            tsbExcluir.Enabled = true;
            txtNome.Enabled = true;
            novo = false;
            txtNome.Focus();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //rltUf frm = new rltUf(ufs);
            //frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscarId = "select * from uf where nome LIKE @nome order by nome";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscarId, con);

                //Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;

                SqlDataReader tabuf;
                con.Open();
                //*******carregando datagrid ***************************************8
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                ufs = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(ufs);
                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = ufs;
                //*******************fim do carregamento do datagrid
                tabuf = cmd.ExecuteReader();
                if (tabuf.Read())
                {
                    txtId.Text = tabuf["Cod"].ToString();
                    txtNome.Text = tabuf["Nome"].ToString();
                    txtSigla.Text = tabuf["Sigla"].ToString();
                    //ativar controle dos botões
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    txtNome.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("uf não Encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Buscar!!!");
            }

            finally
            {
                con.Close();
            }
            txtBuscar.Text = string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUf_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
