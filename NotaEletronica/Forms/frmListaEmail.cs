using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotaEletronica.DAL;

namespace NotaEletronica.Forms
{
    public partial class frmListaEmail : Form
    {
        TEmailDAL dal = new TEmailDAL();
        public frmListaEmail()
        {
            InitializeComponent();
        }

        private void frmListaEmail_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            if (rbFila.Checked)
            {
                var lista = new TEmailDAL().getFila();
                panel1.Visible = false;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
            }
            else
            {
                panel1.Visible = true;
                int NotaFiscal = string.IsNullOrEmpty(txtNotaFiscal.Text) ? 0 : Convert.ToInt32(txtNotaFiscal.Text);

                var lista = new TEmailDAL().getemails("Processado", dateTimePicker1.Value, dateTimePicker2.Value, NotaFiscal, txtEmail.Text);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            BLL.BLEmail bl = new BLL.BLEmail();
            bl.SendEmails();
            CarregaGrid();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void rbFila_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(rbFila.Checked)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                    TEmailDAL edal = new TEmailDAL();
                    Models.TEmail email = edal.GetByID(id);
                    frmEnviaEmail frmenv = new frmEnviaEmail(email);
                    frmenv.dal = edal;
                    frmenv.ShowDialog();
                    CarregaGrid();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
