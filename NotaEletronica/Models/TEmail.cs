using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NotaEletronica.Models
{
    [Table("TEmail", Schema = "DBO")]
    public class TEmail
    {
        [Key]
        public int IdEmail { get; set; }
        public string de { get; set; }
        public string para { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Anexo { get; set; }
        public string Anexo2 { get; set; }
        public string Anexo3 { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }

        public int? NotaFiscal { get; set; }
    }
}
