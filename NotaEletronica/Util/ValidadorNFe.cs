using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaEletronica.Models;

namespace NotaEletronica.Util
{
    public static class ValidadorNFe
    {
        public static List<string> Validar(NFe n)
        {
            List<string> erros = new List<string>();

            List<string> ide = new List<string>();
            if (n.ide_cUF == null) ide.Add(">>> cUF informar o código da UF do emitente do Documento Fiscal, utilizar a codificação do IBGE (Ex. SP->35, RS->43, etc.)");
            if (string.IsNullOrEmpty(n.ide_natOp)) ide.Add(">>> Natureza da Operação em branco");
            if (string.IsNullOrEmpty(n.ide_serie)) ide.Add(">>> Série em branco");
            if (n.ide_nNF == null) ide.Add(">>> Informe o número da NFe");
            if (n.ide_tpNF == null) ide.Add(">>> Informar o código do tipo do Documento Fiscal"); 
            if (n.ide_tpEmis == null) ide.Add(">>> Informar o código da forma de emissão");
            if (n.ide_finNFe == null) ide.Add(">>> Informar o código da finalidade de emissão da NF-e");
            if (n.ide_indFinal == null) ide.Add(">>> Informar o indicador de operação com Consumidor final");
            if (n.ide_indPres == null) ide.Add(">>> Informar o indicador de presença do comprador no estabelecimento comercial no momento da operação");
            if(ide.Count > 0)
            {
                erros.Add("Informações da Nota Fiscal");
                foreach(string s in ide)
                {
                    erros.Add(s);
                }
                erros.Add("");
            }



            List<string> dest = new List<string>();
            if(n.dest_UF.ToUpper() == "EX")
            {
                if (string.IsNullOrEmpty(n.dest_xBairro)) dest.Add(">>> Informar ID Estrangeiro");
                if (string.IsNullOrEmpty(n.UFSaidaPais)) dest.Add(">>> Informar UF de saída do pais");
                if (string.IsNullOrEmpty(n.xLocEmbarq)) dest.Add(">>> Informar Local de embarque");
                if (!string.IsNullOrEmpty(n.dest_CPF)) dest.Add(">>> CPF não deve ser informado");
                if (!string.IsNullOrEmpty(n.dest_CNPJ)) dest.Add(">>> CNPJ não deve ser informado");
                if (n.dest_cPais == "1058") dest.Add(">>> País informado deve ser diferente do BRASIL");
            }
            else
            {
                if (string.IsNullOrEmpty(n.dest_CNPJ) && string.IsNullOrEmpty(n.dest_CPF)) dest.Add(">>> Informe o CNPJ ou CPF do destinatário");
                if (!string.IsNullOrEmpty(n.dest_CNPJ) && !Util.IsCnpj(n.dest_CNPJ)) dest.Add(">>> CNPJ inválido");
                if (!string.IsNullOrEmpty(n.dest_CPF) && !Util.IsCpf(n.dest_CPF)) dest.Add(">>> CPF inválido");
            }
           
            if (string.IsNullOrEmpty(n.dest_xNome)) dest.Add(">>> Informar a razão social do destinatário");
            if (string.IsNullOrEmpty(n.dest_xlgr)) dest.Add(">>> Informar a logradouro do destinatário");
            if (string.IsNullOrEmpty(n.dest_nro)) dest.Add(">>> Informar número do endereço");
            if (string.IsNullOrEmpty(n.dest_xBairro)) dest.Add(">>> Informar o bairro do endereço do destinatário");
            if (string.IsNullOrEmpty(n.dest_cMun)) dest.Add(">>> Informar o código do município na codificação do IBGE");
            if (string.IsNullOrEmpty(n.dest_UF)) dest.Add(">>> Informar a UF do destinatário");
            if (string.IsNullOrEmpty(n.dest_indIEDest)) dest.Add(">>> Informar o Indicador da IE do Destinatário");

            if(n.dest_indIEDest == "1")
            {
                if (string.IsNullOrEmpty(n.dest_IE)) dest.Add(">>> Informar IE do Destinatário");
            }
            else
            {
                if (!string.IsNullOrEmpty(n.dest_IE)) dest.Add(">>> Para contribuinte Isento ou Não Contribuinte não deve ser informada a IE");
            }

            if (dest.Count > 0)
            {
                erros.Add("Informações do Destinatário");
                foreach (string s in dest)
                {
                    erros.Add(s);
                }
                erros.Add("");
            }

            if (string.IsNullOrEmpty(n.tra_modFrete))
            {
                erros.Add(">>> Informações do Transporte");
                erros.Add(">>> Informe o responsável pelo Frete!");
                erros.Add("");
            }


            foreach(var i in n.Produtos)
            {
                List<string> pro = new List<string>();
                if (string.IsNullOrEmpty(i.cProd)) pro.Add(">>> Informar o código do produto ou serviço");
                if (string.IsNullOrEmpty(i.xProd)) pro.Add(">>> Informar a descrição do produto ou serviço");
                if (string.IsNullOrEmpty(i.NCM)) pro.Add(">>> Informar o Código NCM ");
                if (string.IsNullOrEmpty(i.CFOP)) pro.Add(">>> Informar o CFOP - Código Fiscal de Operações e Prestações ");
                if (string.IsNullOrEmpty(i.uCom)) pro.Add(">>> Informar a unidade de comercialização do produto (Ex. pc, und, dz, kg, etc.).");
                if(i.qCom == null) pro.Add(">>> Informar a quantidade de comercialização do produto.");
                if (i.vUnCom == null) pro.Add(">>> Informar o valor unitário de comercialização do produto.");
                if (i.indTot == null) pro.Add(">>> Informar se o valor do produto compõe o total da nota fiscal");
                if (i.vProd == null) pro.Add(">>> Informar o valor unitário de comercialização do produto");
                if (i.indTot == null) pro.Add(">>> Informar se o valor do produto faz parte do total da nota fiscal (indTot)");

                if (pro.Count > 0)
                {
                    erros.Add($"Informações do Produto {i.cProd} - {i.xProd}");
                    foreach (string s in pro)
                    {
                        erros.Add(s);
                    }
                    erros.Add("");
                }
            }

            return erros;
        }
    }
}
