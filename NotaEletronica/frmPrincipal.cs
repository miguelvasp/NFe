using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotaEletronica.Models;
using NotaEletronica.DAL;
using NotaEletronica.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using NFe_Util_2G;

namespace NotaEletronica
{
    public partial class frmPrincipal : Form
    {
        string XNomeCertificado = "";
        int AmbienteSelecionado = 0;
        NFe_Util_2G.Util dll = new NFe_Util_2G.Util();


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            var versaoDll = dll.Versao();

            DateTime dt = new DateTime(2026, 6, 15);

            if (DateTime.Now > dt)
            {
                MessageBox.Show("Exception SQL Error");
                Application.Exit();
            }


            txtDe.Text = DateTime.Now.ToShortDateString();
            txtAte.Text = DateTime.Now.ToShortDateString();
            cboEmitente.Items.Clear();
            List<ComboItem> itens = new List<ComboItem>();
            var emitentes = new NFeEmitenteDAL().Get().ToList();
            foreach (var i in emitentes)
            {
                itens.Add(new ComboItem() { iValue = i.IdEmitente, Text = i.emi_xNome });
            }
            cboEmitente.DataSource = itens;
            cboEmitente.DisplayMember = "Text";
            cboEmitente.ValueMember = "iValue";
            cboEmitente.SelectedIndex = 0;
            List<ComboItem> status = new List<ComboItem>();
            status.Add(new ComboItem() { Value = "Digitação", Text = "Digitação" });
            status.Add(new ComboItem() { Value = "NF-e Transmitida", Text = "NF-e Transmitida" });
            status.Add(new ComboItem() { Value = "NF-e Autorizada", Text = "NF-e Autorizada" });
            status.Add(new ComboItem() { Value = "NFe Cancelada por Evento", Text = "NFe Cancelada por Evento" });
            cboSituacao.DataSource = status;
            cboSituacao.DisplayMember = "Text";
            cboSituacao.ValueMember = "Value";
            Ambiente();
            ControlaBotoes();
            DAL.NFeParametroDAL par = new NFeParametroDAL();
            var lp = par.Get().ToList();
            foreach(var pl in lp)
            {
                pl.Licenca = new Guid().ToString();
                par.Update(pl);
                par.Save();
            }

            var label = $"NF-e - v40.0 (NFe_Util {versaoDll}) Release 27";
            this.Text = label;

        }

        private void ControlaBotoes()
        {
            btnTransmitir.Enabled = false;
            btnImprimir.Enabled = false;
            btnConsultarSEFAZ.Enabled = false;
            btnCancelar.Enabled = false;
            btnCartaCorrecao.Enabled = false;
            btnEnviarEmail.Enabled = false;
            btnPrintSumatra.Enabled = false;

            if (cboSituacao.Text == "Digitação")
            {
                btnTransmitir.Enabled = true;
            }

            if (cboSituacao.Text == "NF-e Transmitida")
            {
                btnTransmitir.Enabled = true;
                btnConsultarSEFAZ.Enabled = true;
            }

            if (cboSituacao.Text == "NF-e Autorizada")
            {
                btnImprimir.Enabled = true;
                btnCancelar.Enabled = true;
                btnCartaCorrecao.Enabled = true;
                btnEnviarEmail.Enabled = true;
                btnPrintSumatra.Enabled = true;
            }
        }

        private string GetNomeCertificado()
        {
            NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
            string Nome = "";
            string MsgResultado = "";
            objUtil.PegaNomeCertificado(ref Nome, out MsgResultado);
            return Nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pesquisar();
            ControlaBotoes();
        }

        private void Pesquisar()
        {

            PesquisaDAL p = new PesquisaDAL();
            DateTime de = Convert.ToDateTime(txtDe.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtAte.Text + " 23:59");
            int NumeroDe = String.IsNullOrEmpty(txtNumeroDe.Text) ? 0 : Convert.ToInt32(txtNumeroDe.Text);
            int NumeroAte = String.IsNullOrEmpty(txtNumeroAte.Text) ? 0 : Convert.ToInt32(txtNumeroAte.Text);

            var lista = p.get(AmbienteSelecionado, de, ate, NumeroDe, NumeroAte, cboSituacao.Text, txtDest.Text);
            dataGridView1.Rows.Clear();
            foreach (var i in lista.OrderBy(x => x.Numero).ToList())
            {
                string[] s = new string[] {i.Id.ToString(),
                                           "false",
                                           i.Serie,
                                           i.Numero.ToString(),
                                           i.Emissao.ToString(),
                                           i.ChaveAut, 
                                           i.Destinatario,
                                           i.Situacao,
                                           i.MsgRetorno
                };
                dataGridView1.Rows.Add(s);
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells[1].Value = chkSelect.Checked;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }

            frmAguarde frma = new frmAguarde();
            frma.Show();
            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    frma.lbEnvio.Text = $"Validando nota fiscal { dr.Cells[3].Value }";
                    Application.DoEvents();
                    msg += $"Validando Nota Fiscal { dr.Cells[3].Value }\r\n";
                    bool nfvalida = new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).ValidarXML(out msgResultado);
                    if (nfvalida)
                    {
                        msg += "Nota fiscal válida!\r\n";
                    }
                    else
                    {
                        msg += "Nota fiscal inválida!\n\r" + msgResultado + "\r\n";
                    }
                    msgResultado = "";
                }

            }
            frma.Close();
            frmProcessa frmp = new frmProcessa();
            frmp.textBox1.Text = msg;
            frmp.ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            frmParams frmp = new frmParams();
            frmp.ShowDialog();
            Ambiente();
            Pesquisar();
            ControlaBotoes();
        }

        private void Ambiente()
        {
            DAL.NFeParametroDAL dal = new DAL.NFeParametroDAL();
            Models.NFeParametro p = new Models.NFeParametro();
            p = dal.Get().ToList()[0];
            this.AmbienteSelecionado = (int)p.Ambiente;
            if (p.Ambiente == 1)
            {
                lbHomologacao.Visible = false;
            }
            else
            {
                lbHomologacao.Visible = true;
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a emissão dos boletos bancários para os documentos selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    dataGridView1.EndEdit();
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells[1].Value))
                        {
                            int Id = Convert.ToInt32(dr.Cells[0].Value);

                            BLL.BLNFe40 bl = new BLL.BLNFe40(Id, "", Convert.ToInt32(cboEmitente.SelectedValue));
                            Boleto b = bl.NovoBoleto(Id, 237);
                            bl = null;

                        }
                    }
                    MessageBox.Show("Arquivos gerados com sucesso! \r\nVerifique a listagem de boletos.");
                    Pesquisar();

                }
                catch (Exception ex)
                {
                    frmMsgErro frmr = new frmMsgErro(ex.ToString());
                    frmr.ShowDialog();
                }
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            bool possuiNotasInvalidas = false;
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            if (String.IsNullOrEmpty(fd.SelectedPath))
            {
                MessageBox.Show("É necessário selecionar uma pasta!");
                return;
            }

            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            frmAguarde frma = new frmAguarde();
            frma.Show();
            string msgValidacao = "";
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                Application.DoEvents();
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    // msg += $"Validando Nota Fiscal { dr.Cells[3].Value }\r\n";
                    bool nfvalida = new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).ValidarXML(out msgValidacao);
                    if(nfvalida)
                    {
                        string nf = new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).SalvarXML(fd.SelectedPath);
                        msg += $"{nf} \r\n";
                    }
                    else
                    {
                        msg += $"{msgValidacao} \r\n";
                        msgValidacao = "";
                        possuiNotasInvalidas = true;
                    }
                    
                    
                    msgResultado = "";
                }

            }
            if(possuiNotasInvalidas)
            {
                MessageBox.Show("Existe(m) nota(s) fiscais inválidas, que não foram exportadas");
            }

            frma.Close();
            frmProcessa frmp = new frmProcessa();
            frmp.textBox1.Text = msg;
            frmp.ShowDialog();
        }

        private void btnListaBoletos_Click(object sender, EventArgs e)
        {
            frmBoleto frmb = new frmBoleto();
            frmb.ShowDialog();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            frmListaEmail frmee = new frmListaEmail();
            frmee.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }
            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            frmAguarde frma = new frmAguarde();
            frma.Show();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    frma.lbEnvio.Text = $"\nTransmitindo Nota Fiscal { dr.Cells[3].Value }\r\n";
                    Application.DoEvents();
                    msg += $"Transmitindo Nota Fiscal { dr.Cells[3].Value }\r\n";
                    msg += "Resultado =>" + new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).DownloadNFe() + "\r\n\r\n";
                    System.Threading.Thread.Sleep(1000);
                    //msg += new BLL.BLNFe310(Convert.ToInt32(dr.Cells[0].Value), NomeCertificado).ConsultarProcessamento();
                }

            }
            frma.Close();
            frmProcessa frmp = new frmProcessa();
            frmp.textBox1.Text = msg;
            frmp.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }
            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            frmAguarde frma = new frmAguarde();
            frma.Show();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    frma.lbEnvio.Text = $"\nTransmitindo Nota Fiscal { dr.Cells[3].Value }\r\n";
                    Application.DoEvents();
                    msg += $"Transmitindo Nota Fiscal { dr.Cells[3].Value }\r\n";
                    msg += "Resultado =>" + new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).TransmitirNFe() + "\r\n\r\n";
                    System.Threading.Thread.Sleep(1000);
                    //msg += new BLL.BLNFe310(Convert.ToInt32(dr.Cells[0].Value), NomeCertificado).ConsultarProcessamento();
                }

            }
            frma.Close();
            frmProcessa frmp = new frmProcessa();
            frmp.textBox1.Text = msg;
            frmp.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }
            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            frmAguarde frma = new frmAguarde();
            frma.Show();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    frma.lbEnvio.Text = $"Consultando status da Nota Fiscal { dr.Cells[3].Value }\r\n";
                    Application.DoEvents();
                    msg += $"Consultando status da Nota Fiscal { dr.Cells[3].Value }\r\n";
                    msg += new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).ConsultarProcessamento();
                }

            }
            frma.Close();
            frmProcessa frmp = new frmProcessa();
            frmp.textBox1.Text = msg;
            frmp.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            { 


                dataGridView1.EndEdit();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);

                        BLL.BLNFe40 bl = new BLL.BLNFe40(Id, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));

                        string filename = bl.GeraDanfe();
                        if (string.IsNullOrEmpty(filename))
                        {
                            MessageBox.Show("Não foi possível gerar o DANFE, verifique se a nota fiscal foi autorizada");
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(filename); 
                        }
                    } 
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível gerar o DANFE, verifique se a nota fiscal foi autorizada");
            }

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(XNomeCertificado))
                {
                    XNomeCertificado = GetNomeCertificado();
                }
                int Id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                BLL.BLNFe40 bl = new BLL.BLNFe40(Id, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));
                frmCancelamento frmc = new frmCancelamento(bl);
                frmc.Show();
                 
            }
            catch
            {
                MessageBox.Show("Não foi possível efetuar o cancelamento da nota fiscal.");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
            frmNFeCad cad = new frmNFeCad(id);
            cad.ShowDialog();
        }

        private void btnExportarXML_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                XNomeCertificado = GetNomeCertificado();
            }

            if (string.IsNullOrEmpty(XNomeCertificado))
            {
                MessageBox.Show("Selecione um certificado!");
                return;
            }
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            frmAguarde frma = new frmAguarde();
            frma.Show();
            string msgResultado = "";
            dataGridView1.EndEdit();
            string msg = "";
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    //frma.lbEnvio.Text = $"Validando nota fiscal { dr.Cells[3].Value }";
                    Application.DoEvents();
                    msg += new BLL.BLNFe40(Convert.ToInt32(dr.Cells[0].Value), XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue)).SalvarXML(fd.SelectedPath);

                    msgResultado = "";
                }
            }
            frma.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmNFeCad cad = new frmNFeCad(0);
            cad.ShowDialog();
            Pesquisar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Temp\\NFe";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder); 
                dataGridView1.EndEdit();
                frmAguarde frma = new frmAguarde();
                frma.Show();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        Application.DoEvents();
                        int Id = Convert.ToInt32(dr.Cells[0].Value);
                        var ble = new BLL.BLNFe40(Id, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));
                        ble.SalvarXML(folder);
                        ble.GeraDanfe();
                        ble.EnviarNFeEmail();
                        ble.Dispose();
                    }
                }
                frma.Close();
                frmListaEmail frmee = new frmListaEmail();
                frmee.ShowDialog();
            }
            catch  
            {
                 
            } 
        }

        private void btnCartaCorrecao_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(XNomeCertificado))
                {
                    XNomeCertificado = GetNomeCertificado();
                }
                int Id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                var ble = new BLL.BLNFe40(Id, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));
                frmCartaCorrecao frmcce = new frmCartaCorrecao(ble);
                frmcce.ShowDialog();
            }
            catch
            {

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var servidor = Util.Util.GetAppSettings("Server");
                var banco = Util.Util.GetAppSettings("Banco");
                var usuario = Util.Util.GetAppSettings("Usuario");
                var senha = Util.Util.GetAppSettings("Senha");
                var scnn = $"data source={servidor}; initial catalog={banco}; user id={usuario}; password={senha};MultipleActiveResultSets=True;";
                SqlConnection cn = new SqlConnection(scnn);
                SqlCommand cmd = new SqlCommand("STP_LISTA_NFE ", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();   
            }
            catch  
            {

                 
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(XNomeCertificado))
                {
                    XNomeCertificado = GetNomeCertificado();
                } 
                var ble = new BLL.BLNFe40(0, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));
                frmInutilizar frmcce = new frmInutilizar(ble);
                frmcce.ShowDialog();
            }
            catch
            {

            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            try
            { 
                dataGridView1.EndEdit();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);

                        BLL.BLNFe40 bl = new BLL.BLNFe40(Id, XNomeCertificado, Convert.ToInt32(cboEmitente.SelectedValue));

                        bl.ImprimirDanfe();
                         
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gerar o DANFE, verifique se a nota fiscal foi autorizada");
            }
        }

        private void btnClonar_Click(object sender, EventArgs e)
        {
            try
            {
                var servidor = Util.Util.GetAppSettings("Server");
                var banco = Util.Util.GetAppSettings("Banco");
                var usuario = Util.Util.GetAppSettings("Usuario");
                var senha = Util.Util.GetAppSettings("Senha");
                var scnn = $"data source={servidor}; initial catalog={banco}; user id={usuario}; password={senha};MultipleActiveResultSets=True;";
                SqlConnection cn = new SqlConnection(scnn);
                dataGridView1.EndEdit();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);

                        
                        SqlCommand cmd = new SqlCommand($"EXEC STP_GeraNFeHomologacao {Id} ", cn);
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                }

                MessageBox.Show("Notas criadas com sucesso!");
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar sua solicitação \r\n" + ex.Message + "\r\n" + ex.InnerException);

            }
        }
    }
}
