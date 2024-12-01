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
    public class NFeProdutoDAL : Repository<NFeProduto>
    {
        public List<NFeProduto> getByIdNFe(int Id)
        {
            return (from p in db.NFeProduto
                    where p.IdNFe == Id
                    select p).ToList();
        }
    }
}
