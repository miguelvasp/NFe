
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("PAIS", Schema = "DBO")]
    public class Pais
    {
        [Key]
        [DisplayName("IdPais")]
        [Column("IDPAIS")]
        public int? IdPais { get; set; }
 
        [DisplayName("IdIBGE")]
        [Column("IDIBGE")]
        public int? IdIBGE { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
    }
}
