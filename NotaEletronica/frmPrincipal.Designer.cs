namespace NotaEletronica
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDest = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboEmitente = new System.Windows.Forms.ComboBox();
            this.lbHomologacao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroAte = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroDe = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAte = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnValidar = new System.Windows.Forms.ToolStripButton();
            this.btnSalvarXML = new System.Windows.Forms.ToolStripButton();
            this.btnTransmitir = new System.Windows.Forms.ToolStripButton();
            this.btnConsultarSEFAZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnPrintSumatra = new System.Windows.Forms.ToolStripButton();
            this.btnEnviarEmail = new System.Windows.Forms.ToolStripButton();
            this.btnClonar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnCartaCorrecao = new System.Windows.Forms.ToolStripButton();
            this.btnEmitirBoletos = new System.Windows.Forms.ToolStripButton();
            this.btnListaBoletos = new System.Windows.Forms.ToolStripButton();
            this.btnEmail = new System.Windows.Forms.ToolStripButton();
            this.btnConfiguracoes = new System.Windows.Forms.ToolStripButton();
            this.btnAtualizar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDest);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cboEmitente);
            this.groupBox1.Controls.Add(this.lbHomologacao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cboSituacao);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumeroAte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNumeroDe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAte);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(167, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1330, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pequisa";
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(140, 122);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(358, 22);
            this.txtDest.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Destinatário";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NotaEletronica.Properties.Resources.nfe_versao_4;
            this.pictureBox1.Location = new System.Drawing.Point(17, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // cboEmitente
            // 
            this.cboEmitente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmitente.FormattingEnabled = true;
            this.cboEmitente.Location = new System.Drawing.Point(196, 21);
            this.cboEmitente.Name = "cboEmitente";
            this.cboEmitente.Size = new System.Drawing.Size(315, 22);
            this.cboEmitente.TabIndex = 14;
            // 
            // lbHomologacao
            // 
            this.lbHomologacao.AutoSize = true;
            this.lbHomologacao.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHomologacao.ForeColor = System.Drawing.Color.Red;
            this.lbHomologacao.Location = new System.Drawing.Point(517, 24);
            this.lbHomologacao.Name = "lbHomologacao";
            this.lbHomologacao.Size = new System.Drawing.Size(258, 19);
            this.lbHomologacao.TabIndex = 13;
            this.lbHomologacao.Text = "AMBIENTE DE HOMOLOGAÇÃO";
            this.lbHomologacao.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Emitente:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(807, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboSituacao
            // 
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(504, 122);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(297, 22);
            this.cboSituacao.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // txtNumeroAte
            // 
            this.txtNumeroAte.Location = new System.Drawing.Point(439, 72);
            this.txtNumeroAte.Name = "txtNumeroAte";
            this.txtNumeroAte.Size = new System.Drawing.Size(59, 22);
            this.txtNumeroAte.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "a";
            // 
            // txtNumeroDe
            // 
            this.txtNumeroDe.Location = new System.Drawing.Point(365, 72);
            this.txtNumeroDe.Name = "txtNumeroDe";
            this.txtNumeroDe.Size = new System.Drawing.Size(59, 22);
            this.txtNumeroDe.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Número NF-e:";
            // 
            // txtAte
            // 
            this.txtAte.Location = new System.Drawing.Point(239, 72);
            this.txtAte.Mask = "99/99/9999";
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(80, 22);
            this.txtAte.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "a";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(140, 72);
            this.txtDe.Mask = "99/99/9999";
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(81, 22);
            this.txtDe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Período de Emissão:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(167, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1330, 714);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Column1";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Serie";
            this.Column2.HeaderText = "Série";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Numero";
            this.Column3.HeaderText = "Número";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Emissao";
            this.Column4.HeaderText = "Emissão";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 110;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Chave Autenticação";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 290;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Destinatario";
            this.Column6.HeaderText = "Destinatário";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Situacao";
            this.Column7.HeaderText = "Situação";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 180;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "MsgRetorno";
            this.Column8.HeaderText = "Mensagem SEFAZ";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 500;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(172, 165);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(15, 14);
            this.chkSelect.TabIndex = 3;
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::NotaEletronica.Properties.Resources.Screenshot_1;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton13,
            this.btnNovo,
            this.btnValidar,
            this.btnSalvarXML,
            this.btnTransmitir,
            this.btnConsultarSEFAZ,
            this.toolStripButton4,
            this.btnImprimir,
            this.btnPrintSumatra,
            this.btnEnviarEmail,
            this.btnClonar,
            this.btnCancelar,
            this.toolStripButton1,
            this.btnCartaCorrecao,
            this.btnEmitirBoletos,
            this.btnListaBoletos,
            this.btnEmail,
            this.btnConfiguracoes,
            this.btnAtualizar});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 1, 10);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(167, 874);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton13.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripButton13.ForeColor = System.Drawing.Color.White;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(109, 17);
            this.toolStripButton13.Text = "Opções do Sistema";
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Image = global::NotaEletronica.Properties.Resources.Files_New_File_icon;
            this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(60, 28);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.ForeColor = System.Drawing.Color.White;
            this.btnValidar.Image = global::NotaEletronica.Properties.Resources.document_check_icon;
            this.btnValidar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnValidar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(67, 28);
            this.btnValidar.Text = "Validar";
            this.btnValidar.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnSalvarXML
            // 
            this.btnSalvarXML.ForeColor = System.Drawing.Color.White;
            this.btnSalvarXML.Image = global::NotaEletronica.Properties.Resources.File_Adobe_Dreamweaver_XML_01_icon;
            this.btnSalvarXML.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalvarXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvarXML.Name = "btnSalvarXML";
            this.btnSalvarXML.Size = new System.Drawing.Size(99, 28);
            this.btnSalvarXML.Text = "Exportar XML";
            this.btnSalvarXML.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // btnTransmitir
            // 
            this.btnTransmitir.ForeColor = System.Drawing.Color.White;
            this.btnTransmitir.Image = global::NotaEletronica.Properties.Resources.torrent_icon;
            this.btnTransmitir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTransmitir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransmitir.Name = "btnTransmitir";
            this.btnTransmitir.Size = new System.Drawing.Size(82, 28);
            this.btnTransmitir.Text = "Transmitir";
            this.btnTransmitir.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // btnConsultarSEFAZ
            // 
            this.btnConsultarSEFAZ.ForeColor = System.Drawing.Color.White;
            this.btnConsultarSEFAZ.Image = global::NotaEletronica.Properties.Resources.search_icon;
            this.btnConsultarSEFAZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConsultarSEFAZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsultarSEFAZ.Name = "btnConsultarSEFAZ";
            this.btnConsultarSEFAZ.Size = new System.Drawing.Size(130, 28);
            this.btnConsultarSEFAZ.Text = "Consultar na SEFAZ";
            this.btnConsultarSEFAZ.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = global::NotaEletronica.Properties.Resources.Places_folder_downloads_icon__1_;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(104, 28);
            this.toolStripButton4.Text = "Download XML";
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = global::NotaEletronica.Properties.Resources.Printer_icon;
            this.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 28);
            this.btnImprimir.Text = "Visualizar Danfe (pdf)";
            this.btnImprimir.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // btnPrintSumatra
            // 
            this.btnPrintSumatra.ForeColor = System.Drawing.Color.White;
            this.btnPrintSumatra.Image = global::NotaEletronica.Properties.Resources.Printer_icon;
            this.btnPrintSumatra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintSumatra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSumatra.Name = "btnPrintSumatra";
            this.btnPrintSumatra.Size = new System.Drawing.Size(105, 28);
            this.btnPrintSumatra.Text = "Imprimir Danfe";
            this.btnPrintSumatra.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.ForeColor = System.Drawing.Color.White;
            this.btnEnviarEmail.Image = global::NotaEletronica.Properties.Resources.email_icon;
            this.btnEnviarEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEnviarEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(100, 36);
            this.btnEnviarEmail.Text = "Enviar Email";
            this.btnEnviarEmail.ToolTipText = "Enviar Email";
            this.btnEnviarEmail.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnClonar
            // 
            this.btnClonar.ForeColor = System.Drawing.Color.White;
            this.btnClonar.Image = global::NotaEletronica.Properties.Resources.Copy_icon;
            this.btnClonar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClonar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClonar.Name = "btnClonar";
            this.btnClonar.Size = new System.Drawing.Size(121, 28);
            this.btnClonar.Text = "Clonar Para Teste";
            this.btnClonar.Click += new System.EventHandler(this.btnClonar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::NotaEletronica.Properties.Resources.File_Delete_icon;
            this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 28);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = global::NotaEletronica.Properties.Resources.trash_icon;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 28);
            this.toolStripButton1.Text = "Inutilizar NF-e";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // btnCartaCorrecao
            // 
            this.btnCartaCorrecao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartaCorrecao.ForeColor = System.Drawing.Color.White;
            this.btnCartaCorrecao.Image = global::NotaEletronica.Properties.Resources.Edit_Document_icon;
            this.btnCartaCorrecao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCartaCorrecao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCartaCorrecao.Name = "btnCartaCorrecao";
            this.btnCartaCorrecao.Size = new System.Drawing.Size(109, 28);
            this.btnCartaCorrecao.Text = "Carta Correção";
            this.btnCartaCorrecao.Click += new System.EventHandler(this.btnCartaCorrecao_Click);
            // 
            // btnEmitirBoletos
            // 
            this.btnEmitirBoletos.ForeColor = System.Drawing.Color.White;
            this.btnEmitirBoletos.Image = global::NotaEletronica.Properties.Resources.Barcode_icon;
            this.btnEmitirBoletos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmitirBoletos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmitirBoletos.Name = "btnEmitirBoletos";
            this.btnEmitirBoletos.Size = new System.Drawing.Size(99, 28);
            this.btnEmitirBoletos.Text = "Emitir Boletos";
            this.btnEmitirBoletos.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // btnListaBoletos
            // 
            this.btnListaBoletos.ForeColor = System.Drawing.Color.White;
            this.btnListaBoletos.Image = global::NotaEletronica.Properties.Resources.Actions_view_list_details_icon;
            this.btnListaBoletos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnListaBoletos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListaBoletos.Name = "btnListaBoletos";
            this.btnListaBoletos.Size = new System.Drawing.Size(110, 28);
            this.btnListaBoletos.Text = "Lista de Boletos";
            this.btnListaBoletos.Click += new System.EventHandler(this.btnListaBoletos_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.Image = global::NotaEletronica.Properties.Resources.email_icon;
            this.btnEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(114, 36);
            this.btnEmail.Text = "Caixa de Saída";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracoes.Image = global::NotaEletronica.Properties.Resources.database_settings_icon__1_;
            this.btnConfiguracoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConfiguracoes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(104, 28);
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.Click += new System.EventHandler(this.toolStripButton15_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Image = global::NotaEletronica.Properties.Resources.Button_Refresh_icon__1_;
            this.btnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(108, 28);
            this.btnAtualizar.Text = "Atualizar Notas";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1497, 874);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NF-e - v40.0 (NFe_Util_2Gv4.17b) Release 26";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnValidar;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton btnTransmitir;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnConsultarSEFAZ;
        private System.Windows.Forms.ToolStripButton btnClonar;
        private System.Windows.Forms.ToolStripButton btnSalvarXML;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnCartaCorrecao;
        private System.Windows.Forms.ToolStripButton btnListaBoletos;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton btnConfiguracoes;
        private System.Windows.Forms.MaskedTextBox txtAte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtNumeroAte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtNumeroDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbHomologacao;
        private System.Windows.Forms.ToolStripButton btnEmitirBoletos;
        private System.Windows.Forms.ToolStripButton btnEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboEmitente;
        private System.Windows.Forms.ToolStripButton btnEnviarEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripButton btnAtualizar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.MaskedTextBox txtDest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton btnPrintSumatra;
    }
}

