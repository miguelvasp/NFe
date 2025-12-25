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

namespace NotaEletronica.Forms
{
    public partial class frmNFeProdutoCad : Form
    {
        NFeProduto p;
        int IdNFe;
        public NFeProdutoDAL dal = new NFeProdutoDAL();
        public frmNFeProdutoCad(NFeProduto n, bool Bloqueada = false, int pIdNFe = 0)
        {
            p = n;
            IdNFe = pIdNFe;
            InitializeComponent();
            if (Bloqueada)
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
            }
        }

        private void frmNFeProdutoCad_Load(object sender, EventArgs e)
        {
            Util.Combos c = new Util.Combos();
            //NCM.DataSource = c.getNCM();
            //NCM.DisplayMember = "Text";
            //NCM.ValueMember = "Value";
            //NCM.SelectedIndex = -1;
            CboCodigoSituacaoTributaria.DataSource = c.getCodigoSituacaoTributaria();
            CboCodigoSituacaoTributaria.DisplayMember = "Text";
            CboCodigoSituacaoTributaria.ValueMember = "Value";
            CboCodigoSituacaoTributaria.SelectedIndex = -1;

            CboCodigoClassificacaoTributaria.DataSource = c.getCodigoClassificacaoTributaria();
            CboCodigoClassificacaoTributaria.DisplayMember = "Text";
            CboCodigoClassificacaoTributaria.ValueMember = "Value";
            CboCodigoClassificacaoTributaria.SelectedIndex = -1;

            CEST.DataSource = c.getCEST();
            CEST.DisplayMember = "Text";
            CEST.ValueMember = "Value";
            CEST.SelectedIndex = -1;

            //CFOP.DataSource = c.getCFOP();
            //CFOP.DisplayMember = "Text";
            //CFOP.ValueMember = "Value";
            //CFOP.SelectedIndex = -1;

            indTot.DataSource = c.getindTot();
            indTot.DisplayMember = "Text";
            indTot.ValueMember = "iValue";
            indTot.SelectedIndex = -1;

            ICMS_origem.DataSource = c.getorig();
            ICMS_origem.DisplayMember = "Text";
            ICMS_origem.ValueMember = "Value";
            ICMS_origem.SelectedIndex = -1;

            ICMS_modBC.DataSource = c.getmodBC();
            ICMS_modBC.DisplayMember = "Text";
            ICMS_modBC.ValueMember = "iValue";
            ICMS_modBC.SelectedIndex = -1;

            ICMS_modBCST.DataSource = c.getmodBCST();
            ICMS_modBCST.DisplayMember = "Text";
            ICMS_modBCST.ValueMember = "iValue";
            ICMS_modBCST.SelectedIndex = -1;

            CarregarDados();
        }

        private void CarregarDados()
        {
            if (p.IdNFeProduto > 0)
            {
                cProd.Text = p.cProd;
                cEAN.Text = p.cEAN;
                xProd.Text = p.xProd;
                txtNCM.Text = p.NCM;
                CEST.SelectedValue = Util.Util.ToString(p.CEST);
                txtCFOP.Text = Util.Util.ToString(p.CFOP);
                uCom.Text = p.uCom;
                qCom.Text = Util.Util.ToString(p.qCom);
                vUnCom.Text = Util.Util.ToString(p.vUnCom);
                vProd.Text = Util.Util.ToString(p.vProd);
                cEANTrib.Text = p.cEANTrib;
                uTrib.Text = p.uTrib;
                qTrib.Text = Util.Util.ToString(p.qTrib);
                vUnTrib.Text = Util.Util.ToString(p.vUnTrib);
                vOutro.Text = Util.Util.ToString(p.vOutro);
                indTot.SelectedValue = p.indTot == null ? -1 : p.indTot;
                xPed.Text = p.xPed;
                ICMS_origem.SelectedValue = p.ICMS_origem;
                ICMS_CST.Text = p.ICMS_CST;
                ICMS_modBC.SelectedValue = p.ICMS_modBC == null ? -1 : p.ICMS_modBC;
                ICMS_redBC.Text = Util.Util.ToString(p.ICMS_redBC);
                ICMS_vBC.Text = Util.Util.ToString(p.ICMS_vBC);
                ICMS_pICMS.Text = Util.Util.ToString(p.ICMS_pICMS);
                ICMS_vICMS.Text = Util.Util.ToString(p.ICMS_vICMS);
                ICMS_modBCST.SelectedValue = p.ICMS_modBCST == null ? -1 : p.ICMS_modBCST;
                ICMS_pMVAST.Text = Util.Util.ToString(p.ICMS_pMVAST);
                ICMS_pRedBCST.Text = Util.Util.ToString(p.ICMS_pRedBCST);
                ICMS_vBCST.Text = Util.Util.ToString(p.ICMS_vBCST);
                ICMS_pST.Text = Util.Util.ToString(p.ICMS_pST);
                ICMS_vST.Text = Util.Util.ToString(p.ICMS_vST);
                ICMS_vBCSTRet.Text = Util.Util.ToString(p.ICMS_vBCSTRet);
                ICMS_vICMSSTRet.Text = Util.Util.ToString(p.ICMS_vICMSSTRet);
                ICMS_pCredSN.Text = Util.Util.ToString(p.ICMS_pCredSN);
                ICMS_vCredICMSSN.Text = Util.Util.ToString(p.ICMS_vCredICMSSN);
                IPI_CST.Text = p.IPI_CST;
                IPI_Enq.Text = p.IPI_Enq;
                IPI_pIpi.Text = Util.Util.ToString(p.IPI_pIpi);
                IPI_vIPI.Text = Util.Util.ToString(p.IPI_vIPI);
                PIS_CST.Text = p.PIS_CST;
                PIS_pPis.Text = Util.Util.ToString(p.PIS_pPis);
                PIS_vPis.Text = Util.Util.ToString(p.PIS_vPis);
                COFINS_CST.Text = p.COFINS_CST;
                COFINS_pCofins.Text = Util.Util.ToString(p.COFINS_pCofins);
                COFINS_vCofins.Text = Util.Util.ToString(p.COFINS_vCofins);
                infAdic.Text = p.infAdic;
                vFrete.Text = Util.Util.ToString(p.vFrete);
                vSeg.Text = Util.Util.ToString(p.vSeg);
                vDesc.Text = Util.Util.ToString(p.vDesc);
                IPI_vBC.Text = Util.Util.ToString(p.IPI_vBC);
                PIS_vBC.Text = Util.Util.ToString(p.PIS_vBC);
                COFINS_vBC.Text = Util.Util.ToString(p.COFINS_vBC);
                pis_qBCProd.Text = Util.Util.ToString(p.pis_qBCProd);
                pis_vAliqProd.Text = Util.Util.ToString(p.pis_vAliqProd);
                cofins_qBCProd.Text = Util.Util.ToString(p.cofins_qBCProd);
                cofins_vAliqProd.Text = Util.Util.ToString(p.cofins_vAliqProd);
                ipi_CNPJProd.Text = p.ipi_CNPJProd;
                ipi_cSelo.Text = p.ipi_cSelo;
                ipi_qSelo.Text = Util.Util.ToString(p.ipi_qSelo);
                ipi_clEnq.Text = p.ipi_clEnq;
                ipi_qUnid.Text = Util.Util.ToString(p.ipi_qUnid);
                ipi_vUnid.Text = Util.Util.ToString(p.ipi_vUnid);
                txtCbenf.Text = p.cBenf;
                txtcProdANP.Text = p.cProdANP;
                txtdescANP.Text = p.descANP;
                txtUFCons.Text = p.UFCons;

                CboCodigoSituacaoTributaria.SelectedValue = Util.Util.ToString(p.ibscbs_cst);
                CboCodigoClassificacaoTributaria.SelectedValue = Util.Util.ToString(p.ibscbs_cClassTrib);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.codigocest.com.br/");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            p.IdNFe = IdNFe;
            p.ICMS_modBCST = null;
            p.NCM = null;
            p.CEST = null;
            p.CFOP = null;
            p.ICMS_modBC = null;
            p.ICMS_origem = null;
            p.cProd = cProd.Text;
            p.cEAN = cEAN.Text;
            p.xProd = xProd.Text;
            p.NCM = txtNCM.Text;
            p.CEST = CEST.Text;
            p.CFOP = txtCFOP.Text;
            p.uCom = uCom.Text;
            p.qCom = Util.Util.IsNumberZero(qCom.Text);
            p.vUnCom = Util.Util.IsNumberZero(vUnCom.Text);
            p.vProd = Util.Util.IsNumberZero(vProd.Text);
            p.cEANTrib = cEANTrib.Text;
            p.uTrib = uTrib.Text;
            p.qTrib = Util.Util.IsNumberZero(qTrib.Text);
            p.vUnTrib = Util.Util.IsNumberZero(vUnTrib.Text);
            p.vOutro = Util.Util.IsNumberZero(vOutro.Text);
            p.cBenf = txtCbenf.Text;
            if (!string.IsNullOrEmpty(indTot.Text))
            {
                p.indTot = Convert.ToInt32(indTot.SelectedValue);
            }
            p.xPed = xPed.Text;
            p.ICMS_origem = ICMS_origem.SelectedValue == null ? "" : ICMS_origem.SelectedValue.ToString();
            p.ICMS_CST = ICMS_CST.Text;
            if (!string.IsNullOrEmpty(ICMS_modBC.Text))
            {
                p.ICMS_modBC = Convert.ToInt32(ICMS_modBC.SelectedValue);
            }
            p.ICMS_redBC = Util.Util.IsNumberZero(ICMS_redBC.Text);
            p.ICMS_vBC = Util.Util.IsNumberZero(ICMS_vBC.Text);
            p.ICMS_pICMS = Util.Util.IsNumberZero(ICMS_pICMS.Text);
            p.ICMS_vICMS = Util.Util.IsNumberZero(ICMS_vICMS.Text);
            if (!string.IsNullOrEmpty(ICMS_modBCST.Text))
            {
                p.ICMS_modBCST = Convert.ToInt32(ICMS_modBCST.SelectedValue);
            }

            p.ICMS_pMVAST = Util.Util.IsNumberZero(ICMS_pMVAST.Text);
            p.ICMS_pRedBCST = Util.Util.IsNumberZero(ICMS_pRedBCST.Text);
            p.ICMS_vBCST = Util.Util.IsNumberZero(ICMS_vBCST.Text);
            p.ICMS_pST = Util.Util.IsNumberZero(ICMS_pST.Text);
            p.ICMS_vST = Util.Util.IsNumberZero(ICMS_vST.Text);
            p.ICMS_vBCSTRet = Util.Util.IsNumberZero(ICMS_vBCSTRet.Text);
            p.ICMS_vICMSSTRet = Util.Util.IsNumberZero(ICMS_vICMSSTRet.Text);
            p.ICMS_pCredSN = Util.Util.IsNumberZero(ICMS_pCredSN.Text);
            p.ICMS_vCredICMSSN = Util.Util.IsNumberZero(ICMS_vCredICMSSN.Text);
            p.IPI_CST = IPI_CST.Text;
            p.IPI_Enq = IPI_Enq.Text;
            p.IPI_pIpi = Util.Util.IsNumberZero(IPI_pIpi.Text);
            p.IPI_vIPI = Util.Util.IsNumberZero(IPI_vIPI.Text);
            p.PIS_CST = PIS_CST.Text;
            p.PIS_pPis = Util.Util.IsNumberZero(PIS_pPis.Text);
            p.PIS_vPis = Util.Util.IsNumberZero(PIS_vPis.Text);
            p.COFINS_CST = COFINS_CST.Text;
            p.COFINS_pCofins = Util.Util.IsNumberZero(COFINS_pCofins.Text);
            p.COFINS_vCofins = Util.Util.IsNumberZero(COFINS_vCofins.Text);
            p.infAdic = infAdic.Text;
            p.vFrete = Util.Util.IsNumberZero(vFrete.Text);
            p.vSeg = Util.Util.IsNumberZero(vSeg.Text);
            p.vDesc = Util.Util.IsNumberZero(vDesc.Text);
            p.IPI_vBC = Util.Util.IsNumberZero(IPI_vBC.Text);
            p.PIS_vBC = Util.Util.IsNumberZero(PIS_vBC.Text);
            p.COFINS_vBC = Util.Util.IsNumberZero(COFINS_vBC.Text);
            p.pis_qBCProd = Util.Util.IsNumberZero(pis_qBCProd.Text);
            p.pis_vAliqProd = Util.Util.IsNumberZero(pis_vAliqProd.Text);
            p.cofins_qBCProd = Util.Util.IsNumberZero(cofins_qBCProd.Text);
            p.cofins_vAliqProd = Util.Util.IsNumberZero(cofins_vAliqProd.Text);
            p.ipi_CNPJProd = ipi_CNPJProd.Text;
            p.ipi_cSelo = ipi_cSelo.Text;
            p.ipi_qSelo = Util.Util.IsNumberZero(ipi_qSelo.Text);
            p.ipi_clEnq = ipi_clEnq.Text;
            p.ipi_qUnid = Util.Util.IsNumberZero(ipi_qUnid.Text);
            p.ipi_vUnid = Util.Util.IsNumberZero(ipi_vUnid.Text);

            p.cProdANP = txtcProdANP.Text;
            p.descANP = txtdescANP.Text;
            p.UFCons = txtUFCons.Text;
            p.ibscbs_cst = CboCodigoSituacaoTributaria.SelectedValue == null ? "" : CboCodigoSituacaoTributaria.SelectedValue.ToString();
            p.ibscbs_cClassTrib = CboCodigoClassificacaoTributaria.SelectedValue == null ? "" : CboCodigoClassificacaoTributaria.SelectedValue.ToString();


            if (p.IdNFeProduto == 0)
            {
                dal.Insert(p);
            }
            else
            {
                dal.Update(p);
            }
            dal.Save();
            MessageBox.Show("Produto salvo com sucesso!");
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (p.IdNFeProduto > 0)
            {
                if (MessageBox.Show("Confirma a exclusão do produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    dal.Delete(p.IdNFeProduto);
                    dal.Save();
                    MessageBox.Show("Produto excluido com sucesso!");
                    this.Close();
                }
            }
        }
    }
}
