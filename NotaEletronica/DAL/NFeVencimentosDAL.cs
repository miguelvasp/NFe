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
    public class NFeVencimentosDAL : Repository<NFeVencimentos>
    {
        public List<NFeVencimentos> getByIdNFe(int id)
        {
            return (from v in db.NFeVencimentos
                    where v.IdNFe == id
                    && v.IdBoleto == null
                    select v).OrderBy(x => x.Vencimento).ToList();
        }
    }
}
