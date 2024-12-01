
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NCM", Schema = "DBO")]
    public class NCM
    {
        [Key]
        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int? IdNCM { get; set; }
 
        [DisplayName("NCM")]
        [Column("Codigo")]
        public string Codigo { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("CEST")]
        [Column("CEST")]
        public string CEST { get; set; }
 
    }
}
