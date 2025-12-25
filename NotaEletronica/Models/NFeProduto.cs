
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEPRODUTO", Schema = "DBO")]
    public class NFeProduto
    {
        [Key]
        [DisplayName("IdNFeProduto")]
        [Column("IDNFEPRODUTO")]
        public int IdNFeProduto { get; set; }
 
        [DisplayName("IdNFe")]
        [Column("IDNFE")]
        public int? IdNFe { get; set; }
 
        [DisplayName("cProd")]
        [Column("CPROD")]
        public string cProd { get; set; }
 
        [DisplayName("cEAN")]
        [Column("CEAN")]
        public string cEAN { get; set; }
 
        [DisplayName("xProd")]
        [Column("XPROD")]
        public string xProd { get; set; }
 
        [DisplayName("NCM")]
        [Column("NCM")]
        public string NCM { get; set; }
 
        [DisplayName("CEST")]
        [Column("CEST")]
        public string CEST { get; set; }
 
        [DisplayName("CFOP")]
        [Column("CFOP")]
        public string CFOP { get; set; }
 
        [DisplayName("uCom")]
        [Column("UCOM")]
        public string uCom { get; set; }
 
        [DisplayName("qCom")]
        [Column("QCOM")]
        public decimal? qCom { get; set; }
 
        [DisplayName("vUnCom")]
        [Column("VUNCOM")]
        public decimal? vUnCom { get; set; }
 
        [DisplayName("vProd")]
        [Column("VPROD")]
        public decimal? vProd { get; set; }
 
        [DisplayName("cEANTrib")]
        [Column("CEANTRIB")]
        public string cEANTrib { get; set; }
 
        [DisplayName("uTrib")]
        [Column("UTRIB")]
        public string uTrib { get; set; }
 
        [DisplayName("qTrib")]
        [Column("QTRIB")]
        public decimal? qTrib { get; set; }
 
        [DisplayName("vUnTrib")]
        [Column("VUNTRIB")]
        public decimal? vUnTrib { get; set; }
 
        [DisplayName("vOutro")]
        [Column("VOUTRO")]
        public decimal? vOutro { get; set; }
 
        [DisplayName("indTot")]
        [Column("INDTOT")]
        public int? indTot { get; set; }
 
        [DisplayName("xPed")]
        [Column("XPED")]
        public string xPed { get; set; }
 
        [DisplayName("ICMS_origem")]
        [Column("ICMS_ORIGEM")]
        public string ICMS_origem { get; set; }
 
        [DisplayName("ICMS_CST")]
        [Column("ICMS_CST")]
        public string ICMS_CST { get; set; }
 
        [DisplayName("ICMS_modBC")]
        [Column("ICMS_MODBC")]
        public int? ICMS_modBC { get; set; }
 
        [DisplayName("ICMS_redBC")]
        [Column("ICMS_REDBC")]
        public decimal? ICMS_redBC { get; set; }
 
        [DisplayName("ICMS_vBC")]
        [Column("ICMS_VBC")]
        public decimal? ICMS_vBC { get; set; }
 
        [DisplayName("ICMS_pICMS")]
        [Column("ICMS_PICMS")]
        public decimal? ICMS_pICMS { get; set; }
 
        [DisplayName("ICMS_vICMS")]
        [Column("ICMS_VICMS")]
        public decimal? ICMS_vICMS { get; set; }
 
        [DisplayName("ICMS_modBCST")]
        [Column("ICMS_MODBCST")]
        public int? ICMS_modBCST { get; set; }
 
        [DisplayName("ICMS_pMVAST")]
        [Column("ICMS_PMVAST")]
        public decimal? ICMS_pMVAST { get; set; }
 
        [DisplayName("ICMS_pRedBCST")]
        [Column("ICMS_PREDBCST")]
        public decimal? ICMS_pRedBCST { get; set; }
 
        [DisplayName("ICMS_vBCST")]
        [Column("ICMS_VBCST")]
        public decimal? ICMS_vBCST { get; set; }
 
        [DisplayName("ICMS_pST")]
        [Column("ICMS_PST")]
        public decimal? ICMS_pST { get; set; }
 
        [DisplayName("ICMS_vST")]
        [Column("ICMS_VST")]
        public decimal? ICMS_vST { get; set; }
 
        [DisplayName("ICMS_vBCSTRet")]
        [Column("ICMS_VBCSTRET")]
        public decimal? ICMS_vBCSTRet { get; set; }
 
        [DisplayName("ICMS_vICMSSTRet")]
        [Column("ICMS_VICMSSTRET")]
        public decimal? ICMS_vICMSSTRet { get; set; }
 
        [DisplayName("ICMS_pCredSN")]
        [Column("ICMS_PCREDSN")]
        public decimal? ICMS_pCredSN { get; set; }
 
        [DisplayName("ICMS_vCredICMSSN")]
        [Column("ICMS_VCREDICMSSN")]
        public decimal? ICMS_vCredICMSSN { get; set; }
 
        [DisplayName("IPI_CST")]
        [Column("IPI_CST")]
        public string IPI_CST { get; set; }
 
        [DisplayName("IPI_Enq")]
        [Column("IPI_ENQ")]
        public string IPI_Enq { get; set; }
 
        [DisplayName("IPI_pIpi")]
        [Column("IPI_PIPI")]
        public decimal? IPI_pIpi { get; set; }
 
        [DisplayName("IPI_vIPI")]
        [Column("IPI_VIPI")]
        public decimal? IPI_vIPI { get; set; }
 
        [DisplayName("PIS_CST")]
        [Column("PIS_CST")]
        public string PIS_CST { get; set; }
 
        [DisplayName("PIS_pPis")]
        [Column("PIS_PPIS")]
        public decimal? PIS_pPis { get; set; }
 
        [DisplayName("PIS_vPis")]
        [Column("PIS_VPIS")]
        public decimal? PIS_vPis { get; set; }
 
        [DisplayName("COFINS_CST")]
        [Column("COFINS_CST")]
        public string COFINS_CST { get; set; }
 
        [DisplayName("COFINS_pCofins")]
        [Column("COFINS_PCOFINS")]
        public decimal? COFINS_pCofins { get; set; }
 
        [DisplayName("COFINS_vCofins")]
        [Column("COFINS_VCOFINS")]
        public decimal? COFINS_vCofins { get; set; }
 
        [DisplayName("infAdic")]
        [Column("INFADIC")]
        public string infAdic { get; set; }
 
        [DisplayName("vFrete")]
        [Column("VFRETE")]
        public decimal? vFrete { get; set; }
 
        [DisplayName("vSeg")]
        [Column("VSEG")]
        public decimal? vSeg { get; set; }
 
        [DisplayName("vDesc")]
        [Column("VDESC")]
        public decimal? vDesc { get; set; }
 
        [DisplayName("IPI_vBC")]
        [Column("IPI_VBC")]
        public decimal? IPI_vBC { get; set; }
 
        [DisplayName("PIS_vBC")]
        [Column("PIS_VBC")]
        public decimal? PIS_vBC { get; set; }
 
        [DisplayName("COFINS_vBC")]
        [Column("COFINS_VBC")]
        public decimal? COFINS_vBC { get; set; }

        [DisplayName("pis_qBCProd")]
        [Column("PIS_QBCPROD")]
        public decimal? pis_qBCProd { get; set; }

        [DisplayName("pis_vAliqProd")]
        [Column("PIS_VALIQPROD")]
        public decimal? pis_vAliqProd { get; set; }

        [DisplayName("cofins_qBCProd")]
        [Column("COFINS_QBCPROD")]
        public decimal? cofins_qBCProd { get; set; }

        [DisplayName("cofins_vAliqProd")]
        [Column("COFINS_VALIQPROD")]
        public decimal? cofins_vAliqProd { get; set; }

        [DisplayName("ipi_CNPJProd")]
        [Column("IPI_CNPJPROD")]
        public string ipi_CNPJProd { get; set; }

        [DisplayName("ipi_cSelo")]
        [Column("IPI_CSELO")]
        public string ipi_cSelo { get; set; }

        [DisplayName("ipi_qSelo")]
        [Column("IPI_QSELO")]
        public decimal? ipi_qSelo { get; set; }

        [DisplayName("ipi_clEnq")]
        [Column("IPI_CLENQ")]
        public string ipi_clEnq { get; set; }

        [DisplayName("ipi_qUnid")]
        [Column("IPI_QUNID")]
        public decimal? ipi_qUnid { get; set; }

        [DisplayName("ipi_vUnid")]
        [Column("IPI_VUNID")]
        public decimal? ipi_vUnid { get; set; }
        [Column("cBenf")]
        public string cBenf { get; set; }

        [Column("cProdANP")]
        public string cProdANP { get; set; }

        [Column("descANP")]
        public string descANP { get; set; }

        [Column("UFCons")]
        public string UFCons { get; set; }

        [Column("ibscbs_cst")]
        public string ibscbs_cst { get; set; }
        [Column("ibscbs_cClassTrib")]
        public string ibscbs_cClassTrib { get; set; }
    }
}
