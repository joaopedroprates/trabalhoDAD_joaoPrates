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
    public partial class frmTelefone : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable telefones;
        bool novo = false;
        List<Operadora> auxOperadora = new List<Operadora>();
        int posicaoOperadora = 0;
        //funções
        public void carregaOperadora()
        {
            C_Operadora cs = new C_Operadora();
            auxOperadora = new List<Operadora>();
            auxOperadora = cs.carregaDados();
            cbOperadora.DataSource = auxOperadora;
            cbOperadora.DisplayMember = "nome";
            cbOperadora.ValueMember = "cod";
        }
        //Carrega as informações no DatagridView1 com os dados das telefones
        public void carregarTabela()
        {
            C_Telefone cc = new C_Telefone();
            telefones = cc.buscarTodos();
            dataGridView1.DataSource = telefones;
        }
        //Construtor da Classe frmTelefone
        public frmTelefone()
        {
            InitializeComponent();
            carregarTabela();
            carregaOperadora();
            txtNumero.Focus();
            txtNumero.Enabled = false;
            cbOperadora.Enabled = false;
            
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNumero.Enabled = true;
            cbOperadora.Enabled = true;
            
            txtId.Clear();
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            txtNumero.Focus();
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (novo)
                {
                    Telefone telefone = new Telefone
                    {
                        Numero = txtNumero.Text,
                        Operadora = auxOperadora[posicaoOperadora],
                    };
                    C_Telefone cc = new C_Telefone();
                    cc.insereDados(telefone);
                }
                else
                {
                    Telefone telefone = new Telefone
                    {
                        Cod = Int32.Parse(txtId.Text),
                        Numero = txtNumero.Text,
                        Operadora = auxOperadora[posicaoOperadora],
                    };
                    C_Telefone c_telefone = new C_Telefone();
                    c_telefone.editaDados(telefone);
                }
                carregarTabela();
                txtNumero.Enabled = false;
                cbOperadora.Enabled = false;
               
                txtNumero.Clear();
                txtId.Clear();
                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                C_Telefone cc = new C_Telefone();
                cc.apagaDados(Int32.Parse(txtId.Text));
                carregarTabela();
                txtNumero.Enabled = false;
                cbOperadora.Enabled = false;
                
                txtNumero.Clear();
                txtId.Clear();
                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            txtNumero.Enabled = false;
            cbOperadora.Enabled = false;
            
            txtNumero.Clear();
            txtId.Clear();
            
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            if (index > -1)
            {
                try
                {
                    txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtNumero.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    cbOperadora.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    
                    tsbNovo.Enabled = false;
                    tsbCancelar.Enabled = true;
                    tsbSalvar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNumero.Enabled = true;
                    cbOperadora.Enabled = true;

                    novo = false;
                    txtNumero.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBuscar = @"SELECT 
    t.Cod,
    t.Numero,
    op.Nome AS Operadora
FROM TELEFONE t
INNER JOIN OPERADORA op ON t.CODOPERADORA_FK = op.Cod
WHERE t.numero LIKE @Numero;";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscar, con);
                cmd.Parameters.AddWithValue("@Numero", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;
                con.Open();
                da = new SqlDataAdapter(cmd);
                telefones = new DataTable();
                da.Fill(telefones);
                dataGridView1.DataSource = telefones;
                SqlDataReader tabtelefone = cmd.ExecuteReader();

                if (tabtelefone.Read())
                {
                    txtId.Text = tabtelefone["Cod"].ToString();
                    txtNumero.Text = tabtelefone["Numero"].ToString();
                    cbOperadora.Text = tabtelefone["Operadora"].ToString();
                    // Ativar controle dos botões
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNumero.Enabled = true;
                    cbOperadora.Enabled = true;
                    txtNumero.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Telefone não encontrada!");
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
            //rltTelefone frm = new rltTelefone(telefones);
            //frm.ShowDialog();
        }
        //ComboBox
        private void cbOperadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoOperadora = cbOperadora.SelectedIndex;
        }
    }
}
