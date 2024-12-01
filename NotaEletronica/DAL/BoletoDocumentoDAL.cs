using NotaEletronica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NotaEletronica.DAL
{
    public class BoletoDocumentoDAL : Repository<BoletoDocumento>
    {
        public int getCount(string TipoDocumento, int IdDocumento)
        {
            return (from b in db.BoletoDocumento
                    where b.TipoDocumento == TipoDocumento
                    && b.IdDocumento == IdDocumento
                    select b).Count();
        }
    }
}
