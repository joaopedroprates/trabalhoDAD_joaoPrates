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
    public partial class frmItensTelefoneCliente : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable ItensTelefoneClientes;
        bool novo = false;
        List<Telefone> auxTelefone = new List<Telefone>();
        List<Cliente> auxCliente = new List<Cliente>();
        int posicaoTelefone = 0;
        int posicaoCliente = 0;
        //funções
        public void carregaTelefone()
        {
            C_Telefone cs = new C_Telefone();
            auxTelefone = new List<Telefone>();
            auxTelefone = cs.carregaDados();
            cbTelefone.DataSource = auxTelefone;
            cbTelefone.DisplayMember = "numero";
            cbTelefone.ValueMember = "cod";
        } 
        public void carregaCliente()
        {
            C_Cliente cs = new C_Cliente();
            auxCliente = new List<Cliente>();
            auxCliente = cs.carregaDados();
            cbCliente.DataSource = auxCliente;
            cbCliente.DisplayMember = "nome";
            cbCliente.ValueMember = "cod";
        }
        //Carrega as informações no DatagridView1 com os dados das ItensTelefoneClientes
        public void carregarTabela()
        {
            C_ItensTelefoneCliente cc = new C_ItensTelefoneCliente();
            ItensTelefoneClientes = cc.buscarTodos();
            dataGridView1.DataSource = ItensTelefoneClientes;
        }
        //Construtor da Classe frmItensTelefoneCliente
        public frmItensTelefoneCliente()
        {
            InitializeComponent();
            carregarTabela();
            carregaTelefone();
            carregaCliente();
            cbTelefone.Focus();
            cbTelefone.Enabled = false;
            cbCliente.Enabled = false;

            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            cbTelefone.Enabled = true;
            cbCliente.Enabled = true;

            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            cbTelefone.Focus();
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (novo)
                {
                    ItensTelefoneCliente telefone = new ItensTelefoneCliente
                    {
                        CodTelefone = auxTelefone[posicaoTelefone],
                        CodCliente = auxCliente[posicaoCliente],
                    };
                    C_ItensTelefoneCliente cc = new C_ItensTelefoneCliente();
                    cc.insereDados(telefone);
                }
                //else
                //{
                //    ItensTelefoneCliente telefone = new ItensTelefoneCliente
                //    {
                //        Cod = Int32.Parse(txtId.Text),
                //        Numero = cbTelefone.Text,
                //        Telefone = auxTelefone[posicaoTelefone],
                //    };
                //    C_ItensTelefoneCliente c_telefone = new C_ItensTelefoneCliente();
                //    c_telefone.editaDados(telefone);
                //}
                carregarTabela();
                cbTelefone.Enabled = false;
                cbCliente.Enabled = false;
                
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
                C_ItensTelefoneCliente cc = new C_ItensTelefoneCliente();
                cc.apagaDados(posicaoTelefone, posicaoCliente);
                carregarTabela();
                cbTelefone.Enabled = false;
                cbCliente.Enabled = false;

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
            cbTelefone.Enabled = false;
            cbCliente.Enabled = false;

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
                    cbTelefone.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    cbCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    tsbNovo.Enabled = false;
                    tsbCancelar.Enabled = true;
                    tsbSalvar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    cbTelefone.Enabled = true;
                    cbCliente.Enabled = true;

                    novo = false;
                    cbTelefone.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
//        private void btnBuscar_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string sqlBuscar = @"SELECT 
//    t.Cod,
//    t.Numero,
//    op.Nome AS Telefone
//FROM TELEFONE t
//INNER JOIN OPERADORA op ON t.CODOPERADORA_FK = op.Cod
//WHERE t.numero LIKE @Numero;";
//                ConectaBanco cb = new ConectaBanco();
//                con = cb.conectaSqlServer();
//                cmd = new SqlCommand(sqlBuscar, con);
//                cmd.Parameters.AddWithValue("@Numero", txtBuscar.Text + "%");
//                cmd.CommandType = CommandType.Text;
//                con.Open();
//                da = new SqlDataAdapter(cmd);
//                ItensTelefoneClientes = new DataTable();
//                da.Fill(ItensTelefoneClientes);
//                dataGridView1.DataSource = ItensTelefoneClientes;
//                SqlDataReader tabtelefone = cmd.ExecuteReader();

//                if (tabtelefone.Read())
//                {
//                    txtId.Text = tabtelefone["Cod"].ToString();
//                    cbTelefone.Text = tabtelefone["Numero"].ToString();
//                    cbCliente.Text = tabtelefone["Telefone"].ToString();
//                    // Ativar controle dos botões
//                    tsbNovo.Enabled = false;
//                    tsbSalvar.Enabled = true;
//                    tsbCancelar.Enabled = true;
//                    tsbExcluir.Enabled = true;
//                    cbTelefone.Enabled = true;
//                    cbCliente.Enabled = true;
//                    cbTelefone.Focus();
//                    novo = false;
//                }
//                else
//                {
//                    MessageBox.Show("ItensTelefoneCliente não encontrada!");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Erro ao buscar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                con.Close();
//            }
//            txtBuscar.Text = string.Empty;
//        }
        //Relatorio
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //rltItensTelefoneCliente frm = new rltItensTelefoneCliente(ItensTelefoneClientes);
            //frm.ShowDialog();
        }
        //ComboBox
        private void cbTelefone_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoTelefone = cbTelefone.SelectedIndex;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoCliente = cbCliente.SelectedIndex;
        }
    }
}
