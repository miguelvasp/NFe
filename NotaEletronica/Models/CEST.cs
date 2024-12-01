
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("CEST", Schema = "DBO")]
    public class CEST
    {
        [Key]
        [DisplayName("IdCest")]
        [Column("IDCEST")]
        public int? IdCest { get; set; }
 
        [DisplayName("Cest")]
        [Column("CEST")]
        public string Cest { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("NCM")]
        [Column("NCM")]
        public string NCM { get; set; }
 
    }
}
