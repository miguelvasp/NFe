using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotaEletronica.Forms
{
    public partial class frmBancoCad : Form
    {
        public DAL.BoletoConfiguracoesDAL dal;
        public Models.BoletoConfiguracoes c;
        
        public frmBancoCad()
        {
            InitializeComponent();
        }

        private void frmBancoCad_Load(object sender, EventArgs e)
        {
            txtnroDias.Text = c.nroDias.ToString();
            txtCarteira.Text = c.Cateira;
            txtBanco.Text = c.numeroBanco.ToString();
            txtNossoNumero.Text = c.NossoNumero;
            txtAgencia.Text = c.Agencia;
            txtDigitoAgencia.Text = c.DigitoAgencia;
            txtContaCorrente.Text = c.ContaCorrente;
            txtDigitoContaCorrente.Text = c.DigitoContaCorrente;
            txtCedente.Text = c.Codigo;
            txtConvenio.Text = c.Convenio;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var bancosFebraban = Util.Util.GetAppSettings("BancosFebraban").Split(',');

            if (!bancosFebraban.Contains(txtBanco.Text))
            {
                MessageBox.Show("Não existe layout disponível para o banco informado!");
                return;
            }

            c.nroDias = Convert.ToInt32(txtnroDias.Text);
            c.Cateira = txtCarteira.Text;
            c.numeroBanco = Convert.ToInt32(txtBanco.Text);
            c.NossoNumero = txtNossoNumero.Text;
            c.Agencia = txtAgencia.Text;
            c.DigitoAgencia = txtDigitoAgencia.Text;
            c.ContaCorrente = txtContaCorrente.Text;
            c.DigitoContaCorrente = txtDigitoContaCorrente.Text;
            c.Codigo = txtCedente.Text;
            c.Convenio = txtConvenio.Text;
            if(c.IdBoletoConfiguracoes == 0)
            {
                dal.Insert(c);
            }
            else
            {
                dal.Update(c);
            }
            dal.Save();
            this.Close();
        }
    }
}
