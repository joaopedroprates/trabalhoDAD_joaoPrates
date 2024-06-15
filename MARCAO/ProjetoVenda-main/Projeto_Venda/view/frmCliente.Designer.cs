namespace Projeto_Venda_caua_joao.view
{
    partial class frmCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbSalvar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblBuscaId = new System.Windows.Forms.ToolStripLabel();
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRelatorio = new System.Windows.Forms.ToolStripButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatanasc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.cbRua = new System.Windows.Forms.ComboBox();
            this.cbBairro = new System.Windows.Forms.ComboBox();
            this.cbCep = new System.Windows.Forms.ComboBox();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.cbTrabalho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumerocasa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 292);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(558, 180);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Cod";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovo,
            this.tsbSalvar,
            this.tsbCancelar,
            this.tsbExcluir,
            this.toolStripSeparator1,
            this.lblBuscaId,
            this.txtBuscar,
            this.btnBuscar,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.btnRelatorio});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 27);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNovo
            // 
            this.tsbNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNovo.Image")));
            this.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovo.Name = "tsbNovo";
            this.tsbNovo.Size = new System.Drawing.Size(24, 24);
            this.tsbNovo.Text = "toolStripButton1";
            this.tsbNovo.ToolTipText = "Adicionar Novo Cliente";
            this.tsbNovo.Click += new System.EventHandler(this.tsbNovo_Click);
            // 
            // tsbSalvar
            // 
            this.tsbSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalvar.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalvar.Image")));
            this.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalvar.Name = "tsbSalvar";
            this.tsbSalvar.Size = new System.Drawing.Size(24, 24);
            this.tsbSalvar.Text = "toolStripButton1";
            this.tsbSalvar.ToolTipText = "Salvar Cliente";
            this.tsbSalvar.Click += new System.EventHandler(this.tsbSalvar_Click);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(24, 24);
            this.tsbCancelar.Text = "toolStripButton1";
            this.tsbCancelar.ToolTipText = "Cancelar";
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // tsbExcluir
            // 
            this.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExcluir.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcluir.Image")));
            this.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluir.Name = "tsbExcluir";
            this.tsbExcluir.Size = new System.Drawing.Size(24, 24);
            this.tsbExcluir.Text = "toolStripButton1";
            this.tsbExcluir.ToolTipText = "Excluir Registro";
            this.tsbExcluir.Click += new System.EventHandler(this.tsbExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lblBuscaId
            // 
            this.lblBuscaId.Name = "lblBuscaId";
            this.lblBuscaId.Size = new System.Drawing.Size(100, 24);
            this.lblBuscaId.Text = "Buscar por nome:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(180, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 24);
            this.btnBuscar.Text = "toolStripButton1";
            this.btnBuscar.ToolTipText = "Buscar Cliente";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorio.Image")));
            this.btnRelatorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(24, 24);
            this.btnRelatorio.Text = "toolStripButton1";
            this.btnRelatorio.ToolTipText = "Gerar Relatório";
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(118, 94);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(162, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.Text = "OI9III";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 94);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 33;
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(431, 229);
            this.btnFoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(94, 21);
            this.btnFoto.TabIndex = 11;
            this.btnFoto.Text = "Importar foto";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(404, 94);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Foto";
            // 
            // txtDatanasc
            // 
            this.txtDatanasc.Location = new System.Drawing.Point(298, 94);
            this.txtDatanasc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDatanasc.Mask = "00/00/0000";
            this.txtDatanasc.Name = "txtDatanasc";
            this.txtDatanasc.Size = new System.Drawing.Size(93, 20);
            this.txtDatanasc.TabIndex = 2;
            this.txtDatanasc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Data de nascimento";
            // 
            // cbSexo
            // 
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(9, 136);
            this.cbSexo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(103, 21);
            this.cbSexo.TabIndex = 3;
            this.cbSexo.SelectedIndexChanged += new System.EventHandler(this.cbSexo_SelectedIndexChanged);
            // 
            // cbRua
            // 
            this.cbRua.FormattingEnabled = true;
            this.cbRua.Location = new System.Drawing.Point(118, 136);
            this.cbRua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRua.Name = "cbRua";
            this.cbRua.Size = new System.Drawing.Size(92, 21);
            this.cbRua.TabIndex = 4;
            this.cbRua.SelectedIndexChanged += new System.EventHandler(this.cbRua_SelectedIndexChanged);
            // 
            // cbBairro
            // 
            this.cbBairro.FormattingEnabled = true;
            this.cbBairro.Location = new System.Drawing.Point(213, 136);
            this.cbBairro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBairro.Name = "cbBairro";
            this.cbBairro.Size = new System.Drawing.Size(92, 21);
            this.cbBairro.TabIndex = 5;
            this.cbBairro.SelectedIndexChanged += new System.EventHandler(this.cbBairro_SelectedIndexChanged);
            // 
            // cbCep
            // 
            this.cbCep.FormattingEnabled = true;
            this.cbCep.Location = new System.Drawing.Point(308, 136);
            this.cbCep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCep.Name = "cbCep";
            this.cbCep.Size = new System.Drawing.Size(92, 21);
            this.cbCep.TabIndex = 6;
            this.cbCep.SelectedIndexChanged += new System.EventHandler(this.cbCep_SelectedIndexChanged);
            // 
            // cbCidade
            // 
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(9, 187);
            this.cbCidade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(127, 21);
            this.cbCidade.TabIndex = 7;
            this.cbCidade.SelectedIndexChanged += new System.EventHandler(this.cbCidade_SelectedIndexChanged);
            // 
            // cbTrabalho
            // 
            this.cbTrabalho.FormattingEnabled = true;
            this.cbTrabalho.Location = new System.Drawing.Point(140, 187);
            this.cbTrabalho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTrabalho.Name = "cbTrabalho";
            this.cbTrabalho.Size = new System.Drawing.Size(140, 21);
            this.cbTrabalho.TabIndex = 8;
            this.cbTrabalho.SelectedIndexChanged += new System.EventHandler(this.cbTrabalho_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Sexo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Rua";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Bairro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Cep";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Cidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Trabalho";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(282, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Salario";
            // 
            // txtSalario
            // 
            this.txtSalario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalario.Location = new System.Drawing.Point(284, 187);
            this.txtSalario.MaxLength = 50;
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(116, 20);
            this.txtSalario.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Numero da casa";
            // 
            // txtNumerocasa
            // 
            this.txtNumerocasa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumerocasa.Location = new System.Drawing.Point(9, 229);
            this.txtNumerocasa.MaxLength = 50;
            this.txtNumerocasa.Name = "txtNumerocasa";
            this.txtNumerocasa.Size = new System.Drawing.Size(81, 20);
            this.txtNumerocasa.TabIndex = 10;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 495);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNumerocasa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTrabalho);
            this.Controls.Add(this.cbCidade);
            this.Controls.Add(this.cbCep);
            this.Controls.Add(this.cbBairro);
            this.Controls.Add(this.cbRua);
            this.Controls.Add(this.cbSexo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDatanasc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNovo;
        private System.Windows.Forms.ToolStripButton tsbSalvar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.ToolStripButton tsbExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblBuscaId;
        private System.Windows.Forms.ToolStripTextBox txtBuscar;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRelatorio;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDatanasc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.ComboBox cbRua;
        private System.Windows.Forms.ComboBox cbBairro;
        private System.Windows.Forms.ComboBox cbCep;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.ComboBox cbTrabalho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumerocasa;
    }
}