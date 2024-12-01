
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("CFOP", Schema = "DBO")]
    public class CFOP
    {
        [Key]
        [DisplayName("IdCFOP")]
        [Column("IDCFOP")]
        public int? IdCFOP { get; set; }
 
        [DisplayName("CFOPCOD")]
        [Column("CFOPCOD")]
        public string CFOPCOD { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Localizacao")]
        [Column("LOCALIZACAO")]
        public int? Localizacao { get; set; }
 
        [DisplayName("Direcao")]
        [Column("DIRECAO")]
        public int? Direcao { get; set; }
 
        [DisplayName("IdTextoPadrao")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }
 
        [DisplayName("Finalidade")]
        [Column("FINALIDADE")]
        public int? Finalidade { get; set; }
  
 
    }
}
