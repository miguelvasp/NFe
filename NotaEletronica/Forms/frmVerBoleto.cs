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
    public partial class frmVerBoleto : Form
    {
        string content;
        public frmVerBoleto(string strContent)
        {
            content = strContent;
            InitializeComponent();
        }

        private void frmVerBoleto_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = content;
        }
    }
}
