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
    public partial class frmCartaCorrecao : Form
    {
        BLL.BLNFe40 bl = null;
        public frmCartaCorrecao(BLL.BLNFe40 bll)
        {
            bl = bll;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCCe.Text.Length < 15)
            {
                MessageBox.Show("É necessário informar no mínimo 15 caracteres!");
                return;
            }

            MessageBox.Show(bl.CartaCorrecao(txtCCe.Text));
        }
    }
}
