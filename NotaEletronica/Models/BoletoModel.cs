using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Models
{
    public class BoletoModel
    {
        public DateTime vencimento { get; set; }
        public int instrucao { get; set; }
        public int nroDias { get; set; }
        public string ccpf { get; set; }
        public string cnome { get; set; }
        public string cagencia { get; set; }
        public string cdigitoagencia { get; set; }
        public string ccontacorrente { get; set; }
        public string cdigitoconta { get; set; }
        public string ccodigo { get; set; }
        public decimal valorBoleto { get; set; }
        public string carteira { get; set; }
        public string nossonumero { get; set; }
        public string numeroDocumento { get; set; }
        public string scpf { get; set; }
        public string snome { get; set; }

    }
}
