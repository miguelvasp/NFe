
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFE", Schema = "DBO")]
    public class NFe
    {
        [Key]
        [DisplayName("IdNFe")]
        [Column("IDNFE")]
        public int IdNFe { get; set; }
 
        [DisplayName("IdEmitente")]
        [Column("IDEMITENTE")]
        public int? IdEmitente { get; set; }
 
        [DisplayName("Ambiente")]
        [Column("AMBIENTE")]
        public int? Ambiente { get; set; }
 
        [DisplayName("cDV")]
        [Column("CDV")]
        public int? cDV { get; set; }
 
        [DisplayName("ide_cUF")]
        [Column("IDE_CUF")]
        public int? ide_cUF { get; set; }
 
        [DisplayName("ide_natOp")]
        [Column("IDE_NATOP")]
        public string ide_natOp { get; set; }
 
        [DisplayName("ide_indPag")]
        [Column("IDE_INDPAG")]
        public int? ide_indPag { get; set; }
 
        [DisplayName("ide_mode")]
        [Column("IDE_MODE")]
        public int? ide_mode { get; set; }
 
        [DisplayName("ide_serie")]
        [Column("IDE_SERIE")]
        public string ide_serie { get; set; }
 
        [DisplayName("ide_nNF")]
        [Column("IDE_NNF")]
        public int? ide_nNF { get; set; }
 
        [DisplayName("ide_dEmi")]
        [Column("IDE_DEMI")]
        public DateTime? ide_dEmi { get; set; }
 
        [DisplayName("ide_dSaiEnt")]
        [Column("IDE_DSAIENT")]
        public DateTime? ide_dSaiEnt { get; set; }
 
        [DisplayName("ide_tpNF")]
        [Column("IDE_TPNF")]
        public int? ide_tpNF { get; set; }
 
        [DisplayName("ide_cMunFG")]
        [Column("IDE_CMUNFG")]
        public int? ide_cMunFG { get; set; }
 
        [DisplayName("ide_tpImp")]
        [Column("IDE_TPIMP")]
        public int? ide_tpImp { get; set; }
 
        [DisplayName("ide_finNFe")]
        [Column("IDE_FINNFE")]
        public int? ide_finNFe { get; set; }
 
        [DisplayName("ide_tpEmis")]
        [Column("IDE_TPEMIS")]
        public int? ide_tpEmis { get; set; }
 
        [DisplayName("ide_procEmi")]
        [Column("IDE_PROCEMI")]
        public int? ide_procEmi { get; set; }
 
        [DisplayName("ide_verProc")]
        [Column("IDE_VERPROC")]
        public string ide_verProc { get; set; }
 
        [DisplayName("ide_NFref")]
        [Column("IDE_NFREF")]
        public string ide_NFref { get; set; }
 
        [DisplayName("ide_CondPagDesc")]
        [Column("IDE_CONDPAGDESC")]
        public string ide_CondPagDesc { get; set; }
 
        [DisplayName("ide_indFinal")]
        [Column("IDE_INDFINAL")]
        public int? ide_indFinal { get; set; }
 
        [DisplayName("ide_indPres")]
        [Column("IDE_INDPRES")]
        public int? ide_indPres { get; set; }
 
        [DisplayName("ide_cNF")]
        [Column("IDE_CNF")]
        public int? ide_cNF { get; set; }
 
        [DisplayName("dest_CNPJ")]
        [Column("DEST_CNPJ")]
        public string dest_CNPJ { get; set; }
 
        [DisplayName("dest_CPF")]
        [Column("DEST_CPF")]
        public string dest_CPF { get; set; }
 
        [DisplayName("dest_xNome")]
        [Column("DEST_XNOME")]
        public string dest_xNome { get; set; }
 
        [DisplayName("dest_xFant")]
        [Column("DEST_XFANT")]
        public string dest_xFant { get; set; }
 
        [DisplayName("dest_xlgr")]
        [Column("DEST_XLGR")]
        public string dest_xlgr { get; set; }
 
        [DisplayName("dest_nro")]
        [Column("DEST_NRO")]
        public string dest_nro { get; set; }
 
        [DisplayName("dest_xCpl")]
        [Column("DEST_XCPL")]
        public string dest_xCpl { get; set; }
 
        [DisplayName("dest_xBairro")]
        [Column("DEST_XBAIRRO")]
        public string dest_xBairro { get; set; }
 
        [DisplayName("dest_cMun")]
        [Column("DEST_CMUN")]
        public string dest_cMun { get; set; }
 
        [DisplayName("dest_xMun")]
        [Column("DEST_XMUN")]
        public string dest_xMun { get; set; }
 
        [DisplayName("dest_UF")]
        [Column("DEST_UF")]
        public string dest_UF { get; set; }
 
        [DisplayName("dest_CEP")]
        [Column("DEST_CEP")]
        public string dest_CEP { get; set; }
 
        [DisplayName("dest_cPais")]
        [Column("DEST_CPAIS")]
        public string dest_cPais { get; set; }
 
        [DisplayName("dest_xPais")]
        [Column("DEST_XPAIS")]
        public string dest_xPais { get; set; }
 
        [DisplayName("dest_fone")]
        [Column("DEST_FONE")]
        public string dest_fone { get; set; }
 
        [DisplayName("dest_IE")]
        [Column("DEST_IE")]
        public string dest_IE { get; set; }
 
        [DisplayName("dest_IESUF")]
        [Column("DEST_IESUF")]
        public string dest_IESUF { get; set; }
 
        [DisplayName("dest_email")]
        [Column("DEST_EMAIL")]
        public string dest_email { get; set; }
 
        [DisplayName("dest_indIEDest")]
        [Column("DEST_INDIEDEST")]
        public string dest_indIEDest { get; set; }
 
        [DisplayName("dest_IdExtrangeiro")]
        [Column("DEST_IDEXTRANGEIRO")]
        public string dest_IdExtrangeiro { get; set; }
 
        [DisplayName("tot_vBC")]
        [Column("TOT_VBC")]
        public decimal? tot_vBC { get; set; }
 
        [DisplayName("tot_vICMS")]
        [Column("TOT_VICMS")]
        public decimal? tot_vICMS { get; set; }
 
        [DisplayName("tot_vBCST")]
        [Column("TOT_VBCST")]
        public decimal? tot_vBCST { get; set; }
 
        [DisplayName("tot_vST")]
        [Column("TOT_VST")]
        public decimal? tot_vST { get; set; }
 
        [DisplayName("tot_vProd")]
        [Column("TOT_VPROD")]
        public decimal? tot_vProd { get; set; }
 
        [DisplayName("tot_vFrete")]
        [Column("TOT_VFRETE")]
        public decimal? tot_vFrete { get; set; }
 
        [DisplayName("tot_vSeg")]
        [Column("TOT_VSEG")]
        public decimal? tot_vSeg { get; set; }
 
        [DisplayName("tot_vDesc")]
        [Column("TOT_VDESC")]
        public decimal? tot_vDesc { get; set; }
 
        [DisplayName("tot_vII")]
        [Column("TOT_VII")]
        public decimal? tot_vII { get; set; }
 
        [DisplayName("tot_vIPI")]
        [Column("TOT_VIPI")]
        public decimal? tot_vIPI { get; set; }
 
        [DisplayName("tot_vPIS")]
        [Column("TOT_VPIS")]
        public decimal? tot_vPIS { get; set; }
 
        [DisplayName("tot_vCOFINS")]
        [Column("TOT_VCOFINS")]
        public decimal? tot_vCOFINS { get; set; }
 
        [DisplayName("tot_vOutro")]
        [Column("TOT_VOUTRO")]
        public decimal? tot_vOutro { get; set; }
 
        [DisplayName("tot_vNF")]
        [Column("TOT_VNF")]
        public decimal? tot_vNF { get; set; }
 
        [DisplayName("tot_vTotTrib")]
        [Column("TOT_VTOTTRIB")]
        public decimal? tot_vTotTrib { get; set; }
 
        [DisplayName("tot_vICMSDeson")]
        [Column("TOT_VICMSDESON")]
        public decimal? tot_vICMSDeson { get; set; }
 
        [DisplayName("tot_vICMSUFDest_Opc")]
        [Column("TOT_VICMSUFDEST_OPC")]
        public decimal? tot_vICMSUFDest_Opc { get; set; }
 
        [DisplayName("tot_vICMSUFRemet")]
        [Column("TOT_VICMSUFREMET")]
        public decimal? tot_vICMSUFRemet { get; set; }
 
        [DisplayName("tot_vFCPUFDest")]
        [Column("TOT_VFCPUFDEST")]
        public decimal? tot_vFCPUFDest { get; set; }
 
        [DisplayName("tot_vFCP")]
        [Column("TOT_VFCP")]
        public decimal? tot_vFCP { get; set; }
 
        [DisplayName("tot_vFCPST")]
        [Column("TOT_VFCPST")]
        public decimal? tot_vFCPST { get; set; }
 
        [DisplayName("tot_vFCPSTRet")]
        [Column("TOT_VFCPSTRET")]
        public decimal? tot_vFCPSTRet { get; set; }
 
        [DisplayName("tot_vIPIDevol")]
        [Column("TOT_VIPIDEVOL")]
        public decimal? tot_vIPIDevol { get; set; }
 
        [DisplayName("tra_modFrete")]
        [Column("TRA_MODFRETE")]
        public string tra_modFrete { get; set; }
 
        [DisplayName("tra_CNPJ")]
        [Column("TRA_CNPJ")]
        public string tra_CNPJ { get; set; }
 
        [DisplayName("tra_CPF")]
        [Column("TRA_CPF")]
        public string tra_CPF { get; set; }
 
        [DisplayName("tra_xNome")]
        [Column("TRA_XNOME")]
        public string tra_xNome { get; set; }
 
        [DisplayName("tra_IE")]
        [Column("TRA_IE")]
        public string tra_IE { get; set; }
 
        [DisplayName("tra_xEnder")]
        [Column("TRA_XENDER")]
        public string tra_xEnder { get; set; }
 
        [DisplayName("tra_xMun")]
        [Column("TRA_XMUN")]
        public string tra_xMun { get; set; }
 
        [DisplayName("tra_UF")]
        [Column("TRA_UF")]
        public string tra_UF { get; set; }

        [DisplayName("Recibo")]
        [Column("RECIBO")]
        public string Recibo { get; set; }

        [DisplayName("Protocolo")]
        [Column("PROTOCOLO")]
        public string Protocolo { get; set; }

        [DisplayName("DtAutorizacao")]
        [Column("DTAUTORIZACAO")]
        public DateTime? DtAutorizacao { get; set; }

        [DisplayName("MsgRetorno")]
        [Column("MSGRETORNO")]
        public string MsgRetorno { get; set; }

        [DisplayName("NFeStatus")]
        [Column("NFESTATUS")]
        public string NFeStatus { get; set; }

        [DisplayName("DtCancelamento")]
        [Column("DTCANCELAMENTO")]
        public DateTime? DtCancelamento { get; set; }

        [DisplayName("Justificativa")]
        [Column("JUSTIFICATIVA")]
        public string Justificativa { get; set; }

        public string ChaveAut { get; set; }

        public string ProtocoloCancelamento { get; set; }

        [DisplayName("veic_Placa")]
        [Column("VEIC_PLACA")]
        public string veic_Placa { get; set; }

        [DisplayName("veic_UF")]
        [Column("VEIC_UF")]
        public string veic_UF { get; set; }

        [DisplayName("veic_RNTC")]
        [Column("VEIC_RNTC")]
        public string veic_RNTC { get; set; }

        [DisplayName("vol_qVol")]
        [Column("VOL_QVOL")]
        public decimal? vol_qVol { get; set; }

        [DisplayName("vol_esp")]
        [Column("VOL_ESP")]
        public string vol_esp { get; set; }

        [DisplayName("vol_Marca")]
        [Column("VOL_MARCA")]
        public string vol_Marca { get; set; }

        [DisplayName("vol_nVol")]
        [Column("VOL_NVOL")]
        public string vol_nVol { get; set; }

        [DisplayName("vol_pesoL")]
        [Column("VOL_PESOL")]
        public decimal? vol_pesoL { get; set; }

        [DisplayName("vol_pesoB")]
        [Column("VOL_PESOB")]
        public decimal? vol_pesoB { get; set; }

        [DisplayName("vol_lacres")]
        [Column("VOL_LACRES")]
        public string vol_lacres { get; set; }

        public string infAdic { get; set; }

        public string pag_tPag { get; set; }

        public decimal? pag_vPag { get; set; }

        public string CCeTexto { get; set; }

        public string UFSaidaPais { get; set; }
        public string xLocEmbarq { get; set; }

        public virtual ICollection<NFeProduto> Produtos { get; set; }

    }
}
