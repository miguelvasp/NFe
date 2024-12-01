
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEXML", Schema = "DBO")]
    public class NFeXML
    {
        [Key]
        [DisplayName("IdNFeXML")]
        [Column("IDNFEXML")]
        public int IdNFeXML { get; set; }
 
        [DisplayName("IdNFe")]
        [Column("IDNFE")]
        public int? IdNFe { get; set; }
 
        [DisplayName("NFe_XML")]
        [Column("NFE_XML")]
        public string NFe_XML { get; set; }
 
        [DisplayName("NFeProtocoloXML")]
        [Column("NFEPROTOCOLOXML")]
        public string NFeProtocoloXML { get; set; }
 
        [DisplayName("NFeCancelaXML")]
        [Column("NFECANCELAXML")]
        public string NFeCancelaXML { get; set; }
 
        [DisplayName("CCeXML")]
        [Column("CCEXML")]
        public string CCeXML { get; set; }
 
    }
}
