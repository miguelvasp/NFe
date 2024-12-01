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
    public partial class frmCancelamento : Form
    {
        BLL.BLNFe40 bl = null;
        public frmCancelamento(BLL.BLNFe40 bll)
        {
            bl = bll;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 15)
            {
                MessageBox.Show(this, "Informe pelo menos 15 caracteres na justificativa de cancelamento");
                return;
            }
            MessageBox.Show(this, bl.CancelaNotaFiscal(textBox1.Text)); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Close();
        }
    }
}
