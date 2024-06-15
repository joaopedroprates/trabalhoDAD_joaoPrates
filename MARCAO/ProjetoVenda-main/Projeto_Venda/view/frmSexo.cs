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
    public partial class frmSexo : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        DataTable sexos;
        bool novo = false;
        //funções
        public void carregarTabela()
        {
            C_Sexo cc = new C_Sexo();
            DataTable aux = new DataTable();
            aux = cc.buscarTodos();
            sexos = aux;
            dataGridView1.DataSource = aux;
        }
        //
        public frmSexo()
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
                Sexo sexo = new Sexo
                {
                    Nome = txtNome.Text
                };
                C_Sexo cc = new C_Sexo();
                cc.insereDados(sexo);
            }
            else
            {
                Sexo sexo = new Sexo();
                sexo.Cod = Int32.Parse(txtId.Text);
                sexo.Nome = txtNome.Text;

                C_Sexo c_sexo = new C_Sexo();
                c_sexo.editaDados(sexo);
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
            C_Sexo cc = new C_Sexo();
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
            //rltSexo frm = new rltSexo(sexos);
            //frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscarId = "select * from sexo where nome LIKE @nome order by nome";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscarId, con);

                //Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;

                SqlDataReader tabsexo;
                con.Open();
                //*******carregando datagrid ***************************************8
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                sexos = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(sexos);
                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = sexos;
                //*******************fim do carregamento do datagrid
                tabsexo = cmd.ExecuteReader();
                if (tabsexo.Read())
                {
                    txtId.Text = tabsexo["Cod"].ToString();
                    txtNome.Text = tabsexo["Nome"].ToString();
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
                    MessageBox.Show("sexo não Encontrado!");
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
    }
}
