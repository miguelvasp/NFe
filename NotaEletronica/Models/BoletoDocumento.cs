
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("BOLETODOCUMENTO", Schema = "DBO")]
    public class BoletoDocumento
    {
        [Key]
        [DisplayName("IdBoletoDocumento")]
        [Column("IDBOLETODOCUMENTO")]
        public int? IdBoletoDocumento { get; set; }
 
        [DisplayName("TipoDocumento")]
        [Column("TIPODOCUMENTO")]
        public string TipoDocumento { get; set; }
 
        [DisplayName("IdDocumento")]
        [Column("IDDOCUMENTO")]
        public int? IdDocumento { get; set; }
 
        [DisplayName("IdBoleto")]
        [Column("IDBOLETO")]
        public int? IdBoleto { get; set; }
 
    }
}
