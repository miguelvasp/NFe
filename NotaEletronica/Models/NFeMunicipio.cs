
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEMUNICIPIO", Schema = "DBO")]
    public class NFeMunicipio
    {
        [Key]
        [DisplayName("IdMunicipio")]
        [Column("IDMUNICIPIO")]
        public int? IdMunicipio { get; set; }
 
        [DisplayName("IdIbge")]
        [Column("IDIBGE")]
        public int? IdIbge { get; set; }
 
        [DisplayName("UF")]
        [Column("UF")]
        public string UF { get; set; }
 
        [DisplayName("MunicipioNome")]
        [Column("MUNICIPIONOME")]
        public string MunicipioNome { get; set; }
 
    }
}
