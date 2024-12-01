using NotaEletronica.Models;
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
    public partial class frmParams : Form
    {
        DAL.NFeParametroDAL dal = new DAL.NFeParametroDAL();
        Models.NFeParametro p = new Models.NFeParametro();
        DAL.BoletoConfiguracoesDAL bdal = new DAL.BoletoConfiguracoesDAL();
        public frmParams()
        {
            InitializeComponent();
        }

        private void frmParams_Load(object sender, EventArgs e)
        {
            List<ComboItem> itens = new List<ComboItem>();
            itens.Add(new ComboItem() { iValue = 1, Text = "Produção" });
            itens.Add(new ComboItem() { iValue = 2, Text = "Homologação" });
            cboAmbiente.DataSource = itens;
            cboAmbiente.DisplayMember = "Text";
            cboAmbiente.ValueMember = "iValue";
            cboAmbiente.SelectedIndex = -1;

            p = dal.Get().ToList()[0];
            cboAmbiente.SelectedValue = Convert.ToInt32(p.Ambiente);
            cboSiglaWS.Text = p.SiglaWS;
            txtLicensaNFe.Text = p.Licenca; 
            txtEmail.Text = p.eEmail;
            txtSMTP.Text = p.eSMTP;
            txtPorta.Text = p.ePort;
            txtUsuario.Text = p.eUsuario;
            txtSenha.Text = p.eSenha;
            chkSSL.Checked = p.eSSL;
            carregaGrid();
        }

        private void carregaGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bdal.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja salvar os dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                p.Ambiente = Convert.ToInt32(cboAmbiente.SelectedValue.ToString());
                p.SiglaWS = cboSiglaWS.Text;
                p.Licenca = txtLicensaNFe.Text; 
                p.eEmail = txtEmail.Text;
                p.eSMTP = txtSMTP.Text;
                p.ePort = txtPorta.Text;
                p.eUsuario = txtUsuario.Text;
                p.eSenha = txtSenha.Text;
                p.eSSL = chkSSL.Checked;

                if(p.IdNFeParametro == 0)
                {
                    dal.Insert(p);
                }
                else
                {
                    dal.Update(p);
                }
                dal.Save();
                MessageBox.Show("Dados salvos com sucesso!");
                this.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmBancoCad frmc = new frmBancoCad();
            frmc.c = new BoletoConfiguracoes();
            frmc.dal = bdal;
            frmc.ShowDialog();
            carregaGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var c = bdal.GetByID(Id);
            frmBancoCad frmc = new frmBancoCad();
            frmc.c = c;
            frmc.dal = bdal;
            frmc.ShowDialog();
            carregaGrid();
        }
    }
}
