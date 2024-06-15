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
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Projeto_Venda_caua_joao.view
{
    public partial class frmCliente : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable clientes;
        bool novo = false;
        bool novaFoto = false;
        List<Sexo> auxSexo = new List<Sexo>();
        List<Rua> auxRua = new List<Rua>();
        List<Bairro> auxBairro = new List<Bairro>();
        List<Cep> auxCep = new List<Cep>();
        List<Cidade> auxCidade = new List<Cidade>();
        List<Trabalho> auxTrabalho = new List<Trabalho>();
        int posicaoSexo = 0;
        int posicaoRua = 0;
        int posicaoBairro = 0;
        int posicaoCep = 0;
        int posicaoCidade = 0;
        int posicaoTrabalho = 0;
        //funções
        public void carregaSexo()
        {
            C_Sexo cs = new C_Sexo();
            auxSexo = new List<Sexo>();
            auxSexo = cs.carregaDados();
            cbSexo.DataSource = auxSexo;
            cbSexo.DisplayMember = "nome";
            cbSexo.ValueMember = "cod";
        }
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
        public void carregaTrabalho()
        {
            C_Trabalho cs = new C_Trabalho();
            auxTrabalho = new List<Trabalho>();
            auxTrabalho = cs.carregaDados();
            cbTrabalho.DataSource = auxTrabalho;
            cbTrabalho.DisplayMember = "nome";
            cbTrabalho.ValueMember = "cod";
        }
        public void carregarTabela()
        {
            C_Cliente cc = new C_Cliente();
            clientes = cc.buscarTodos();
            dataGridView1.DataSource = clientes;
        }
        public byte[] ConverteImageEmByte(System.Drawing.Image obj)
        {
                MemoryStream ms = new MemoryStream();
            try
            {
                if (obj != null)
                {
                    obj.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] img = ms.ToArray();
                    return img;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao converter imagem para byte!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        //Carrega as informações no DatagridView1 com os dados das clientes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            if (index > -1)
            {
                try
                {
                    pictureBox1.Image = null;
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    byte[] imagemBytes = dataGridView1.CurrentRow.Cells[2].Value as byte[];
                    if (imagemBytes != null)
                    {
                        using (MemoryStream stream = new MemoryStream(imagemBytes))
                        {
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                    }
                    txtDatanasc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    cbSexo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    cbRua.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    cbBairro.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    cbCep.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    cbCidade.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    txtSalario.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    cbTrabalho.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    txtNumerocasa.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

                    tsbNovo.Enabled = false;
                    tsbCancelar.Enabled = true;
                    tsbSalvar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    txtDatanasc.Enabled = true;
                    cbSexo.Enabled = true;
                    cbRua.Enabled = true;
                    cbBairro.Enabled = true;
                    cbCep.Enabled = true;
                    cbCidade.Enabled = true;
                    cbTrabalho.Enabled = true;
                    btnFoto.Enabled = true;
                    txtSalario.Enabled = true;
                    txtNumerocasa.Enabled = true;

                    novo = false;
                    novaFoto = false;
                    txtNome.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Construtor da Classe frmCliente
        public frmCliente()
        {
            InitializeComponent();
            carregarTabela();
            carregaSexo();
            carregaRua();
            carregaBairro();
            carregaCep();
            carregaCidade();
            carregaTrabalho();
            txtNome.Focus();
            txtNome.Enabled = false;
            txtDatanasc.Enabled = false;
            cbSexo.Enabled = false;
            cbRua.Enabled = false;
            cbBairro.Enabled = false;
            cbCep.Enabled = false;
            cbCidade.Enabled = false;
            cbTrabalho.Enabled = false;
            btnFoto.Enabled = false;
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
            txtDatanasc.Enabled = true;
            cbSexo.Enabled = true;
            cbRua.Enabled = true;
            cbBairro.Enabled = true;
            cbCep.Enabled = true;
            cbCidade.Enabled = true;
            cbTrabalho.Enabled = true;
            btnFoto.Enabled = true;
            txtSalario.Enabled = true;
            txtNumerocasa.Enabled = true;

            txtId.Text = "";
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            txtNome.Focus();
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string formatoData = "dd/MM/yyyy";
                DateTime datanasc;
                DateTime.TryParseExact(txtDatanasc.Text, formatoData, CultureInfo.InvariantCulture, DateTimeStyles.None, out datanasc);
                if (novo)
                {
                    Cliente cliente = new Cliente
                    {
                        Nome = txtNome.Text,
                        Foto = ConverteImageEmByte(pictureBox1.Image),
                        Datanasc = datanasc,
                        Sexo = auxSexo[posicaoSexo],
                        Rua = auxRua[posicaoRua],
                        Bairro = auxBairro[posicaoBairro],
                        Cep = auxCep[posicaoCep],
                        Cidade = auxCidade[posicaoCidade],
                        Trabalho = auxTrabalho[posicaoTrabalho],
                        Salario = Double.Parse(txtSalario.Text),
                        Numerocasa = txtNumerocasa.Text
                    };
                    C_Cliente cc = new C_Cliente();
                    cc.insereDados(cliente);
                }
                else
                {
                    if (novaFoto)
                    {
                        Cliente cliente = new Cliente
                        {
                            Cod = Int32.Parse(txtId.Text),
                            Nome = txtNome.Text,
                            Foto = ConverteImageEmByte(pictureBox1.Image),
                            Datanasc = datanasc,
                            Sexo = auxSexo[posicaoSexo],
                            Rua = auxRua[posicaoRua],
                            Bairro = auxBairro[posicaoBairro],
                            Cep = auxCep[posicaoCep],
                            Cidade = auxCidade[posicaoCidade],
                            Trabalho = auxTrabalho[posicaoTrabalho],
                            Salario = Double.Parse(txtSalario.Text),
                            Numerocasa = txtNumerocasa.Text
                        };
                        C_Cliente c_cliente = new C_Cliente();
                        c_cliente.editaDados(cliente);
                    }
                    else
                    {
                        Cliente cliente = new Cliente
                        {
                            Cod = Int32.Parse(txtId.Text),
                            Nome = txtNome.Text,
                            Datanasc = datanasc,
                            Sexo = auxSexo[posicaoSexo],
                            Rua = auxRua[posicaoRua],
                            Bairro = auxBairro[posicaoBairro],
                            Cep = auxCep[posicaoCep],
                            Cidade = auxCidade[posicaoCidade],
                            Trabalho = auxTrabalho[posicaoTrabalho],
                            Salario = Double.Parse(txtSalario.Text),
                            Numerocasa = txtNumerocasa.Text
                        };
                        C_Cliente c_cliente = new C_Cliente();
                        c_cliente.editaDados2(cliente);
                    }
                }
                carregarTabela();
                txtNome.Enabled = false;
                txtDatanasc.Enabled = false;
                cbSexo.Enabled = false;
                cbRua.Enabled = false;
                cbBairro.Enabled = false;
                cbCep.Enabled = false;
                cbCidade.Enabled = false;
                cbTrabalho.Enabled = false;
                btnFoto.Enabled = false;
                txtSalario.Enabled = false;
                txtNumerocasa.Enabled = false;

                txtNome.Clear();
                txtId.Clear();
                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;
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
                C_Cliente cc = new C_Cliente();
                cc.apagaDados(Int32.Parse(txtId.Text));
                carregarTabela();
                txtNome.Enabled = false;
                txtDatanasc.Enabled = false;
                cbSexo.Enabled = false;
                cbRua.Enabled = false;
                cbBairro.Enabled = false;
                cbCep.Enabled = false;
                cbCidade.Enabled = false;
                cbTrabalho.Enabled = false;
                btnFoto.Enabled = false;
                txtSalario.Enabled = false;
                txtNumerocasa.Enabled = false;

                txtNome.Clear();
                txtId.Clear();
                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbNovo.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir!!!\n\nErro: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            txtDatanasc.Enabled = false;
            cbSexo.Enabled = false;
            cbRua.Enabled = false;
            cbBairro.Enabled = false;
            cbCep.Enabled = false;
            cbCidade.Enabled = false;
            cbTrabalho.Enabled = false;
            btnFoto.Enabled = false;
            txtSalario.Enabled = false;
            txtNumerocasa.Enabled = false;

            txtNome.Clear();
            txtId.Clear();
            txtDatanasc.Clear();
            txtNumerocasa.Clear();
            txtSalario.Clear();
            pictureBox1.Image = null;
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
INNER JOIN TRABALHO trabalho ON c.CODTRABALHO_FK = trabalho.COD
WHERE c.nome LIKE @Nome;";
                ConectaBanco cb = new ConectaBanco();
                con = cb.conectaSqlServer();
                cmd = new SqlCommand(sqlBuscar, con);
                // Passando parâmetros para a sentença SQL
                cmd.Parameters.AddWithValue("@Nome", txtBuscar.Text + "%");
                cmd.CommandType = CommandType.Text;
                con.Open();
                //*******carregando datagrid ***************************************8
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                clientes = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(clientes);


                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = clientes;
                //*******************fim do carregamento do datagrid
                // Executar a leitura dos dados da cliente
                SqlDataReader tabcliente = cmd.ExecuteReader();

                if (tabcliente.Read())
                {
                    txtId.Text = tabcliente["Cod"].ToString();
                    txtNome.Text = tabcliente["Nome"].ToString();
                    txtDatanasc.Text = tabcliente["Datanasc"].ToString();
                    cbSexo.Text = tabcliente["Sexo"].ToString();
                    cbRua.Text = tabcliente["Rua"].ToString();
                    cbBairro.Text = tabcliente["Bairro"].ToString();
                    cbCep.Text = tabcliente["Cep"].ToString();
                    cbCidade.Text = tabcliente["Cidade"].ToString();
                    cbTrabalho.Text = tabcliente["Trabalho"].ToString();
                    pictureBox1.Text = tabcliente["Foto"].ToString();
                    txtSalario.Text = tabcliente["Salario"].ToString();
                    txtNumerocasa.Text = tabcliente["Numerocasa"].ToString();

                    // Ativar controle dos botões
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    txtNome.Enabled = true;
                    txtDatanasc.Enabled = true;
                    cbSexo.Enabled = true;
                    cbRua.Enabled = true;
                    cbBairro.Enabled = true;
                    cbCep.Enabled = true;
                    cbCidade.Enabled = true;
                    cbTrabalho.Enabled = true;
                    btnFoto.Enabled = true;
                    txtSalario.Enabled = true;
                    txtNumerocasa.Enabled = true;

                    txtNome.Focus();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrada!");
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
        private void btnFoto_Click(object sender, EventArgs e)
        {
            String imagLoction = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagLoction = dialog.FileName;
                    pictureBox1.ImageLocation = imagLoction;
                    novaFoto = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Relatorio
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            rltCliente frm = new rltCliente(clientes);
            frm.ShowDialog();
        }
        //ComboBox
        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoSexo = cbSexo.SelectedIndex;
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
        private void cbTrabalho_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicaoTrabalho = cbTrabalho.SelectedIndex;
        }
    }
}
