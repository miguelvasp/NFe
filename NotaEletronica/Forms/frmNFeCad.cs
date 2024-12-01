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
    public partial class frmNFeCad : Form
    {
        NFe n = new NFe();
        public NFeDAL dal = new NFeDAL();
        NFeProdutoDAL pdal = new NFeProdutoDAL();
        bool Bloqueada = false;
        NFeEmitenteDAL edal = new NFeEmitenteDAL();
        NFeXMLDAL xdal = new NFeXMLDAL();
        NFeXML arquivos = new NFeXML();
        NFeEmitente emit = new NFeEmitente();
        public frmNFeCad(int pId = 0)
        {
            n = dal.GetByID(pId);
            emit = new NFeEmitenteDAL().GetByID(1);
            arquivos = xdal.getByNFeId(pId);
            if(arquivos == null)
            {
                arquivos = new NFeXML();
            }
            if(n == null)
            {
                n = new NFe();
                n.NFeStatus = "Digitação";
                n.ide_dEmi = DateTime.Now;
                n.ide_nNF = dal.getNovaNota() + 1;
                n.ide_indFinal = 1;
                n.ide_tpEmis = 1;
            }
            InitializeComponent();
            if (arquivos.CCeXML != null)
                btnCCe.Visible = true;
            else
                btnCCe.Visible = false;

        }

        private void frmNFeCad_Load(object sender, EventArgs e)
        { 
            if(n.NFeStatus != null && (n.NFeStatus == "NF-e Autorizada" || n.NFeStatus == "NFe Cancelada por Evento"))
            {
                Bloqueada = true;
                toolStripButton1.Enabled = false;
            }
            else
            {
                toolStripButton1.Enabled = true;
            }


            Util.Combos c = new Util.Combos();
            cboide_tpNF.DataSource = c.cbotpNF();
            cboide_tpNF.DisplayMember = "Text";
            cboide_tpNF.ValueMember = "iValue";

            cboide_finNFe.DataSource = c.finNFe();
            cboide_finNFe.DisplayMember = "Text";
            cboide_finNFe.ValueMember = "iValue";
            cboide_finNFe.SelectedIndex = -1;

            cboide_indFinal.DataSource = c.indFinal();
            cboide_indFinal.DisplayMember = "Text";
            cboide_indFinal.ValueMember = "iValue";
            cboide_indFinal.SelectedIndex = -1;

            cboide_indPres.DataSource = c.indPres();
            cboide_indPres.DisplayMember = "Text";
            cboide_indPres.ValueMember = "iValue";
            cboide_indPres.SelectedIndex = -1;

            cbodest_cMun.DataSource = c.Municipios();
            cbodest_cMun.DisplayMember = "Text";
            cbodest_cMun.ValueMember = "iValue";
            cbodest_cMun.SelectedIndex = -1;

            cbodest_cPais.DataSource = c.Paises();
            cbodest_cPais.DisplayMember = "Text";
            cbodest_cPais.ValueMember = "iValue";
            cbodest_cPais.SelectedIndex = -1;

            cbodest_indIEDest.DataSource = c.getindIEDest();
            cbodest_indIEDest.DisplayMember = "Text";
            cbodest_indIEDest.ValueMember = "iValue";
            cbodest_indIEDest.SelectedIndex = -1;

            cbotra_modFrete.DataSource = c.getmodFrete();
            cbotra_modFrete.DisplayMember = "Text";
            cbotra_modFrete.ValueMember = "iValue";
            cbotra_modFrete.SelectedIndex = -1;

            cbopagTpag.DataSource = c.gettpPag();
            cbopagTpag.DisplayMember = "Text";
            cbopagTpag.ValueMember = "Value";
            cbopagTpag.SelectedIndex = -1;

            CarregaDados();
        }

        private void CarregaDados()
        {
            txtide_nNF.Text = n.ide_nNF.ToString();
            txtide_serie.Text = n.ide_serie;
            txtide_dEmi.Text = n.ide_dEmi.ToString();
            txtide_natOp.Text = n.ide_natOp;
            cboide_tpNF.SelectedValue = n.ide_tpNF == null ? 0 : n.ide_tpNF;
            cboide_indFinal.SelectedValue = n.ide_indFinal == null ? 0 : n.ide_indFinal;
            cboide_finNFe.SelectedValue = n.ide_finNFe == null ? 0 : n.ide_finNFe;
            cboide_indPres.SelectedValue = n.ide_indPres == null ? 0 : n.ide_indPres;
            txtIdeNFRef.Text = n.ide_NFref;

            //Destinatário
            txtdest_CNPJ.Text = n.dest_CNPJ;
            txtdest_CPF.Text = n.dest_CPF;
            txtdest_xNome.Text = n.dest_xNome;
            txtdest_xFant.Text = n.dest_xFant;
            txtdest_xlgr.Text = n.dest_xlgr;
            txtdest_nro.Text = n.dest_nro;
            txtdest_xCpl.Text = n.dest_xCpl;
            txtdest_xBairro.Text = n.dest_xBairro;
            txtdest_UF.Text = n.dest_UF;
            cbodest_cMun.SelectedValue = string.IsNullOrEmpty(n.dest_cMun) ? 0 : Convert.ToInt32(n.dest_cMun);
            txtdest_CEP.Text = n.dest_CEP;
            cbodest_cPais.SelectedValue = string.IsNullOrEmpty(n.dest_cPais) ? 0 : Convert.ToInt32(n.dest_cPais);
             
            txtdest_fone.Text = n.dest_fone;
            txtdest_email.Text = n.dest_email;
            txtdest_IE.Text = n.dest_IE;
            cbodest_indIEDest.SelectedValue = string.IsNullOrEmpty(n.dest_indIEDest) ? 0 : Convert.ToInt32(n.dest_indIEDest);
            txtdest_IdExtrangeiro.Text = n.dest_IdExtrangeiro;

            txtUFSaidaPais.Text = n.UFSaidaPais;
            txtxLocEmbarq.Text = n.xLocEmbarq;


            //transporte
            cbotra_modFrete.SelectedValue = string.IsNullOrEmpty(n.tra_modFrete) ? -1 : Convert.ToInt32(n.tra_modFrete);
            txttra_CNPJ.Text = n.tra_CNPJ;
            txttra_CPF.Text = n.tra_CPF;
            txttra_xNome.Text = n.tra_xNome;
            txttra_IE.Text = n.tra_IE;
            txttra_xEnder.Text = n.tra_xEnder;
            txttra_xMun.Text = n.tra_xMun;
            txttra_UF.Text = n.tra_UF;
            txtveic_Placa.Text = n.veic_Placa;
            txtveic_UF.Text = n.veic_UF;
            txtveic_RNTC.Text = n.veic_RNTC;
            txtvol_qVol.Text = n.vol_qVol == null ? "" : n.vol_qVol.ToString();
            txtvol_esp.Text = n.vol_esp;
            txtvol_Marca.Text = n.vol_Marca;
            txtvol_nVol.Text = n.vol_nVol;
            txtvol_pesoL.Text = n.vol_pesoL == null ? "" : n.vol_pesoL.ToString();
            txtvol_pesoB.Text = n.vol_pesoB == null ? "" : n.vol_pesoB.ToString();


            //Totais
            txttot_vBC.Text = n.tot_vBC.ToString();
            txttot_vICMS.Text = n.tot_vICMS.ToString();
            txttot_vBCST.Text = n.tot_vBCST.ToString();
            txttot_vST.Text = n.tot_vST.ToString();
            txttot_vProd.Text = n.tot_vProd.ToString();
            txttot_vFrete.Text = n.tot_vFrete.ToString();
            txttot_vSeg.Text = n.tot_vSeg.ToString();
            txttot_vDesc.Text = n.tot_vDesc.ToString();
            txttot_vII.Text = n.tot_vII.ToString();
            txttot_vIPI.Text = n.tot_vIPI.ToString();
            txttot_vPIS.Text = n.tot_vPIS.ToString();
            txttot_vCOFINS.Text = n.tot_vCOFINS.ToString();
            txttot_vOutro.Text = n.tot_vOutro.ToString();
            txttot_vNF.Text = n.tot_vNF.ToString();
            txttot_vTotTrib.Text = n.tot_vTotTrib.ToString();
            txttot_vICMSDeson.Text = n.tot_vICMSDeson.ToString();
            txttot_vICMSUFDest_Opc.Text = n.tot_vICMSUFDest_Opc.ToString();
            txttot_vICMSUFRemet.Text = n.tot_vICMSUFRemet.ToString();
            txttot_vFCPUFDest.Text = n.tot_vFCPUFDest.ToString();
            txttot_vFCP.Text = n.tot_vFCP.ToString();
            txttot_vFCPST.Text = n.tot_vFCPST.ToString();
            txttot_vFCPSTRet.Text = n.tot_vFCPSTRet.ToString();
            txttot_vIPIDevol.Text = n.tot_vIPIDevol.ToString(); 
            txtinfAdic.Text = n.infAdic;
            txtChaveAut.Text = n.ChaveAut;
            txtRecibo.Text = n.Recibo;
            txtProtocolo.Text = n.Protocolo;
            txtDataAutorizacao.Text = n.DtAutorizacao.ToString();
            txtmsgRetorno.Text = n.MsgRetorno;
            txtProtocoloCancelamento.Text = n.ProtocoloCancelamento;
            txtDataCancelamento.Text = n.DtCancelamento.ToString();
            txtJustificativa.Text = n.Justificativa;
            txtStatusNFe.Text = n.NFeStatus;

            cbopagTpag.SelectedValue = n.pag_tPag == null ? "" : n.pag_tPag;
            txtpagvPag.Text = n.pag_vPag == null ? "0,00" : n.pag_vPag.ToString();
            CarregaProdutos();
        }
         
        private void CarregaProdutos()
        {
            var lista = new NFeProdutoDAL().getByIdNFe(n.IdNFe);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista; 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Identificador
            if (!string.IsNullOrEmpty(txtide_nNF.Text))
            {
                n.ide_nNF = Convert.ToInt32(txtide_nNF.Text);
                n.ide_serie = txtide_serie.Text;
                n.ide_dEmi = Convert.ToDateTime(txtide_dEmi.Text);
                n.ide_natOp = txtide_natOp.Text;

                if (!string.IsNullOrEmpty(cboide_tpNF.Text))
                {
                    n.ide_tpNF = Convert.ToInt32(cboide_tpNF.SelectedValue);
                }

                if (!string.IsNullOrEmpty(cboide_indFinal.Text))
                {
                    n.ide_indFinal = Convert.ToInt32(cboide_indFinal.SelectedValue);
                }

                if (!string.IsNullOrEmpty(cboide_finNFe.Text))
                {
                    n.ide_finNFe = Convert.ToInt32(cboide_finNFe.SelectedValue);
                }

                if (!string.IsNullOrEmpty(cboide_indPres.Text))
                {
                    n.ide_indPres = Convert.ToInt32(cboide_indPres.SelectedValue);
                }
            }

            n.ide_NFref = txtIdeNFRef.Text;


            //Destinatário
            n.dest_CNPJ = txtdest_CNPJ.Text;
            n.dest_CPF = txtdest_CPF.Text;
            n.dest_xNome = txtdest_xNome.Text;
            n.dest_xFant = txtdest_xFant.Text;
            n.dest_xlgr = txtdest_xlgr.Text;
            n.dest_nro = txtdest_nro.Text;
            n.dest_xCpl = txtdest_xCpl.Text;
            n.dest_xBairro = txtdest_xBairro.Text;
            n.dest_UF = txtdest_UF.Text;
            if (!string.IsNullOrEmpty(cbodest_cMun.Text))
            {
                n.dest_cMun = cbodest_cMun.SelectedValue.ToString();
                n.dest_xMun = cbodest_cMun.Text;
            }
            n.dest_CEP = txtdest_CEP.Text;
            if (!string.IsNullOrEmpty(cbodest_cPais.Text))
            {
                n.dest_cPais = cbodest_cPais.SelectedValue.ToString();
                n.dest_xPais = cbodest_cPais.Text;
            }

            n.dest_fone = txtdest_fone.Text;
            n.dest_email = txtdest_email.Text;
            n.dest_IE = txtdest_IE.Text;
            if (!String.IsNullOrEmpty(cbodest_indIEDest.Text))
            {
                n.dest_indIEDest = cbodest_indIEDest.SelectedValue.ToString();
            }
            n.dest_IdExtrangeiro = txtdest_IdExtrangeiro.Text;
            n.UFSaidaPais = txtUFSaidaPais.Text;
            n.xLocEmbarq = txtxLocEmbarq.Text;
             
            //transporte
            if (!string.IsNullOrEmpty(cbotra_modFrete.Text))
            {
                n.tra_modFrete = cbotra_modFrete.SelectedValue.ToString();
            }
            n.tra_CNPJ = txttra_CNPJ.Text;
            n.tra_CPF = txttra_CPF.Text;
            n.tra_xNome = txttra_xNome.Text;
            n.tra_IE = txttra_IE.Text;
            n.tra_xEnder = txttra_xEnder.Text;
            n.tra_xMun = txttra_xMun.Text;
            n.tra_UF = txttra_UF.Text;
            n.veic_Placa = txtveic_Placa.Text;
            n.veic_UF = txtveic_UF.Text;
            n.veic_RNTC = txtveic_RNTC.Text;
            n.vol_qVol = Util.Util.IsNumberZero(txtvol_qVol.Text);
            n.vol_esp = txtvol_esp.Text;
            n.vol_Marca = txtvol_Marca.Text;
            n.vol_nVol = txtvol_nVol.Text;
            n.vol_pesoL = Util.Util.IsNumberZero(txtvol_pesoL.Text);
            n.vol_pesoB = Util.Util.IsNumberZero(txtvol_pesoB.Text);


            //Totais
            n.tot_vBC = Util.Util.IsNumberZero(txttot_vBC.Text);
            n.tot_vICMS = Util.Util.IsNumberZero(txttot_vICMS.Text);
            n.tot_vBCST = Util.Util.IsNumberZero(txttot_vBCST.Text);
            n.tot_vST = Util.Util.IsNumberZero(txttot_vST.Text);
            n.tot_vProd = Util.Util.IsNumberZero(txttot_vProd.Text);
            n.tot_vFrete = Util.Util.IsNumberZero(txttot_vFrete.Text);
            n.tot_vSeg = Util.Util.IsNumberZero(txttot_vSeg.Text);
            n.tot_vDesc = Util.Util.IsNumberZero(txttot_vDesc.Text);
            n.tot_vII = Util.Util.IsNumberZero(txttot_vII.Text);
            n.tot_vIPI = Util.Util.IsNumberZero(txttot_vIPI.Text);
            n.tot_vPIS = Util.Util.IsNumberZero(txttot_vPIS.Text);
            n.tot_vCOFINS = Util.Util.IsNumberZero(txttot_vCOFINS.Text);
            n.tot_vOutro = Util.Util.IsNumberZero(txttot_vOutro.Text);
            n.tot_vNF = Util.Util.IsNumberZero(txttot_vNF.Text);
            n.tot_vTotTrib = Util.Util.IsNumberZero(txttot_vTotTrib.Text);
            n.tot_vICMSDeson = Util.Util.IsNumberZero(txttot_vICMSDeson.Text);
            n.tot_vICMSUFDest_Opc = Util.Util.IsNumberZero(txttot_vICMSUFDest_Opc.Text);
            n.tot_vICMSUFRemet = Util.Util.IsNumberZero(txttot_vICMSUFRemet.Text);
            n.tot_vFCPUFDest = Util.Util.IsNumberZero(txttot_vFCPUFDest.Text);
            n.tot_vFCP = Util.Util.IsNumberZero(txttot_vFCP.Text);
            n.tot_vFCPST = Util.Util.IsNumberZero(txttot_vFCPST.Text);
            n.tot_vFCPSTRet = Util.Util.IsNumberZero(txttot_vFCPSTRet.Text);
            n.tot_vIPIDevol = Util.Util.IsNumberZero(txttot_vIPIDevol.Text);

            n.infAdic = txtinfAdic.Text;

            n.pag_tPag = cbopagTpag.SelectedValue == null ? "" : cbopagTpag.SelectedValue.ToString();

            if (n.pag_tPag == "90")
                txtpagvPag.Text = "0,00";
            n.pag_vPag = Util.Util.IsNumberZero(txtpagvPag.Text);

            //Preenche os campos padrão caso seja nota fiscal nova
            if (n.IdNFe == 0)
            {
                dal.Insert(n);
            }
            else
            {
                dal.Update(n);
            }

            dal.Save();

            NFe temp = new NFeDAL().GetByID(n.IdNFe);

            List<string> erros = Util.ValidadorNFe.Validar(temp);

            if(erros.Count > 0)
            {
                frmRecomendacoes frmr = new frmRecomendacoes(erros);
                frmr.ShowDialog();
            }

            MessageBox.Show("Dados salvos com sucesso!");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                NFeProduto prr = pdal.GetByID(Id);
                frmNFeProdutoCad pcad = new frmNFeProdutoCad(prr, Bloqueada, n.IdNFe);
                pcad.dal = pdal;
                pcad.ShowDialog();
                CarregaProdutos();
            }
            catch 
            {
                 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.RecalcularNFe(n.IdNFe);
            n = dal.GetByID(n.IdNFe);
            CarregaDados();
            CarregaProdutos();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int Id = 0;
            NFeProduto prr = pdal.GetByID(Id);
            if(prr == null)
            {
                prr = new NFeProduto();
                prr.IdNFe = n.IdNFe;
            }
            frmNFeProdutoCad pcad = new frmNFeProdutoCad(prr, Bloqueada, n.IdNFe);
            pcad.dal = pdal;
            pcad.ShowDialog();
        }

        private void btnCCe_Click(object sender, EventArgs e)
        {
            StringReader SR = new StringReader(arquivos.CCeXML);
            DataSet ds = new DataSet();
            ds.ReadXml(SR);

            DataTable dtInfEvento = ds.Tables["infEvento"];
            DataTable dtDetEvento = ds.Tables["detEvento"];

            string html = "";
            html += "<html>";
            html += "	<head></head> ";
            html += "	<body>";
            html += "		<div style='font-family: Arial, Helvetica, sans-serif'>";
            html += "			<table>";
            html += "				<tr>";
            html += "					<td style='width: 400px'>Razão Social:" + emit.emi_xNome + "</td>";
            html += "					<td style='text-align: right; width: 400px'>CNPJ: " + emit.emi_CNPJ + "</td>";
            html += "				</tr>";
            html += "				<tr> ";
            html += "					<td style='text-align: right; width: 400px'>Fone: " + emit.emi_Fone + "</td>";
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td style='font-weight: bold; font-size: 16px; text-align: center'>CCe - Carta de Correção Eletrônica</td>";
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td colspan='2'>Chave de Acesso: " + dtInfEvento.Rows[0]["chNFe"].ToString() + "</td>";
            html += "					<td>Ambiente:" + dtInfEvento.Rows[0]["tpAmb"].ToString() + "</td>";
            html += "				</tr>";
            html += "				<tr>";
            html += "					<td>Data: " + dtInfEvento.Rows[0]["dhEvento"].ToString() + "</td>";
            html += "					<td>Protocolo: " + dtInfEvento.Rows[1]["nProt"].ToString() + "</td>";  
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td style='font-weight: bold; font-size: 16px; text-align: center'>Informações da Carta de Correção Eletrônica</td>";
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td><strong>Texto da carta de correção</strong></td> ";
            html += "				</tr>";
            html += "				<tr  style='height: 400px; vertical-align: text-top'>";
            html += "					<td>" + dtDetEvento.Rows[0]["xCorrecao"].ToString() + "</td>";
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td style='font-weight: bold; font-size: 16px; text-align: center'>Condições de uso</td>";
            html += "				</tr>";
            html += "			</table>";
            html += "			<hr>";
            html += "			<table style='width: 100%'>";
            html += "				<tr>";
            html += "					<td>";
            html += "						A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada";
            html += "						para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis";
            html += "						que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao";
            html += "						ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de";
            html += "						emissao ou de saida.";
            html += "					</td>";
            html += "				</tr> ";
            html += "			</table>";
            html += "		</div> ";
            html += "	</body> ";
            html += "</html>";

            var pdf = Util.Util.PdfSharpConvert(html);
            string filePath = Path.GetTempPath() + txtide_nNF.Text + "-cce.pdf";
            File.WriteAllBytes(filePath, pdf);
            if(File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("Não foi possível gerar a impressão da carta de correção.");
            }
        }
    }
}
