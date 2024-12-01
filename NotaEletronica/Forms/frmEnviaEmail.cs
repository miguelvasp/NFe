using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotaEletronica.Models;
using NotaEletronica.DAL;

namespace NotaEletronica.Forms
{
    public partial class frmEnviaEmail : Form
    {
        public TEmailDAL dal = new TEmailDAL();
        TEmail email;
        NFeParametro param;
        public int? ide_nNf;
        public frmEnviaEmail(TEmail pemail)
        {
            email = pemail;
            InitializeComponent();
            param = new NFeParametroDAL().Get().ToList()[0];
        }

        private void frmEnviaEmail_Load(object sender, EventArgs e)
        {
            txtDe.Text = email.de;
            txtPara.Text = email.para;
            txtAsunto.Text = email.Assunto;
            txtMensagem.Text = email.Mensagem;

            if(email.IdEmail > 0)
            {
                btnExcluir.Visible = true;
            }
            else
            {
                btnExcluir.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastraEmail();
        }

        private void CadastraEmail()
        {
            //valida os emails
            var emails = txtPara.Text.Split(',');
            foreach (string s in emails)
            {
                string em = s.Trim();
                if (!string.IsNullOrEmpty(em))
                {
                    if (!Util.Util.emailIsValid(em))
                    {
                        MessageBox.Show("Verifique o(s) email(s), email inválido!");
                        return;
                    }
                }
            }

            email.Assunto = txtAsunto.Text;
            email.para = txtPara.Text.Trim().TrimEnd(',').Trim();
            email.Mensagem = txtMensagem.Text;
            email.Status = "Na fila";
            email.Data = DateTime.Now;
            if (email.IdEmail == 0)
            {
                dal.Insert(email);
            }
            else
            {
                dal.Update(email);
            }

            dal.Save();
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dal.Delete(email.IdEmail);
            dal.Save();
            this.Close();
        }
    }
}
