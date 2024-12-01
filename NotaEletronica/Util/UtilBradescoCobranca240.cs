using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaEletronica.Util
{
    public class UtilBradescoCobranca240
    {


        //public string headerArquivo(
        //                        int LotedeServico,
        //                        string NodeInscricaodaEmpresa,
        //                        string CodigodoConvenionoBanco,
        //                        int AgenciaMantenedoradaConta,
        //                        string DigitoVerificadordaAgencia,
        //                        string NumeroerodaContaCorrente,
        //                        string DigitoVerificadordaConta,
        //                        string DigitoVerificadordaAg_Conta,
        //                        string NomedaEmpresa)
        //{

        //    string header = "";
        //    header += writeint(237, 1, 3);//CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    header += writeint(0, 4, 7);//LotedeServico, 4, 7, 4, -, Num
        //    header += writeint(0, 8, 8);//TipodeRegistro, 8, 8, 1, -, Num, 
        //    header += writetext("", 9, 17);//uso febraban
        //    if (NodeInscricaodaEmpresa.Length == 11)
        //    {
        //        header += writeint(1, 18, 18);//TipodeInscricaodaEmpresa, 18, 18, 1, -, Num
        //    }
        //    else
        //    {
        //        header += writeint(2, 18, 18);//TipodeInscricaodaEmpresa, 18, 18, 1, -, Num
        //    }
        //    header += writetext(NodeInscricaodaEmpresa, 19, 32);//NodeInscricaodaEmpresa, 19, 33, 15, -, Num 
        //    header += writetext(CodigodoConvenionoBanco, 33, 52);//CodigodoConvenionoBanco, 34, 53, 20, -, Alfa
        //    header += writeint(AgenciaMantenedoradaConta, 53, 57);//AgenciaMantenedoradaConta, 54, 58, 5, -, Num
        //    header += writetext(DigitoVerificadordaAgencia, 58, 58);//DigitoVerificadordaConta, 59, 59, 1, -, Alfa
        //    header += writetext(NumeroerodaContaCorrente, 59, 70);//NumerodaContaCorrente, 60, 71, 12, -, Num
        //    header += writetext(DigitoVerificadordaConta, 71, 71);//DigitoVerificadordaConta, 72, 72, 1, -, Alfa
        //    header += writetext(DigitoVerificadordaAg_Conta, 72, 72);//DigitoVerificadordaAg_Conta, 73, 73, 1, -, Alfa
        //    header += writetext(NomedaEmpresa, 73, 102);//NomedaEmpresa, 74, 103, 30, -, Alfa
        //    header += writetext("BANCO BRADESCO", 103, 132);//Mensagem1, 104, 143, 40, -, Alfa
        //    header += writetext("", 133, 142);//Mensagem2, 144, 183, 40, -, Alfa
        //    header += writeint(1, 143, 143);//NumeroSequencialRemessa_Retorno, 184, 191, 8, -, Num
        //    header += writetext(DateTime.Now.ToString("ddMMyyyy"), 144, 151);//DatadeGravacaoRemessa_Retorno, 192, 199, 8, -, Num
        //    header += writetext(DateTime.Now.ToString("hhmmss"), 152, 157);//DatadeGravacaoRemessa_Retorno, 192, 199, 8, -, Num
        //    header += writeint(LotedeServico, 158, 163);//DatadoCredito, 200, 207, 8, -, Num
        //    header += writetext("084", 164, 166);//versao arquivi
        //    header += writetext("", 167, 171);//densidade
        //    header += writetext("", 172, 240);//UsoExclusivoFEBRABAN_CNAB 
        //    return header;
        //}

        //public string headerLote(
        //                        int LotedeServico,
        //                        string NodeInscricaodaEmpresa,
        //                        string CodigodoConvenionoBanco,
        //                        int AgenciaMantenedoradaConta,
        //                        string DigitoVerificadordaAgencia,
        //                        string NumeroerodaContaCorrente,
        //                        string DigitoVerificadordaConta,
        //                        string DigitoVerificadordaAg_Conta,
        //                        string NomedaEmpresa,
        //                        string Mensagem1,
        //                        string Mensagem2)
        //{

        //    string header = "";
        //    header += writeint(237, 1, 3);//CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    header += writeint(LotedeServico, 4, 7);//LotedeServico, 4, 7, 4, -, Num
        //    header += writeint(0, 8, 8);//TipodeRegistro, 8, 8, 1, -, Num, 
        //    header += writetext("R", 9, 9);//TipodeOperacao, 9, 9, 1, -, Alfa, 
        //    header += writetext("01", 10, 11);//TipodeServico, 10, 11, 2, -, Num
        //    header += writetext("", 12, 13);//UsoExclusivoFEBRABAN_CNAB, 12, 13, 2, -, Alfa
        //    header += writetext("042", 14, 16);//NodaVersaodoLayoutdoLote, 14, 16, 3, -, Num
        //    header += writetext("", 17, 17);//UsoExclusivoFEBRABAN_CNAB, 17, 17, 1, -, Alfa
        //    if (NodeInscricaodaEmpresa.Length == 11)
        //    {
        //        header += writeint(1, 18, 18);//TipodeInscricaodaEmpresa, 18, 18, 1, -, Num
        //    }
        //    else
        //    {
        //        header += writeint(2, 18, 18);//TipodeInscricaodaEmpresa, 18, 18, 1, -, Num
        //    }
        //    header += writetext(NodeInscricaodaEmpresa, 19, 33);//NodeInscricaodaEmpresa, 19, 33, 15, -, Num
        //    header += writetext(CodigodoConvenionoBanco, 34, 53);//CodigodoConvenionoBanco, 34, 53, 20, -, Alfa
        //    header += writeint(AgenciaMantenedoradaConta, 54, 58);//AgenciaMantenedoradaConta, 54, 58, 5, -, Num
        //    header += writetext(DigitoVerificadordaAgencia, 59, 59);//DigitoVerificadordaConta, 59, 59, 1, -, Alfa
        //    header += writetext(NumeroerodaContaCorrente, 60, 71);//NumerodaContaCorrente, 60, 71, 12, -, Num
        //    header += writetext(DigitoVerificadordaConta, 72, 72);//DigitoVerificadordaConta, 72, 72, 1, -, Alfa
        //    header += writetext(DigitoVerificadordaAg_Conta, 73, 73);//DigitoVerificadordaAg_Conta, 73, 73, 1, -, Alfa
        //    header += writetext(NomedaEmpresa, 74, 103);//NomedaEmpresa, 74, 103, 30, -, Alfa
        //    header += writetext(Mensagem1, 104, 143);//Mensagem1, 104, 143, 40, -, Alfa
        //    header += writetext(Mensagem2, 144, 183);//Mensagem2, 144, 183, 40, -, Alfa
        //    header += writeint(LotedeServico, 184, 191);//NumeroSequencialRemessa_Retorno, 184, 191, 8, -, Num
        //    header += writetext(DateTime.Now.ToString("ddMMyyyy"), 192, 199);//DatadeGravacaoRemessa_Retorno, 192, 199, 8, -, Num
        //    header += writetext("", 200, 207);//DatadoCredito, 200, 207, 8, -, Num
        //    header += writetext("", 208, 240);//UsoExclusivoFEBRABAN_CNAB, 208, 240, 33, -, Alfa
        //    return header;
        //}

        //public string SegmentoP(
        //                        int LotedeServico,
        //                        int NoSequencialdoRegistronoLote, 
        //                        int AgenciaMantenedoradaConta,
        //                        string DigitoVerificadordaAgencia,
        //                        int NumerodaContaCorrente,
        //                        string DigitoVerificadordaConta,
        //                        string DigitoVerificadordaAg_Conta, 
        //                        int NossoNumero,
        //                        int DigitodonossoNumero,    
        //                        string NumerodoDocumentodeCobranca,
        //                        string DatadeVencimentodoTitulo,
        //                        decimal ValorNominaldoTitulo,
        //                        int AgenciaEncarregadadaCobranca,
        //                        string DigitoVerificadordaAgencia2, 
        //                        string DatadaEmissaodoTitulo,   
        //                        int IdentificacaodoTitulonaEmpresa,    
        //                        int NumeroContrato)
        //{
        //    string sp = "";
        //    sp += writeint(237, 1, 3);//	CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    sp += writeint(LotedeServico, 4, 7);//	LotedeServico, 4, 7, 4, -, Num
        //    sp += writetext("3", 8, 8);//	TipodeRegistro, 8, 8, 1, -, Num, '3'
        //    sp += writeint(NoSequencialdoRegistronoLote, 9, 13);//	NoSequencialdoRegistronoLote, 9, 13, 5, -, Num
        //    sp += writetext("P", 14, 14);//	CodSegmentodoRegistroDetalhe, 14, 14, 1, -, Alfa, 'P'
        //    sp += writetext("", 15, 15);//	UsoExclusivoFEBRABAN_CNAB, 15, 15, 1, -, Alfa, Brancos
        //    sp += writetext("01", 16, 17);//	CodigodeMovimentoRemessa, 16, 17, 2, -, Num
        //    sp += writeint(AgenciaMantenedoradaConta, 18, 22);//	AgenciaMantenedoradaConta, 18, 22, 5, -, Num
        //    sp += writetext(DigitoVerificadordaAgencia, 23, 23);//	DigitoVerificadordaAgencia, 23, 23, 1, -, Alfa
        //    sp += writeint(NumerodaContaCorrente, 24, 35);//	NumerodaContaCorrente, 24, 35, 12, -, Num
        //    sp += writetext(DigitoVerificadordaConta, 36, 36);//	DigitoVerificadordaConta, 36, 36, 1, -, Alfa
        //    sp += writetext(DigitoVerificadordaAg_Conta, 37, 37);//	DigitoVerificadordaAg_Conta, 37, 37, 1, -, Alfa
        //    sp += writeint(0, 38, 40);//	IdentificacaodoProduto, 38, 40, 3, Num
        //    sp += writeint(0, 41, 45);//Zeros, 41, 45, 5, Num
        //    sp += writeint(NossoNumero, 46, 56);//	NossoNumero, 46, 56, 11, Num
        //    sp += writeint(DigitodonossoNumero, 57, 57);//	DigitodonossoNumero, 57, 57, 1, Num
        //    sp += writeint(1, 58, 58);//	CodigodaCarteira, 58, 58, 1, -, Num
        //    sp += writeint(1, 59, 59);//	FormadeCadastrdoTitulonoBanco, 59, 59, 1, -, Num
        //    sp += writeint(1, 60, 60);//	TipodeDocumento, 60, 60, 1, -, Alfa
        //    sp += writeint(2, 61, 61);//	IdentificacaodaEmissaodoBloqueto, 61, 61, 1, -, Num
        //    sp += writeint(2, 62, 62); //	IdentificacaodaDistribuicao, 62, 62, 1, -, Alfa
        //    sp += writetext(NumerodoDocumentodeCobranca, 63, 77); //	NumerodoDocumentodeCobranca, 63, 77, 15, -, Alfa
        //    sp += writetext(DatadeVencimentodoTitulo, 78, 85);//	DatadeVencimentodoTitulo, 78, 85, 8, -, Num
        //    sp += writedouble(ValorNominaldoTitulo, 86, 100);//	ValorNominaldoTitulo, 86, 100, 13, 2, Num
        //    sp += writeint(AgenciaEncarregadadaCobranca, 101, 105);//	AgenciaEncarregadadaCobranca, 101, 105, 5, -, Num
        //    sp += writetext(DigitoVerificadordaAgencia2, 106, 106);//	DigitoVerificadordaAgencia, 106, 106, 1, -, Alfa
        //    sp += writetext("02", 107, 108);//	EspeciedoTitulo, 107, 108, 2, -, Num
        //    sp += writetext("N", 109, 109);//	IdentificdeTituloAceito_NaoAceito, 109, 109, 1, -, Alfa
        //    sp += writetext(DatadaEmissaodoTitulo, 110, 117); //	DatadaEmissaodoTitulo, 110, 117, 8, -, Num
        //    sp += writeint(3, 118, 118);//	CodigodoJurosdeMora, 118, 118, 1, -, Num
        //    sp += writetext("", 119, 126);//	DatadoJurosdeMora, 119, 126, 8, -, Num
        //    sp += writedouble(0, 127, 141);//	JurosdeMoraporDia_Taxa, 127, 141, 13, 2, Num
        //    sp += writeint(1, 142, 142);//	CodigodoDesconto, 142, 142, 1, -, Num
        //    sp += writetext("", 143, 150);//	DatadoDesconto, 143, 150, 8, -, Num
        //    sp += writeint(0, 151, 165);//	Valor_PercentualaserConcedido, 151, 165, 13, 2, Num
        //    sp += writeint(0, 166, 180);//	ValordoIOFaserRecolhido, 166, 180, 13, 2, Num
        //    sp += writeint(0, 181, 195);//	ValordoAbatimento, 181, 195, 13, 2, Num
        //    sp += writeint(IdentificacaodoTitulonaEmpresa, 196, 220);//	IdentificacaodoTitulonaEmpresa, 196, 220, 25, -, Alfa
        //    sp += writeint(3, 221, 221);//	CodigoparaProtesto, 221, 221, 1, -, Num
        //    sp += writeint(0, 222, 223);//	NumerodeDiasparaProtesto, 222, 223, 2, -, Num
        //    sp += writeint(1, 224, 224);//	CodigoparaBaixa_Devolucao, 224, 224, 1, -, Num
        //    sp += writeint(0, 225, 227); //	NumerodeDiasparaBaixa_Devolucao, 225, 227, 3, -, Alfa
        //    sp += writetext("09", 228, 229);//	CodigodaMoeda, 228, 229, 2, -, Num
        //    sp += writeint(NumeroContrato, 230, 239);//	NodoContratodaOperacaodeCred, 230, 239, 10, -, Num
        //    sp += writetext("", 240, 240);//	UsoExclusivoFEBRABAN_CNAB, 240, 240, 1, -, Alfa, Brancos


        //    return sp;
        //}

        //public string SegmentoQ(
        //                        int LotedeServico,
        //                        int NoSequencialdoRegistronoLote,
        //                        string NumerodeInscricao,
        //                        string Nome,
        //                        string Endereco,
        //                        string Bairro,
        //                        string CEP,
        //                        string SufixodoCEP,
        //                        string Cidade,
        //                        string UnidadedaFederacao)
        //{
        //    string sq = "";
        //    sq += writeint(237, 1, 3);//  CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    sq += writeint(LotedeServico, 4, 7);//  LotedeServico, 4, 7, 4, -, Num
        //    sq += writetext("3", 8, 8);//, 1, -, Num,;//  TipodeRegistro, 8, 8, 1, -, Num, ‘3’
        //    sq += writeint(NoSequencialdoRegistronoLote, 9, 13);//  NoSequencialdoRegistronoLote, 9, 13, 5, -, Num
        //    sq += writetext("Q", 14, 14);//  CodSegmentodoRegistroDetalhe, 14, 14, 1, -, Alfa, ‘Q’
        //    sq += writetext("", 15, 15);//  UsoExclusivoFEBRABAN_CNAB, 15, 15, 1, -, Alfa, Brancos
        //    sq += writetext("01", 16, 17);//  CodigodeMovimentoRemessa, 16, 17, 2, -, Num
        //    if(NumerodeInscricao.Length == 14)
        //    {
        //        sq += writetext("2", 18, 18);//, 1, -, N;//  TipodeInscricao, 18, 18, 1, -, Num
        //    }
        //    else
        //    {
        //        sq += writetext("1", 18, 18);//, 1, -, N;//  TipodeInscricao, 18, 18, 1, -, Num
        //    }

        //    sq += writetext(NumerodeInscricao, 19, 33);//, 15, -;//  NumerodeInscricao, 19, 33, 15, -, Num
        //    sq += writetext(Nome, 34, 73);//, 40, -, Alfa;//  Nome, 34, 73, 40, -, Alfa
        //    sq += writetext(Endereco, 74, 113);//, 40, -, Alfa;//  Endereco, 74, 113, 40, -, Alfa
        //    sq += writetext(Bairro, 114, 128);//, 15, -, Alfa;//  Bairro, 114, 128, 15, -, Alfa
        //    sq += writetext(CEP, 129, 133);//, 5, -, Num;//  CEP, 129, 133, 5, -, Num
        //    sq += writetext(SufixodoCEP, 134, 136);//, 3, -, Num;//  SufixodoCEP, 134, 136, 3, -, Num
        //    sq += writetext(Cidade, 137, 151);//, 15, -, Alfa;//  Cidade, 137, 151, 15, -, Alfa
        //    sq += writetext(UnidadedaFederacao, 152, 153);//, 2,;//  UnidadedaFederacao, 152, 153, 2, -, Alfa
        //    if (NumerodeInscricao.Length == 14)
        //    {
        //        sq += writetext("2", 154, 154);//, 1, -, N;//  TipodeInscricao, 18, 18, 1, -, Num
        //    }
        //    else
        //    {
        //        sq += writetext("1", 154, 154);//, 1, -, N;//  TipodeInscricao, 18, 18, 1, -, Num
        //    }
        //    sq += writetext(NumerodeInscricao, 155, 169);//, 15,;//  NumerodeInscricao, 155, 169, 15, -, Num
        //    sq += writetext(Nome, 170, 209);//  NomedoPagadorr_Avalista, 170, 209, 40, -, Alfa
        //    sq += writetext("", 210, 212);//  CodBcoCorrespnaCompensacao, 210, 212, 3, -, Num
        //    sq += writetext("", 213, 232);//  NossoNonoBancoCorrespondente, 213, 232, 20, -, Alfa
        //    sq += writetext("", 233,240);//  UsoExclusivoFEBRABAN_CNAB, 233, 240, 8, -, Alfa, Brancos
        //    return sq;
        //}



        //public string TrailerLote(
        //                        int LotedeServico,
        //                        int QuantidadedeRegistrosnoLote,
        //                        int QuantidadedeTitulosemCobranca,
        //                        decimal ValorTotaldosTitulosemCarteiras)
        //{
        //    string tl = "";
        //    tl += writeint(237, 1, 3);//, 3,  ;//CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    tl += writeint(LotedeServico, 4, 7);//, 4, -, Num  ;//LotedeServico, 4, 7, 4, -, Num
        //    tl += writeint(5, 8, 8);//, 1, -, Num, ‘5’  ;//TipodeRegistro, 8, 8, 1, -, Num, ‘5’
        //    tl += writetext("", 9, 17);//, 9,  ;//UsoExclusivoFEBRABAN_CNAB, 9, 17, 9, -, Alfa, Brancos
        //    tl += writeint(QuantidadedeRegistrosnoLote, 18, 23);//,  ;//QuantidadedeRegistrosnoLote, 18, 23, 6, -, Num
        //    tl += writeint(QuantidadedeTitulosemCobranca, 24, 29);//  ;//QuantidadedeTitulosemCobranca, 24, 29, 6, -, Num
        //    tl += writedouble(ValorTotaldosTitulosemCarteiras, 30, 46);// ;//ValorTotaldosTitulosemCarteiras, 30, 46, 15, 2, Num
        //    tl += writeint(0, 47, 52);//  ;//QuantidadedeTitulosemCobranca, 47, 52, 6, -, Num
        //    tl += writeint(0, 53, 69);//  ;//ValorTotaldosTitulosemCarteiras, 53, 69, 15, 2, Num
        //    tl += writeint(0, 70, 75);//  ;//QuantidadedeTitulosemCobranca, 70, 75, 6, -, Num
        //    tl += writeint(0, 76, 92);//   ;//QuantidadedeTitulosemCarteiras, 76, 92, 15, 2, Num
        //    tl += writeint(0, 93, 98);//  ;//QuantidadedeTitulosemCobranca, 93, 98, 6, -, Nim
        //    tl += writeint(0, 99, 115);// ;//ValorTotaldosTitulosemCarteiras, 99, 115, 15, 2, Num
        //    tl += writetext("", 116, 123);//,  ;//NumerodoAvisodeLancamento, 116, 123, 8, -, Alfa
        //    tl += writetext("", 124, 240);//,  ;//UsoExclusivoFEBRABAN_CNAB, 124, 240, 117, -, Alfa, Brancos
        //    return tl;
        //}

        //public string TrailerArquivo(
        //                        int LotedeServico,
        //                        int QuantidadedeRegistrosdoArquivo)
        //{
        //    string ta = "";
        //    ta += writeint(237, 1, 3);//  ;//CodigodoBanconaCompensacao, 1, 3, 3, -, Num
        //    ta += writeint(LotedeServico, 4, 7);//, 4, -, Num,   ;//LotedeServico, 4, 7, 4, -, Num, '9999'
        //    ta += writeint(9, 8, 8);//, 1, -, Num,  ;//TipodeRegistro, 8, 8, 1, -, Num, '9'
        //    ta += writetext("", 9, 17);//  ;//UsoExclusivoFEBRABAN_CNAB, 9, 17, 9, -, Alfa, Brancos
        //    ta += writeint(1, 18, 23);//   ;//QuantidadedeLotesdoArquivo, 18, 23, 6, -, Num
        //    ta += writeint(QuantidadedeRegistrosdoArquivo, 24, 29);//   ;//QuantidadedeRegistrosdoArquivo, 24, 29, 6, -, Num
        //    ta += writeint(0, 30, 35);//  ;//QtdedeContasp_Conc(Lotes), 30, 35, 6, -, Num
        //    ta += writetext("", 36, 240);//  ;//UsoExclusivoFEBRABAN_CNAB, 36, 240, 205, -, Alfa, Brancos
        //    return ta;
        //}


        ////auxiliares
        //private string writetext(string Value, int start, int end)
        //{
        //    string aux = Util.MudaLetra(Value);
        //    int fieldSize = end - start + 1;
        //    int i = aux.Length;
        //    while (i < fieldSize)
        //    {
        //        i++;
        //        aux += " ";
        //    }

        //    if (aux.Length > fieldSize)
        //    {
        //        aux = aux.Substring(0, fieldSize);
        //    }
        //    return aux;
        //}

        //private string writeint(int Value, int start, int end)
        //{
        //    int fieldSize = end - start + 1;
        //    int i = Value.ToString().Length;
        //    string aux = Value.ToString();
        //    while (i < fieldSize)
        //    {
        //        i++;
        //        aux = "0" + aux;
        //    }

        //    if (aux.Length > fieldSize)
        //    {
        //        aux = aux.Substring(0, fieldSize);
        //    }
        //    return aux;
        //}

        //private string writedouble(decimal Value, int start, int end)
        //{
        //    int fieldSize = end - start + 1;

        //    string aux = Value.ToString().Replace(",", "").Replace(".", "");
        //    int i = aux.Length;
        //    while (i < fieldSize)
        //    {
        //        i++;
        //        aux = "0" + aux;
        //    }

        //    if (aux.Length > fieldSize)
        //    {
        //        aux = aux.Substring(0, fieldSize);
        //    }
        //    return aux;
        //}
    }
}
