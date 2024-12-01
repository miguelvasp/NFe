using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Util
{
    public class UtilBradescoCobranca400
    {


        public string headerArquivo(
                                int CodigoEmpresa,
                                string NomeEmpresa,
                                int Lote)
        {

            string header = "";
            header += writeint(0, 1, 1);//001 a 001Identificação do Registro
            header += writeint(1, 2, 2); //002 a 002Identificação do Arquivo Remessa
            header += writetext("REMESSA", 3, 9); //003 a 009Literal Remessa
            header += writetext("01", 10, 11);//010 a 011Código de Serviço
            header += writetext("COBRANCA", 12,26);//012 a 026Literal Serviço
            //header += writeint(57176, 27, 46);//Código da Empresa
            header += writeint(CodigoEmpresa, 27, 46);//Código da Empresa
            header += writetext(NomeEmpresa, 47, 76);//Nome da Empresa
            header += writeint(237, 77, 79);//Número do Bradesco na Câmara de Compensação
            header += writetext("Bradesco", 80, 94);//Nome do Banco por Extenso
            header += writetext(DateTime.Now.ToString("ddMMyy"), 95, 100);//Data da Gravação do Arquivo
            header += writetext("", 101, 108);//brasncos
            header += writetext("MX", 109, 110);// identificação do sistema
            header += writeint(Lote, 111, 117);//Nº Seqüencial de Remessa
            header += writetext("", 118, 394);//Branco
            header += writeint(1, 395, 400);//Nº Seqüencial do Registro de Um em Um 
            return header;
        }

        public string Transacao(
                string Carteira,
                int Agencia,
                int ContaCorrente,
                int DigitoConta,
                int IdBoleto,
                string NossoNumero,
                string Documento,
                DateTime Vencimento,
                decimal ValorTitulo,
                DateTime Emissao,
                string cpfcnpj,
                string NomePagador,
                string Endereco,
                string CEP,
                int sequencia
            )
        {
            string trs = "";
            trs += writeint(1, 1, 1);//Identificação do Registro
            trs += writetext("", 2, 6);//Agência de Débito (opcional)
            trs += writetext("", 7,7);//Dígito da Agência de Débito (opcional)
            trs += writetext("", 8, 12);//Razão da Conta Corrente (opcional)
            trs += writetext("", 13, 19);//Conta Corrente (opcional)
            trs += writetext("", 20, 20);//Dígito da Conta Corrente (opcional)
            trs += writeint(0, 21, 21 );//zero
            trs += writeint(9, 22, 24);//códigos da carteira
            trs += writeint(Agencia, 25, 29);//códigos da Agência Beneficiários, sem o dígito.
            trs += writeint(ContaCorrente, 30, 36);//Contas Corrente
            trs += writeint(DigitoConta, 37, 37);//dígitos da Conta
            trs += writetext(IdBoleto.ToString(), 38, 62);//Nº Controle do Participante
            trs += writeint(0, 63, 65);//codigo do banco
            trs += writeint(0, 66, 66);//Multa
            trs += writeint(0, 67, 70);//Percentual de multa
            trs += writetextzero(NossoNumero, 71, 82);
            trs += writeint(0, 83, 92);//Desconto Bonificação por dia
            trs += writeint(2, 93, 93);//Condição para Emissão da Papeleta de Cobrança 2 = Cliente emite e o Banco somente processa o registro
            trs += writetext("N", 94, 94);//Ident. se emite Boleto para Débito Automático
            trs += writetext("", 95, 104);//brancos
            trs += writetext("", 105, 105);//Indicador Rateio Crédito (opcional)
            trs += writetext("2", 106, 106);//Endereçamento para Aviso do Débito Automático em Conta Corrente (opcional)
            trs += writetext("", 107, 108);//Quantidade possíveis de pagamento
            trs += writetext("01", 109, 110);//Identificação da ocorrência remessa
            trs += writetext(Documento, 111, 120);//documento
            trs += writetext(Vencimento.ToString("ddMMyy"), 121, 126);//Data do Vencimento do Título
            trs += writedouble(ValorTitulo, 127, 139);//Valor do Título
            trs += writeint(0, 140, 142);//Banco Encarregado da Cobrança  
            trs += writeint(0, 143, 147);//  Agência Depositária
            trs += writetext("01", 148, 149);//Espécie de Título - 01 duplicata
            trs += writetext("N", 150, 150);//Identificação
            trs += writetext(Emissao.ToString("ddMMyy"), 151, 156);//Data da emissão do Título
            trs += writetext("09", 157, 158);//1ª instrução
            trs += writetext("", 159, 160);//2ª instrução
            trs += writeint(0, 161, 173);//Valor a ser cobrado por Dia de Atraso
            trs += writetext("", 174, 179);//data limite para concessao de desconto
            trs += writeint(0, 180, 192);//Valor do Desconto
            trs += writeint(0, 193, 205);//IOF
            trs += writeint(0, 206, 218);//Valor do Abatimento a ser concedido ou cancelado
            trs += writetext(cpfcnpj.Length == 11 ? "01" : "02", 219, 220);//Identificação do Tipo de Inscrição do Pagador
            trs += writetext(cpfcnpj, 221, 234);//Nº Inscrição do Pagador
            trs += writetext(NomePagador, 235, 274);//Nome do Pagador
            trs += writetext(Endereco, 275, 314);//Endereço Completo
            trs += writetext("", 315, 326);//1ª Mensagem
            trs += writetext(CEP, 327, 334);//cep
            trs += writetext("", 335, 394);//segunda mensagem
            trs += writeint(sequencia, 395, 400);//Nº Seqüencial do Registro 
            return trs;
        }

        public string transacao6(string Carteira,
                                 int Agencia,
                                 int ContaCorrente,
                                 int IdBoleto,
                                 int sequencia,
                                 string NossoNumero)
        {
            string trs = "";
            trs += writeint(6, 1, 1);//Identificação do Registro
            trs += writeint(Convert.ToInt32(Carteira), 2, 4);//Carteira
            trs += writeint(Agencia, 5, 9);//Agência
            trs += writeint(ContaCorrente, 10, 16);//Conta Corrente
            trs += writetextzero(NossoNumero, 17, 28); //NossoNumero(Carteira, IdBoleto);//Nosso Número
            trs += writetext("", 29, 394);// 
            trs += writeint(sequencia, 395, 400);//
            return trs;
        }

        public string trailer(int sequencia)
        {
            string tra = "9" + writetext("", 2, 394) + writeint(sequencia, 395, 400); 
            return tra;
        }

        public string NossoNumero(string pCarteira, int pIdBoleto)
        {
            string C = pCarteira;
            string N = writeint(pIdBoleto, 1, 11);
            int c1 = 2 * Convert.ToInt32(C[0].ToString());
            int c2 = 7 * Convert.ToInt32(C[1].ToString());
            int n1 = 6 * Convert.ToInt32(N[0].ToString());
            int n2 = 5 * Convert.ToInt32(N[1].ToString());
            int n3 = 4 * Convert.ToInt32(N[2].ToString());
            int n4 = 3 * Convert.ToInt32(N[3].ToString());
            int n5 = 2 * Convert.ToInt32(N[4].ToString());
            int n6 = 7 * Convert.ToInt32(N[5].ToString());
            int n7 = 6 * Convert.ToInt32(N[6].ToString());
            int n8 = 5 * Convert.ToInt32(N[7].ToString());
            int n9 = 4 * Convert.ToInt32(N[8].ToString());
            int n10 = 3 * Convert.ToInt32(N[9].ToString());
            int n11 = 2 * Convert.ToInt32(N[10].ToString());
            int Soma = c1 + c2 + n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11;
            int resto = Soma % 11;
            string NossoNumero = N;

            //if(N.Length == 11)
            //{
            //    NossoNumero = N.Substring(1, 10);
            //}

            if (resto == 0)
            {
                return NossoNumero + "0";
            }
            else if (resto == 1)
            {
                return NossoNumero + "P";
            }
            else
            {
                int digito = 11 - resto; 
                return NossoNumero + digito.ToString();
            }
        }

    


        //auxiliares
        private string writetext(string Value, int start, int end)
        {
            string aux = Util.MudaLetra(Value);
            int fieldSize = end - start + 1;
            int i = aux.Length;
            while (i < fieldSize)
            {
                i++;
                aux += " ";
            }

            if (aux.Length > fieldSize)
            {
                aux = aux.Substring(0, fieldSize);
            }
            return aux.ToUpper();
        }

        private string writetextzero(string Value, int start, int end)
        {
            string aux = Util.MudaLetra(Value);
            int fieldSize = end - start + 1;
            int i = aux.Length;
            while (i < fieldSize)
            {
                i++;
                aux = "0" + aux;
            }

            if (aux.Length > fieldSize)
            {
                aux = aux.Substring(0, fieldSize);
            }
            return aux.ToUpper();
        }

        private string writeint(int Value, int start, int end)
        {
            int fieldSize = end - start + 1;
            int i = Value.ToString().Length;
            string aux = Value.ToString();
            while (i < fieldSize)
            {
                i++;
                aux = "0" + aux;
            }

            if (aux.Length > fieldSize)
            {
                aux = aux.Substring(0, fieldSize);
            }
            return aux;
        }

        private string writedouble(decimal Value, int start, int end)
        {
            int fieldSize = end - start + 1;

            string aux = Value.ToString().Replace(",", "").Replace(".", "");
            int i = aux.Length;
            while (i < fieldSize)
            {
                i++;
                aux = "0" + aux;
            }

            if (aux.Length > fieldSize)
            {
                aux = aux.Substring(0, fieldSize);
            }
            return aux;
        }
    }
}
