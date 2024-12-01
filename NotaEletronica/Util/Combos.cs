using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaEletronica.Models;
using NotaEletronica.DAL;

namespace NotaEletronica.Util
{
    public class Combos
    {
        public List<ComboItem> cbotpNF()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Entrada" });
            l.Add(new ComboItem() { iValue = 1, Text = "Saída" });
            return l;
        }

        public List<ComboItem> finNFe()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 1, Text = "NF-e normal" });
            l.Add(new ComboItem() { iValue = 2, Text = "NF-e complementar" });
            l.Add(new ComboItem() { iValue = 3, Text = "NF-e de ajuste" });
            l.Add(new ComboItem() { iValue = 4, Text = "Devolução" });
            return l;
        }

        public List<ComboItem> indFinal()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Não" });
            l.Add(new ComboItem() { iValue = 1, Text = "Sim" });
            return l;
        }

        public List<ComboItem> indPres()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste)" });
            l.Add(new ComboItem() { iValue = 1, Text = "Operação presencial" });
            l.Add(new ComboItem() { iValue = 2, Text = "Operação não presencial, pela Internet" });
            l.Add(new ComboItem() { iValue = 3, Text = "Operação não presencial, Teleatendimento" }); 
            l.Add(new ComboItem() { iValue = 5, Text = "Operação presencial fora do estabelecimento" });
            l.Add(new ComboItem() { iValue = 9, Text = "Operação não presencial, outros" }); 
            return l;
        }

        public List<ComboItem> Municipios()
        {
            var lista = new NFeMunicipioDAL().Get().OrderBy(x => x.MunicipioNome).ToList();
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            foreach (var m in lista)
            {
                l.Add(new ComboItem() { iValue = Convert.ToInt32(m.IdIbge), Text = m.MunicipioNome + "-" + m.UF});
            } 
            return l;
        }

        public List<ComboItem> Paises()
        {
            DB_ERPContext db = new DB_ERPContext();
            return (from p in db.Pais
                    orderby p.Nome
                    select new ComboItem
                    {
                        iValue = (int)p.IdIBGE,
                        Text = p.Nome
                    }).ToList();
            //List<ComboItem> l = new List<ComboItem>();
            //l.Add(new ComboItem() { iValue = 1058, Text = "Brasil" }); 
            //return l;
        }

        public List<ComboItem> getindIEDest()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 1, Text = "1 - Contribuinte ICMS (informar a tag IE do destinatário)" });
            l.Add(new ComboItem() { iValue = 2, Text = "2 - Contribuinte isento de Inscrição no cadastro de Contribuintes do ICMS - não informar a tag IE" });
            l.Add(new ComboItem() { iValue = 9, Text = "9 - Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS - não informar a tag IE" });
            return l;
        }

        public List<ComboItem> getmodFrete()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Contratação do Frete por conta do Remetente (CIF)" });
            l.Add(new ComboItem() { iValue = 1, Text = "Contratação do Frete por conta do Destinatário (FOB)" });
            l.Add(new ComboItem() { iValue = 2, Text = "Contratação do Frete por conta de Terceiros" });
            l.Add(new ComboItem() { iValue = 3, Text = "Transporte Próprio por conta do Remetente" });
            l.Add(new ComboItem() { iValue = 4, Text = "Transporte Próprio por conta do Destinatário" });
            l.Add(new ComboItem() { iValue = 9, Text = "Sem Ocorrência de Transporte" });
            return l;
        }

        public List<ComboItem> getNCM()
        {
            return new NCMDAL().Get().OrderBy(X => X.Codigo).Select(x => new ComboItem() { Text = x.Codigo, Value = x.Codigo }).ToList(); 
        }

        public List<ComboItem> getCEST()
        {
            return new CESTDAL().Get().OrderBy(X => X.Cest).Select(x => new ComboItem() { Text = x.Cest, Value = x.Cest }).ToList();
        }

        public List<ComboItem> getCFOP()
        {
            return new CFOPDAL().Get().OrderBy(X => X.CFOPCOD).Select(x => new ComboItem() { Text = x.CFOPCOD, Value = x.CFOPCOD }).ToList();
        }

        public List<ComboItem> getindTot()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Valor do item (vProd) não compõe o valor total da NF-e (vProd)" });
            l.Add(new ComboItem() { iValue = 1, Text = "Valor do item (vProd) compõe o valor total da NF-e" });
            return l;
        }

        public List<ComboItem> getorig()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { Value = "0", Text = "0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;" });
            l.Add(new ComboItem() { Value = "1", Text = "1 - Estrangeira - Importação direta, exceto a indicada no código 6;" });
            l.Add(new ComboItem() { Value = "2", Text = "2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;" });
            l.Add(new ComboItem() { Value = "3", Text = "3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;" });
            l.Add(new ComboItem() { Value = "4", Text = "4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;" });
            l.Add(new ComboItem() { Value = "5", Text = "5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;" });
            l.Add(new ComboItem() { Value = "6", Text = "6 - Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;" });
            l.Add(new ComboItem() { Value = "7", Text = "7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX e gás natural." });
            l.Add(new ComboItem() { Value = "8", Text = "8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;" });
            return l;
        }

        public List<ComboItem> getmodBC()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Margem Valor Agregado (%)" });
            l.Add(new ComboItem() { iValue = 1, Text = "Pauta (valor)" });
            l.Add(new ComboItem() { iValue = 2, Text = "Preço Tabelado Máximo (valor)" });
            l.Add(new ComboItem() { iValue = 3, Text = "Valor da Operação" });
            return l;
        }

        public List<ComboItem> getmodBCST()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { iValue = 0, Text = "Preço tabelado ou máximo sugerido" });
            l.Add(new ComboItem() { iValue = 1, Text = "Lista Negativa (valor)" });
            l.Add(new ComboItem() { iValue = 2, Text = "Lista Positiva (valor)" });
            l.Add(new ComboItem() { iValue = 3, Text = "Lista Neutra (valor)" });
            l.Add(new ComboItem() { iValue = 4, Text = "Margem Valor Agregado (%)" });
            l.Add(new ComboItem() { iValue = 5, Text = "Pauta (valor)" });
            return l;
        }

        public List<ComboItem> gettpPag()
        {
            List<ComboItem> l = new List<ComboItem>();
            l.Add(new ComboItem() { Text = "" });
            l.Add(new ComboItem() { Value = "01", Text = "Dinheiro" });
            l.Add(new ComboItem() { Value = "02", Text = "Cheque" });
            l.Add(new ComboItem() { Value = "03", Text = "Cartão de Crédito" });
            l.Add(new ComboItem() { Value = "04", Text = "Cartão de Débito" });
            l.Add(new ComboItem() { Value = "05", Text = "Crédito Loja" });
            l.Add(new ComboItem() { Value = "10", Text = "Vale Alimentação" });
            l.Add(new ComboItem() { Value = "11", Text = "Vale Refeição" });
            l.Add(new ComboItem() { Value = "12", Text = "Vale Presente" });
            l.Add(new ComboItem() { Value = "13", Text = "Vale Combustível" });
            l.Add(new ComboItem() { Value = "14", Text = "Duplicata Mercantil" });
            l.Add(new ComboItem() { Value = "90", Text = "Sem Pagamento" });
            l.Add(new ComboItem() { Value = "99", Text = "Outros" });
            return l;
        }
    }
}
