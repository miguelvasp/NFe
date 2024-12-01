
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEVENCIMENTOS", Schema = "DBO")]
    public class NFeVencimentos
    {
        [Key]
        [DisplayName("IdNFeVencimentos")]
        [Column("IDNFEVENCIMENTOS")]
        public int? IdNFeVencimentos { get; set; }
 
        [DisplayName("IdNFe")]
        [Column("IDNFE")]
        public int? IdNFe { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }

        public int? IdBoleto { get; set; }


    }
}
