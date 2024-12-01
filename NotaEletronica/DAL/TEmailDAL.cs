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
    public class TEmailDAL : Repository<TEmail>
    {
        public List<TEmail> getFila()
        {
            return (from e in db.TEmail
                    where e.Status == "Na Fila"
                    select e).ToList();
        }

        public List<TEmail> getemails(string status, DateTime data, DateTime datafinal, int NotaFiscal = 0, string Email = "")
        {
            DateTime dt = new DateTime(data.Year, data.Month, data.Day, 0, 0, 0);
            DateTime dtfinal = new DateTime(datafinal.Year, datafinal.Month, datafinal.Day, 0, 0, 0);
            return (from e in db.TEmail
                    where e.Status == "Processado"
                    && e.Data >= dt
                    && e.Data <= dtfinal
                    && (NotaFiscal == 0 || e.NotaFiscal == NotaFiscal)
                    && e.para.Contains(Email)
                    select e).ToList();
        }
    }
}
