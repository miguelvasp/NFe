
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEINUTILIZA", Schema = "DBO")]
    public class NFeInutiliza
    {
        [Key]
        [DisplayName("id")]
        [Column("ID")]
        public int? id { get; set; }
 
        [DisplayName("Numero")]
        [Column("NUMERO")]
        public string Numero { get; set; }
 
        [DisplayName("Serie")]
        [Column("SERIE")]
        public string Serie { get; set; }
 
        [DisplayName("Justificativa")]
        [Column("JUSTIFICATIVA")]
        public string Justificativa { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Protocolo")]
        [Column("PROTOCOLO")]
        public string Protocolo { get; set; }
 
        [DisplayName("XMLInut")]
        [Column("XMLINUT")]
        public string XMLInut { get; set; }
 
    }
}
