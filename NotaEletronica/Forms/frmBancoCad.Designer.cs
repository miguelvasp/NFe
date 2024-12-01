namespace NotaEletronica.Forms
{
    partial class frmBancoCad
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.txtDigitoAgencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDigitoContaCorrente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCarteira = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNossoNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCedente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtnroDias = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agencia";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(143, 57);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(100, 20);
            this.txtAgencia.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::NotaEletronica.Properties.Resources.fundo;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(508, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::NotaEletronica.Properties.Resources.Save_icon1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(93, 22);
            this.toolStripButton1.Text = "Salvar dados";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // txtDigitoAgencia
            // 
            this.txtDigitoAgencia.Location = new System.Drawing.Point(249, 57);
            this.txtDigitoAgencia.Name = "txtDigitoAgencia";
            this.txtDigitoAgencia.Size = new System.Drawing.Size(46, 20);
            this.txtDigitoAgencia.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dígito";
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.Location = new System.Drawing.Point(301, 57);
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.Size = new System.Drawing.Size(100, 20);
            this.txtContaCorrente.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Conta Corrente";
            // 
            // txtDigitoContaCorrente
            // 
            this.txtDigitoContaCorrente.Location = new System.Drawing.Point(407, 57);
            this.txtDigitoContaCorrente.Name = "txtDigitoContaCorrente";
            this.txtDigitoContaCorrente.Size = new System.Drawing.Size(46, 20);
            this.txtDigitoContaCorrente.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dígito";
            // 
            // txtCarteira
            // 
            this.txtCarteira.Location = new System.Drawing.Point(37, 106);
            this.txtCarteira.Name = "txtCarteira";
            this.txtCarteira.Size = new System.Drawing.Size(100, 20);
            this.txtCarteira.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Carteira";
            // 
            // txtNossoNumero
            // 
            this.txtNossoNumero.Location = new System.Drawing.Point(143, 106);
            this.txtNossoNumero.Name = "txtNossoNumero";
            this.txtNossoNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNossoNumero.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nosso Número";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(37, 57);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(100, 20);
            this.txtBanco.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Número do banco";
            // 
            // txtCedente
            // 
            this.txtCedente.Location = new System.Drawing.Point(249, 106);
            this.txtCedente.Name = "txtCedente";
            this.txtCedente.Size = new System.Drawing.Size(100, 20);
            this.txtCedente.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código do Cedente";
            // 
            // txtConvenio
            // 
            this.txtConvenio.Location = new System.Drawing.Point(355, 106);
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(100, 20);
            this.txtConvenio.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Convenio";
            // 
            // txtnroDias
            // 
            this.txtnroDias.Location = new System.Drawing.Point(37, 161);
            this.txtnroDias.Name = "txtnroDias";
            this.txtnroDias.Size = new System.Drawing.Size(100, 20);
            this.txtnroDias.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dias ate o vencimento";
            // 
            // frmBancoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 214);
            this.Controls.Add(this.txtnroDias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtConvenio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCedente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNossoNumero);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCarteira);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDigitoContaCorrente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContaCorrente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDigitoAgencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBancoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco";
            this.Load += new System.EventHandler(this.frmBancoCad_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtDigitoAgencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDigitoContaCorrente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarteira;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNossoNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCedente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtnroDias;
        private System.Windows.Forms.Label label10;
    }
}