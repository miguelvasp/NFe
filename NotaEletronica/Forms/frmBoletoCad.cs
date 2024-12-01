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
using System.IO;

namespace NotaEletronica.Forms
{
    public partial class frmBoletoCad : Form
    {
        public BoletoDAL dal = new BoletoDAL();
        Boleto b;
        public frmBoletoCad(Boleto pb)
        {
            b = pb;
            InitializeComponent();
        }

        private void frmBoletoCad_Load(object sender, EventArgs e)
        {
            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 10, Text = "Não Protestar" });
            cboCodigoInstrucao.DataSource = lista;
            cboCodigoInstrucao.DisplayMember = "Text";
            cboCodigoInstrucao.ValueMember = "iValue";

            if (b.IdBoleto == 0)
            {
                b.Situacao = "Digitação";
                dal.Insert(b);
                dal.Save();
            }

            CarregarDados();
        }

        private void CarregarDados()
        {
            txtCNome.Text = b.cedente_nome;
            txtCedenteCNPJ.Text = b.cedente_cpf;
            txtBanco.Text = b.numeroBanco.ToString();
            txtAgencia.Text = b.cedente_agencia;
            txtDVAgencia.Text = b.cedente_digitoagencia;
            txtConta.Text = b.cedente_conta;
            txtDVConta.Text = b.cedente_digitoconta;
            txtCodCedente.Text = b.cedente_codigo;
            txtSNome.Text = b.sacado_nome;
            txtSDocumento.Text = b.sacado_cpf;
            txtSEndereco.Text = b.sacado_endereco;
            txtCidade.Text = b.sacado_cidade;
            txtBairro.Text = b.sacado_bairro;
            txtCEP.Text = b.sacado_cep;
            txtUF.Text = b.sacado_uf;
            txtNossoNumero.Text = b.NossoNumero;
            txtDocumento.Text = b.NumeroDocumento;
            txtValorDocumento.Text = b.ValorBoleto.ToString();
            txtEmissao.Text = b.Emissao.ToString();
            txtVencimento.Text = b.Vencimento.ToString();
            txtDataProcessamento.Text = b.Processamento == null ? "" : b.Processamento.ToString();
            cboCodigoInstrucao.SelectedValue = b.Instrucao.ToString();
            txtnroDias.Text = b.nroDias.ToString();
            txtCarteira.Text = b.Carteira;
            txtModalidade.Text = "";
            txtConvenio.Text = b.Convenio;
            txtInstrucoes.Text = b.InstrucaoDescricao2;
            txtInstrucoes2.Text = b.InstrucaoDescricao3;
            lbStatus.Text = "Status: " + b.Situacao;
            lbBoleto.Text = b.IdBoleto.ToString().PadLeft(8, '0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                b.InstrucaoDescricao2 = txtInstrucoes.Text;
                b.InstrucaoDescricao3 = txtInstrucoes2.Text;
                b.Instrucao = Convert.ToInt32(cboCodigoInstrucao.SelectedValue);
                b.nroDias = Convert.ToInt32(txtnroDias.Text);
                b.Vencimento = Convert.ToDateTime(txtVencimento.Text);
                if (!string.IsNullOrEmpty(txtDataProcessamento.Text))
                {
                    b.Processamento = Convert.ToDateTime(txtDataProcessamento.Text);
                }
                if (b.IdBoleto == 0)
                {
                    dal.Insert(b);
                }
                else
                {
                    dal.Update(b);
                }
                dal.Save();
                MessageBox.Show("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (b.IdBoleto == 0)
                {
                    MessageBox.Show("Salve os dados antes de imprimir o boleto!");
                    return;
                }

                BLL.BLBoletos bl = new BLL.BLBoletos(b.numeroBanco, b);
                byte[] arrBytes = bl.BradescoPDF();
                string myTempFile = Path.Combine(Path.GetTempPath(), b.IdBoleto.ToString().PadLeft(8, '0') + ".pdf");
                File.WriteAllBytes(myTempFile, arrBytes);

                if (File.Exists(myTempFile))
                {
                    System.Diagnostics.Process.Start(myTempFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (b.IdBoleto == 0)
                {
                    MessageBox.Show("Salve os dados antes de imprimir o boleto!");
                    return;
                }

                BLL.BLBoletos bl = new BLL.BLBoletos(b.numeroBanco, b);
                byte[] arrBytes = bl.BradescoPDF();
                string myTempFile = Path.Combine(Path.GetTempPath(), b.IdBoleto.ToString().PadLeft(8, '0') + ".pdf");
                File.WriteAllBytes(myTempFile, arrBytes);

                if (File.Exists(myTempFile))
                {
                    var param = new NFeParametroDAL().Get().ToList()[0];

                    NFeDAL ndal = new NFeDAL();
                    var emailDados = ndal.GetByID(Convert.ToInt32(b.IdDocumentoEletronico));

                    //Monta o email
                    TEmail em = new TEmail();
                    em.de = param.eEmail;


                    em.para = emailDados.dest_email;
                    em.Anexo = myTempFile;
                    em.Assunto = "Editora Andrei - Efetue seu pagamento.";
                    em.Mensagem = "Olá " + emailDados.dest_xNome;
                    em.Mensagem += "\r\nSegue em anexo cobrança referente a nota fiscal " + emailDados.ide_nNF.ToString();

                    em.Mensagem += "\r\n\r\nPara efetuar o pagamento, você precisará pagar o boleto bancário em anexo no caixa do banco local ou na internet.";
                    em.Mensagem += "\r\n\r\nSe você tiver alguma pergunta em relação ao seu pagamento, entre em contato conosco pelo e-mail vendas@editora-andrei ou pelo telefone  +55 11 3223-5111";
                    frmEnviaEmail frmem = new frmEnviaEmail(em);
                    frmem.ShowDialog();
                    dal.Update(b);
                    dal.Save();

                }
                else
                {
                    MessageBox.Show("Não foi possível gerar o boleto, por favor verifique as permissões do seu usuário no computador.");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível gerar o boleto, por favor verifique as permissões do seu usuário no computador ou verifique se o arquivo pdf referente ao boleto está aberto em algum programa.");
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            b.Situacao = "Confirmado";
            b.Processamento = DateTime.Now;
            dal.Update(b);
            dal.Save();
        }

        private void btnCancelaPagamento_Click(object sender, EventArgs e)
        {
            b.Situacao = "Cancelado";
            b.Processamento = DateTime.Now;
            dal.Update(b);
            dal.Save();
        }
    }
}
