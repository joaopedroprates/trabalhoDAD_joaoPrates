using Projeto_Venda_caua_joao.controller;
using Projeto_Venda_caua_joao.model;
using Projeto_Venda_caua_joao.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_caua_joao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }
        private void aCESSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcesso frm = new frmAcesso();
            frm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sEXOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSexo frm = new frmSexo();
            frm.ShowDialog();
        }

        private void bAIRROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBairro frm = new frmBairro();
            frm.ShowDialog();
        }

        private void cEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCep frm = new frmCep();
            frm.ShowDialog();
        }

        private void rUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRua frmRua = new frmRua();
            frmRua.ShowDialog();    
        }

        private void tRABALHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabalho frmTrabalho = new frmTrabalho();
            frmTrabalho.ShowDialog();
        }

        private void lOJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoja frmLoja = new frmLoja();
            frmLoja.ShowDialog();
        }

        private void uFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUf frm = new frmUf();    
            frm.ShowDialog();
        }

        private void tIPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo frm = new frmTipo();
            frm.ShowDialog();
        }

        private void mARCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca frm = new frmMarca();
            frm.ShowDialog();
        }

        private void oPERADORAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperadora frm = new frmOperadora();
            frm.ShowDialog();
        }

        private void sITUAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSituacao frm = new frmSituacao();
            frm.ShowDialog();
        }

        private void fUNÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncao frm = new frmFuncao();
            frm.ShowDialog();
        }

        private void cLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.ShowDialog();
        }

        private void cidadesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCadastroCidades cadcidade = new frmCadastroCidades();
            cadcidade.ShowDialog();
        }

        private void tELEFONEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelefone frm = new frmTelefone();
            frm.ShowDialog();
        }

        private void tELEFONEECLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItensTelefoneCliente frm = new frmItensTelefoneCliente();
            frm.ShowDialog();
        }

        private void fUNCIONARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionario frm = new frmFuncionario();
            frm.ShowDialog();
        }

        private void lOGINSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogins frm = new frmLogins();
            frm.ShowDialog();
        }
    }
}
