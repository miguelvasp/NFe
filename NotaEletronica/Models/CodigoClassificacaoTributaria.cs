using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Models
{
    
        [Table("CodigoClassificacaoTributaria", Schema = "DBO")]
        public class CodigoClassificacaoTributaria
        {
            [Key]
            [DisplayName("Id")]
            [Column("ID")]
            public int? Id { get; set; }

            [DisplayName("Codigo")]
            [Column("Codigo")]
            public string Codigo { get; set; }

            [DisplayName("Nome")]
            [Column("Nome")]
            public string Nome { get; set; } 

        }
    
}
