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
    public class NFeEmailDAL : Repository<NFeEmail>
    {
         public List<NFeEmail> getByNFeId(int IdNfe)
        {
            return (from e in db.NFeEmail
                    where e.IdNFe == IdNfe
                    && !string.IsNullOrEmpty(e.email)
                    select e).ToList();
        }
    }
}
