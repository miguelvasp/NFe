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
    public class BoletoConfiguracoesDAL : Repository<BoletoConfiguracoes>
    {
        public BoletoConfiguracoes getByBanco(int numeroBanco)
        {
            return (from b in db.BoletoConfiguracoes
                    where b.numeroBanco == numeroBanco
                    select b).FirstOrDefault();
        }
    }
}
