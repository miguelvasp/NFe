using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Models
{
    public class PesquisaGrid
    {
        public int? Id { get; set; }
        public string Serie { get; set; }
        public int? Numero { get; set; }
        public DateTime? Emissao { get; set; }
        public string Emitente { get; set; }
        public string Destinatario { get; set; }
        public string Situacao { get; set; }

        public string ChaveAut { get; set; }
        public string MsgRetorno { get; set; }
    }
}
