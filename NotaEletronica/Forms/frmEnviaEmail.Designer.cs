namespace NotaEletronica.Forms
{
    partial class frmEnviaEmail
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
            this.txtDe = new System.Windows.Forms.TextBox();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "De:";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(15, 25);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(691, 20);
            this.txtDe.TabIndex = 1;
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(15, 67);
            this.txtPara.Multiline = true;
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(691, 122);
            this.txtPara.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Para:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(15, 208);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(691, 20);
            this.txtAsunto.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Assunto:";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(15, 259);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(691, 120);
            this.txtMensagem.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mensagem:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Adicionar a fila de envio de email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(398, 402);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(87, 23);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir Email";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmEnviaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 437);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.label1);
            this.Name = "frmEnviaEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email";
            this.Load += new System.EventHandler(this.frmEnviaEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExcluir;
    }
}