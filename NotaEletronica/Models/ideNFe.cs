using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Models
{
    public class ideNFe
    {
        public int? cUF { get; set; }
        public string natOp { get; set; }
        public int? indPag { get; set; }
        public int? mode { get; set; }
        public int? serie { get; set; }
        public int? nNF { get; set; }
        public DateTime? dEmi { get; set; }
        public DateTime? dSaiEnt { get; set; }
        public int? tpNF { get; set; }
        public int? cMunFG { get; set; }
        public int? tpImp { get; set; }
        public int? finNFe { get; set; }
        public int? tpEmis { get; set; }
        public int? procEmi { get; set; }
        public string verProc { get; set; }
        public string NFref { get; set; }
        public string CondPagDesc { get; set; }
    }
}
