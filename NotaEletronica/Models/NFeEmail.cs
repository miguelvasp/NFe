
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEEMAIL", Schema = "DBO")]
    public class NFeEmail
    {
        [Key]
        [DisplayName("IdNFeEmail")]
        [Column("IDNFEEMAIL")]
        public int? IdNFeEmail { get; set; }
 
        [DisplayName("IdNFe")]
        [Column("IDNFE")]
        public int? IdNFe { get; set; }
 
        [DisplayName("email")]
        [Column("EMAIL")]
        public string email { get; set; }
 
    }
}
