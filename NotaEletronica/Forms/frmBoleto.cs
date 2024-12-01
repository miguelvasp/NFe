using BoletoNet;
using NotaEletronica.DAL;
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
    public partial class frmBoleto : Form
    {
        BoletoDAL dal = new BoletoDAL();
        public frmBoleto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            DateTime de = Convert.ToDateTime(txtDe.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtAte.Text + " 23:59");

            if(checkBox2.Checked)
            {
                de = Convert.ToDateTime("01/01/2000 00:00");
                ate = Convert.ToDateTime("01/01/2050 23:59");
            }

            string Situacao = cboSituacao.Text;
            string ordem = "";

            if (rbNome.Checked) ordem = "nome";
            if (rbDocumento.Checked) ordem = "documento";
            if (rbEmissao.Checked) ordem = "emissao";
            if (rbVencimento.Checked) ordem = "vencimento";

            var lista = dal.getByParams(de, ate, Situacao, txtNota.Text, txtNome.Text, ordem);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void frmBoleto_Load(object sender, EventArgs e)
        {
            txtDe.Text = DateTime.Now.ToShortDateString();
            txtAte.Text = DateTime.Now.ToShortDateString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DateTime de = Convert.ToDateTime(txtDe.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtAte.Text + " 23:59");

            if (checkBox2.Checked)
            {
                de = Convert.ToDateTime("01/01/2000 00:00");
                ate = Convert.ToDateTime("01/01/2050 23:59");
            }

            string Situacao = cboSituacao.Text;
            List<FiltroRelatorio> ff = new List<FiltroRelatorio>();
            ff.Add(new FiltroRelatorio() { Nome = "de", Valor = de.ToString("yyyyMMdd") });
            ff.Add(new FiltroRelatorio() { Nome = "ate", Valor = ate.ToString("yyyyMMdd") });
            ff.Add(new FiltroRelatorio() { Nome = "situacao", Valor = cboSituacao.Text });
            ff.Add(new FiltroRelatorio() { Nome = "nota", Valor = txtNota.Text });
            ff.Add(new FiltroRelatorio() { Nome = "nome", Valor = txtNome.Text });

            frmVisualizar frmv = new frmVisualizar("BoletosLista");
            frmv.FiltrosRelatorio = ff;
            frmv.ShowDialog();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            int lote = 0;
            
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    if (dr.Cells["Lote"].Value != null && !String.IsNullOrEmpty(dr.Cells["Lote"].Value.ToString()))
                    {
                        if (lote == 0)
                        {
                            lote = Convert.ToInt32(dr.Cells["Lote"].Value.ToString());
                        }

                        if (lote != Convert.ToInt32(dr.Cells["Lote"].Value.ToString()))
                        {
                            MessageBox.Show("Boletos selecionados de distintos lotes.");
                            return;
                        }
                    }
                } 
            }


            int novolote = lote;
            if(novolote == 0)
            {
                novolote = dal.NovoLote();
            }
                 
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    int Id = Convert.ToInt32(dr.Cells[0].Value);
                    Models.Boleto bol = dal.GetByID(Id);
                    bol.Lote = novolote;
                    bol.Situacao = "Arquivo gerado";
                    dal.Update(bol);
                    dal.Save();
                }
            }

            //Gera o arquivo de texto
            BLL.BLBoletos bl = new BLL.BLBoletos(237, new Models.Boleto()); 
            var boletos = bl.getBoletosCollectionByLote(novolote);
            var config = new BoletoConfiguracoesDAL().getByBanco(237);
            var emit = new NFeEmitenteDAL().Get().ToList()[0];
            bl.GeraArquivoCNAB400(novolote, boletos, config, emit);
            CarregaGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                var bl = dal.GetByID(Id);
                frmBoletoCad frmc = new frmBoletoCad(bl);
                frmc.ShowDialog();
            }
            catch  
            {
                 
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells[1].Value = checkBox1.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("A data de vencimento não pode ser inferior a data de hoje");
                return;
            }

            if(MessageBox.Show("Confirma a mudança de data de vencimento dos boletos selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                dataGridView1.EndEdit(); 

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        int id = Convert.ToInt32(dr.Cells[0].Value);
                        dal.AtualizaVencimento(id, dateTimePicker1.Value);
                    }
                }
                CarregaGrid();
            }
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void rbDocumento_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void rbVencimento_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void rbEmissao_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
