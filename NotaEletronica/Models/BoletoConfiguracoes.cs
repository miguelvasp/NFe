
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("BOLETOCONFIGURACOES", Schema = "DBO")]
    public class BoletoConfiguracoes
    {
        [Key]
        [DisplayName("IdBoletoConfiguracoes")]
        [Column("IDBOLETOCONFIGURACOES")]
        public int IdBoletoConfiguracoes { get; set; }
 
        [DisplayName("nroDias")]
        [Column("NRODIAS")]
        public int? nroDias { get; set; }
 
        [DisplayName("Cateira")]
        [Column("CATEIRA")]
        public string Cateira { get; set; }
 
        [DisplayName("numeroBanco")]
        [Column("NUMEROBANCO")]
        public int? numeroBanco { get; set; }
 
        [DisplayName("NossoNumero")]
        [Column("NOSSONUMERO")]
        public string NossoNumero { get; set; }

        public int? CodigoInstrucao { get; set; }

        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string ContaCorrente { get; set; }
        public string DigitoContaCorrente { get; set; }

        public string Codigo { get; set; }
        public string Convenio { get; set; }
        public string NossoNumeroDigito { get; set; }
        public string Contrato { get; set; }
    }
}
