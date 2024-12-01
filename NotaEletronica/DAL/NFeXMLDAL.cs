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
    public class NFeXMLDAL : Repository<NFeXML>
    {
        public NFeXML getByNFeId(int Id)
        {
            return (from x in db.NFeXML
                    where x.IdNFe == Id
                    select x).FirstOrDefault();
        }
    }
}
