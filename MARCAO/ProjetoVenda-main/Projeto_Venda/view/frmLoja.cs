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
    public partial class frmLoja : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        DataTable lojas;
        bool novo = false;
        //funções
        public void carregarTabela()
        {
            C_Loja cc = new C_Loja();
            DataTable aux = new DataTable();
            aux = cc.buscarTodos();
            lojas = aux;
            dataGridView1.DataSource = aux;
        }
        //
        public frmLoja()
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
                Loja loja = new Loja
                {
                    Nome = txtNome.Text,
                    CNPJ =textBox2.Text,
                    NomeFantasia = textBox3.Text,
                    RazaoSocial = textBox4.Text
                };
                C_Loja cc = new C_Loja();
                cc.insereDados(loja);
            }
            else
            {
                Loja loja = new Loja();
                loja.Cod = Int32.Parse(txtId.Text);
                loja.Nome = txtNome.Text;
                loja.CNPJ = textBox2.Text;
                loja.NomeFantasia = textBox3.Text;
                loja.RazaoSocial = textBox4.Text;

                C_Loja c_loja = new C_Loja();
                c_loja.editaDados(loja);
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
            C_Loja cc = new C_Loja();
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
            //rltLoja frm = new rltLoja(lojas);
            //frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscarId = "select * from loja where nome LIKE @nome order by nome";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscarId, con);

                //Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;

                SqlDataReader tabloja;
                con.Open();
                //*******carregando datagrid ***************************************8
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                lojas = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(lojas);
                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = lojas;
                //*******************fim do carregamento do datagrid
                tabloja = cmd.ExecuteReader();
                if (tabloja.Read())
                {
                    txtId.Text = tabloja["Cod"].ToString();
                    txtNome.Text = tabloja["Nome"].ToString();
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
                    MessageBox.Show("loja não Encontrado!");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
