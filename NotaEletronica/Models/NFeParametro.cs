
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("NFEPARAMETRO", Schema = "DBO")]
    public class NFeParametro
    {
        [Key]
        [DisplayName("IdNFeParametro")]
        [Column("IDNFEPARAMETRO")]
        public int IdNFeParametro { get; set; }
 
        [DisplayName("IdEmitente")]
        [Column("IDEMITENTE")]
        public int? IdEmitente { get; set; }
 
        [DisplayName("Ambiente")]
        [Column("AMBIENTE")]
        public int? Ambiente { get; set; }
 
        [DisplayName("eUsuario")]
        [Column("EUSUARIO")]
        public string eUsuario { get; set; }
 
        [DisplayName("eSenha")]
        [Column("ESENHA")]
        public string eSenha { get; set; }
 
        [DisplayName("eEmail")]
        [Column("EEMAIL")]
        public string eEmail { get; set; }
 
        [DisplayName("eSMTP")]
        [Column("ESMTP")]
        public string eSMTP { get; set; }
 
        [DisplayName("ePort")]
        [Column("EPORT")]
        public string ePort { get; set; }
 
        [DisplayName("eSSL")]
        [Column("ESSL")]
        public bool eSSL { get; set; }
 
        [DisplayName("Licenca")]
        [Column("LICENCA")]
        public string Licenca { get; set; }

        public string SiglaWS { get; set; }


    }
}
