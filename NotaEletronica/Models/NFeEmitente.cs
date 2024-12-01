
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEEMITENTE", Schema = "DBO")]
    public class NFeEmitente
    {
        [Key]
        [DisplayName("IdEmitente")]
        [Column("IDEMITENTE")]
        public int IdEmitente { get; set; }
 
        [DisplayName("emi_CNPJ")]
        [Column("EMI_CNPJ")]
        public string emi_CNPJ { get; set; }
 
        [DisplayName("emi_CPF")]
        [Column("EMI_CPF")]
        public string emi_CPF { get; set; }
 
        [DisplayName("emi_xNome")]
        [Column("EMI_XNOME")]
        public string emi_xNome { get; set; }
 
        [DisplayName("emi_xFant")]
        [Column("EMI_XFANT")]
        public string emi_xFant { get; set; }
 
        [DisplayName("emi_IE")]
        [Column("EMI_IE")]
        public string emi_IE { get; set; }
 
        [DisplayName("emi_xLgr")]
        [Column("EMI_XLGR")]
        public string emi_xLgr { get; set; }
 
        [DisplayName("emi_nro")]
        [Column("EMI_NRO")]
        public string emi_nro { get; set; }
 
        [DisplayName("emi_xCpl")]
        [Column("EMI_XCPL")]
        public string emi_xCpl { get; set; }
 
        [DisplayName("emi_xBairro")]
        [Column("EMI_XBAIRRO")]
        public string emi_xBairro { get; set; }
 
        [DisplayName("emi_cMun")]
        [Column("EMI_CMUN")]
        public string emi_cMun { get; set; }
 
        [DisplayName("emi_xMun")]
        [Column("EMI_XMUN")]
        public string emi_xMun { get; set; }
 
        [DisplayName("emi_UF")]
        [Column("EMI_UF")]
        public string emi_UF { get; set; }
 
        [DisplayName("emi_CEP")]
        [Column("EMI_CEP")]
        public string emi_CEP { get; set; }
 
        [DisplayName("emi_cPais")]
        [Column("EMI_CPAIS")]
        public string emi_cPais { get; set; }
 
        [DisplayName("emi_xPais")]
        [Column("EMI_XPAIS")]
        public string emi_xPais { get; set; }
 
        [DisplayName("emi_Fone")]
        [Column("EMI_FONE")]
        public string emi_Fone { get; set; }
 
        [DisplayName("emi_IEST")]
        [Column("EMI_IEST")]
        public string emi_IEST { get; set; }
 
        [DisplayName("emi_IM")]
        [Column("EMI_IM")]
        public string emi_IM { get; set; }
 
        [DisplayName("emi_CNAE")]
        [Column("EMI_CNAE")]
        public string emi_CNAE { get; set; }
 
        [DisplayName("emi_CRT")]
        [Column("EMI_CRT")]
        public string emi_CRT { get; set; }
        public string emi_xContato { get; set; }
        public string emi_xContatoEmail { get; set; }
        public string emi_idCSRT { get; set; }
        public string emi_CSRT { get; set; }
        public string emi_chaveNFe { get; set; }


    }
}
