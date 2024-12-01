using NotaEletronica.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.BLL
{
    public class BLEmail
    {
        TEmailDAL dal = new TEmailDAL();
        public void SendEmails()
        {
            var emailConfig = new NFeParametroDAL().Get().ToList()[0];
            var lista = dal.getFila();
            foreach(var e in lista)
            {
                bool resultado = Util.Util.EnviarEmail(e.Assunto, e.Mensagem, e.para, e.Anexo, e.Anexo2, e.Anexo3, emailConfig);
                if(resultado)
                {
                    e.Status = "Processado";
                    dal.Update(e);
                    dal.Save();
                }
            }
        }
    }
}
