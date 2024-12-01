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
    public class BoletoDAL : Repository<Boleto>
    {
        public Boleto getByIdDocumento(int Id, string TipoDocumento)
        {
            return (from b in db.Boleto
                    where b.IdDocumentoEletronico == Id
                    && b.TipoDocumento == TipoDocumento
                    select b).FirstOrDefault();
        }

        public void AtualizaVencimento(int idBoleto, DateTime vencimento)
        {
            Boleto b = this.GetByID(idBoleto);
            if(b != null)
            {
                b.Vencimento = vencimento;
                this.Update(b);
                this.Save();
            }
        }

        public List<Boleto> getByParams(DateTime de, DateTime ate, string situacao, string Nota, string Nome, string ordem)
        {
            var lista =  (from b in db.Boleto
                    where b.Emissao >= de
                    && b.Emissao <= ate
                    && (string.IsNullOrEmpty(situacao) || b.Situacao == situacao)
                    && (string.IsNullOrEmpty(Nota) || b.NumeroDocumento.Contains(Nota))
                    && (string.IsNullOrEmpty(Nome) || b.sacado_nome.Contains(Nome))
                    && b.ValorBoleto > 0
                    select b).ToList();

            switch(ordem)
            {
                case "nome": lista = lista.OrderBy(x => x.sacado_nome).ToList();break;
                case "documento": lista.OrderBy(x => x.NumeroDocumento).ToList(); break;
                case "emissao": lista.OrderBy(x => x.Emissao).ToList(); break;
                case "vencimento": lista.OrderBy(x => x.Vencimento).ToList(); break;
            }

            return lista;
        }

        public int NovoLote()
        {
            var v = (from n in db.Boleto
                     select n.Lote).Max();
            if(v == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(v) + 1;
            }
        }

        public List<Boleto> getByLote(int lote)
        {
            return (from b in db.Boleto
                    where b.Lote == lote
                    select b).ToList();
        }
    }
}
