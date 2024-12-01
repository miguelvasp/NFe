using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotaEletronica.Forms
{
    public partial class frmInutilizar : Form
    {
        BLL.BLNFe40 bl = null;
        List<Models.NFeInutiliza> lista = new List<Models.NFeInutiliza>();
        public frmInutilizar(BLL.BLNFe40 bll)
        {
            bl = bll;
            InitializeComponent();
        }

        public string XNomeCertificado { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        { 

            if(string.IsNullOrEmpty(txtJustificativa.Text) || string.IsNullOrEmpty(txtNF.Text) || string.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Prencha todas as informações");
                return;
            }


            Models.NFeInutiliza obj = new Models.NFeInutiliza();
            obj.Numero = txtNF.Text;
            obj.Serie = txtSerie.Text;
            obj.Justificativa = txtJustificativa.Text;
            int status = 0;

            string msg = bl.InutilizarNFe(obj, out status);

            Carregar();

            if(status == 102)
            {
                txtJustificativa.Text = "";
                txtNF.Text = "";
                txtSerie.Text = ""; 
            }

            MessageBox.Show(msg);
            

        }

        private void Carregar()
        {
            lista = new DAL.NFeInutilizaDAL().Get().ToList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void frmInutilizar_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                var inutiliza = lista.Where(x => x.id == id).FirstOrDefault();
                if(inutiliza != null)
                {
                    
                    FolderBrowserDialog ff = new FolderBrowserDialog();
                    
                    ff.ShowDialog();
                    string xmlPath = ff.SelectedPath + "\\" + inutiliza.Numero + "-inutiliza.xml";
                    using (StreamWriter outfilec = new StreamWriter(xmlPath, false))
                    {
                        outfilec.Write(inutiliza.XMLInut);
                        outfilec.Close();
                        MessageBox.Show("Arquivo Salvo com sucesso");
                    }
                }
            }
            catch
            {

                throw;
            }
        }
    }
}
