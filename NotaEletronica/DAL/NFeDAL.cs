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
    public class NFeDAL : Repository<NFe>
    {
        public void RecalcularNFe(int Id)
        {
            NFeProdutoDAL pdal = new NFeProdutoDAL();
            List<NFeProduto> prod = pdal.getByIdNFe(Id);
            Decimal total = 0;
            //recalcula o preço dos itens
            foreach(var p in prod)
            {
                p.vProd = p.qCom * p.vUnCom;
                if(p.indTot == 1)
                {
                    total += Convert.ToDecimal(p.vProd);
                }
                pdal.Update(p);
                pdal.Save();
            }

            //atualiza o total da NF
            NFe n = this.GetByID(Id);
            n.tot_vNF = total - n.tot_vDesc;
            n.tot_vProd = total;
            this.Update(n);
            this.Save();
        }

        public int getNovaNota()
        {
            return (int)db.NFe.Max(x => x.ide_nNF);
        }
    }
}
