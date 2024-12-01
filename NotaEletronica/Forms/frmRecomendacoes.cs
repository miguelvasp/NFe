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
    public partial class frmRecomendacoes : Form
    {
        public frmRecomendacoes(List<string> erros)
        {
            InitializeComponent();
            foreach(string s in erros)
            {
                textBox1.AppendText($"{s}\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
