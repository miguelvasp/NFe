using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaEletronica.Models;

namespace NotaEletronica.DAL
{
    public class PesquisaDAL
    {
        DB_ERPContext db = new DB_ERPContext();

        public List<PesquisaGrid> get(int Ambiente, DateTime de, DateTime ate, int NumeroDe = 0, int NumeroAte = 0, string Situacao = "", string Dest = "" )
        {
           
            return (from p in db.NFe
                    where p.Ambiente == Ambiente 
                    && p.ide_dEmi >= de
                    && p.ide_dEmi <= ate
                    && (NumeroDe == 0 || p.ide_nNF >= NumeroDe)
                    && (NumeroAte == 0 || p.ide_nNF <= NumeroAte)
                    && (String.IsNullOrEmpty(Situacao) || p.NFeStatus == Situacao)
                    && (String.IsNullOrEmpty(Dest) || p.dest_xNome.Contains(Dest))
                    orderby p.ide_nNF
                    select new PesquisaGrid
                    {
                        Id = p.IdNFe,
                        Serie = p.ide_serie,
                        Numero = p.ide_nNF,
                        Emissao = p.ide_dEmi, 
                        Destinatario = p.dest_xNome,
                        Situacao = p.NFeStatus,
                        ChaveAut = p.ChaveAut,
                        MsgRetorno = p.MsgRetorno
                    }).ToList();

            

            return new List<PesquisaGrid>();
        }
    }

    
}
