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
    public partial class frmMsgErro : Form
    {
        public frmMsgErro(string errp)
        {
            InitializeComponent();
            textBox1.Text = errp;
        }
    }
}
