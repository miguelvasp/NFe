using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoNet;
using Boleto = BoletoNet.Boleto;
using System.Windows.Forms;
using System.IO;
using NotaEletronica.DAL;

namespace NotaEletronica.BLL
{
    public enum Bancos
    {
        BancodoBrasil = 1,
        Banrisul = 41,
        Basa = 3,
        Bradesco = 237,
        BRB = 70,
        Caixa = 104,
        HSBC = 399,
        Itau = 341,
        Real = 356,
        Safra = 422,
        Santander = 33,
        Sicoob = 756,
        Sicred = 748,
        Sudameris = 347,
        Unibanco = 409
    }



    public class BLBoletos
    {
        public BoletoBancario boletoBancario { get; set; } 
        BoletoNet.Boleto b = new BoletoNet.Boleto();
        int Instrucao;
        int nroDias; 

        public BLBoletos(int Banco, Models.Boleto p)
        {
            try
            {
                boletoBancario = new BoletoBancario();
                boletoBancario.CodigoBanco = (short)Banco;

                //Monta os campos do boleto
                b.DataVencimento = Convert.ToDateTime(p.Vencimento);
                b.ValorBoleto = Convert.ToDecimal(p.ValorBoleto);
                b.Carteira = p.Carteira;
                Cedente c = new Cedente(p.cedente_cpf, p.cedente_nome, p.cedente_agencia, p.cedente_digitoagencia, p.cedente_conta, p.cedente_digitoconta, "7");
                c.Codigo = p.cedente_codigo;
                b.Cedente = c;
                b.NumeroDocumento = p.NumeroDocumento;
                b.Sacado = new Sacado(p.sacado_cpf, p.sacado_nome);
                b.Sacado.Endereco.End = p.sacado_endereco;
                b.Sacado.Endereco.Bairro = p.sacado_bairro;
                b.Sacado.Endereco.Cidade = p.sacado_cidade;
                b.Sacado.Endereco.CEP = p.sacado_cep;
                b.Sacado.Endereco.UF = p.sacado_uf;
                b.NossoNumero = p.NossoNumero.Length == 12 ? p.NossoNumero.Substring(0, 11) : p.NossoNumero;
                b.DigitoNossoNumero = p.NossoNumero.Length == 12 ? p.NossoNumero.Substring(11, 1) : "";
                Instrucao = Convert.ToInt32(p.Instrucao);
                nroDias = Convert.ToInt32(p.nroDias);
                //Instrucao_Bradesco item = new Instrucao_Bradesco(Instrucao, nroDias);
                //item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                //b.Instrucoes.Add(item);
                if (!String.IsNullOrEmpty(p.InstrucaoDescricao2))
                {
                    Instrucao i = new Instrucao(p.numeroBanco);
                    i.Descricao = p.InstrucaoDescricao2;
                    b.Instrucoes.Add(i);
                }

                if (!String.IsNullOrEmpty(p.InstrucaoDescricao3))
                {
                    Instrucao i = new Instrucao(p.numeroBanco);
                    i.Descricao = p.InstrucaoDescricao3;
                    b.Instrucoes.Add(i);
                }
            }
            catch  
            {
                 
            }
           

        }

        public string BancodoBrasil()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            #region Exemplo Carteira 16, com nosso número de 11 posições
            /*
         * Nesse exemplo utilizamos a carteira 16 e o nosso número no máximo de 11 posições.
         * Não é necessário informar o numero do convênio e nem o tipo da modalidade.
         * O nosso número tem que ter no máximo 11 posições.
         */

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01m, "16", "09876543210", c);

            #endregion Exemplo Carteira 16, com nosso número de 11 posições

            #region Exemplo Carteira 16, convênio de 6 posições e tipo modalidade 21
            /*
         * Nesse exemplo utilizamos a carteira 16 e o número do convênio de 6 posições.
         * É obrigatório informar o tipo da modalidade 21.
         * O nosso número tem que ter no máximo 10 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //c.Convenio = 123456;

            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "16", "09876543210", c);
            //b.TipoModalidade = "21";
            #endregion Exemplo Carteira 16, convênio de 6 posições e tipo modalidade 21

            #region Exemplo Carteira 18, com nosso número de 11 posições
            /*
         * Nesse exemplo utilizamos a carteira 18 e o nosso número no máximo de 11 posições.
         * Não é necessário informar o numero do convênio e nem o tipo da modalidade.
         * O nosso número tem que ter no máximo 11 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "18", "09876543210", c);

            #endregion Exemplo Carteira 18, com nosso número de 11 posições

            #region Exemplo Carteira 18, convênio de 6 posições e tipo modalidade 21
            /*
         * Nesse exemplo utilizamos a carteira 18 e o número do convênio de 6 posições.
         * É obrigatório informar o tipo da modalidade 21.
         * O nosso número tem que ter no máximo 10 posições.
         */

            //Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "1", "123456", "1");
            //c.Convenio = 123456;
            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01, "18", "09876543210", c);
            //b.TipoModalidade = "21";
            #endregion Exemplo Carteira 18, convênio de 6 posições e tipo modalidade 21


            b.NumeroDocumento = "12415487";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //Adiciona as instruções ao boleto
            #region Instruções
            //Protestar
            Instrucao_BancoBrasil item = new Instrucao_BancoBrasil(9, 5);
            b.Instrucoes.Add(item);
            //ImportanciaporDiaDesconto
            item = new Instrucao_BancoBrasil(30, 0);
            b.Instrucoes.Add(item);
            //ProtestarAposNDiasCorridos
            item = new Instrucao_BancoBrasil(81, 15);
            b.Instrucoes.Add(item);
            #endregion Instruções

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            boletoBancario.RemoveSimboloMoedaValorDocumento = true;
            boletoBancario.AjustaTamanhoFonte(12, 10, 14, 14);

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Banrisul()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "5", "12345678", "9");

            c.Codigo = "00000000504";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 45.50m, "18", "12345678901", c);

            b.Sacado = new Sacado("000.000.000-00", "Fulano de Silva");
            b.Sacado.Endereco.End = "SSS 154 Bloco J Casa 23";
            b.Sacado.Endereco.Bairro = "Testando";
            b.Sacado.Endereco.Cidade = "Testelândia";
            b.Sacado.Endereco.CEP = "70000000";
            b.Sacado.Endereco.UF = "DF";

            //Adiciona as instruções ao boleto
            #region Instruções
            //Protestar
            Instrucao_Banrisul item = new Instrucao_Banrisul(9, 10, 0);
            b.Instrucoes.Add(item);
            #endregion Instruções

            b.NumeroDocumento = "12345678901";


            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Basa()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "5", "12345678", "9");

            c.Codigo = "12548";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 45.50m, "CNR", "125478", c);

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";


            b.NumeroDocumento = "12345678901";

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            boletoBancario.Cedente.Endereco = new Endereco()
            {
                End = "Endereço do Cedente",
                Bairro = "Bairro",
                Cidade = "Cidade",
                CEP = "70000000",
                UF = "DF"

            };

            //boletoBancario.MostrarEnderecoCedente = true;

            //boletoBancario.AjustaTamanhoFonte(12, tamanhoFonteInstrucaoImpressao: 14);
            boletoBancario.RemoveSimboloMoedaValorDocumento = false;

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Bradesco()
        {  
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true; 
            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida(); 
            return boletoBancario.MontaHtmlEmbedded();
        }

        public byte[] BradescoPDF()
        {
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = false;
            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();
            return boletoBancario.MontaBytesPDF();
        }

        public string BRB()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "208", "", "010357", "6");
            c.Codigo = "13000";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.01m, "COB", "119964", c);
            b.NumeroDocumento = "119964";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //b.Instrucoes.Add("Não Receber após o vencimento");
            //b.Instrucoes.Add("Após o Vencimento pague somente no Bradesco");
            //b.Instrucoes.Add("Instrução 2");
            //b.Instrucoes.Add("Instrução 3");

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Caixa()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("000.000.000-00", "Boleto.net ILTDA", "1234", "12345678", "9");

            c.Codigo = "112233";


            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 20.00m, "2", "0123456789", c);

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //Adiciona as instruções ao boleto
            #region Instruções
            Instrucao_Caixa item;
            //ImportanciaporDiaDesconto
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.Multa, Convert.ToDecimal(0.40));
            b.Instrucoes.Add(item);
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.JurosdeMora, Convert.ToDecimal(0.01));
            b.Instrucoes.Add(item);
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.NaoReceberAposNDias, 90);
            b.Instrucoes.Add(item);
            #endregion Instruções

            EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
            b.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
            b.NumeroDocumento = "00001";
            b.DataProcessamento = DateTime.Now;
            b.DataDocumento = DateTime.Now;

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string HSBC()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Minha empresa", "0000", "", "00000", "00");
            // Código fornecido pela agencia, NÃO é o numero da conta
            c.Codigo = "0000000"; // 7 posicoes

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 2, "CNR", "1330001490684", c); //cod documento
            b.NumeroDocumento = "9999999999999"; // nr documento

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Itau()
        {
            DateTime vencimento = DateTime.Now.AddDays(1);

            Instrucao_Itau item1 = new Instrucao_Itau(9, 5);
            Instrucao_Itau item2 = new Instrucao_Itau(81, 10);
            Cedente c = new Cedente("10.823.650/0001-90", "SAFIRALIFE", "4406", "22324");
            //Na carteira 198 o código do Cedente é a conta bancária
            c.Codigo = "13000";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.1m, "176", "00000001", c, new EspecieDocumento(341, "1"));
            b.NumeroDocumento = "00000001";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            // Exemplo de como adicionar mais informações ao sacado
            b.Sacado.InformacoesSacado.Add(new InfoSacado("TÍTULO: " + "2541245"));

            item2.Descricao += " " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item1);
            b.Instrucoes.Add(item2);

            // juros/descontos

            if (b.ValorDesconto == 0)
            {
                Instrucao_Itau item3 = new Instrucao_Itau(999, 1);
                item3.Descricao += ("1,00 por dia de antecipação.");
                b.Instrucoes.Add(item3);
            }

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Real()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Coloque a Razão Social da sua empresa aqui", "1234", "12345");
            c.Codigo = "12345";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.1m, "57", "123456", c, new EspecieDocumento(356, "9"));
            b.NumeroDocumento = "1234567";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //b.Instrucoes.Add("Não Receber após o vencimento");
            //b.Instrucoes.Add("Após o Vencimento pague somente no Real");
            //b.Instrucoes.Add("Instrução 2");
            //b.Instrucoes.Add("Instrução 3");
            boletoBancario.Boleto = b;

            EspeciesDocumento ed = EspecieDocumento_Real.CarregaTodas();
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Safra()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "0542", "5413000");

            c.Codigo = "13000";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 1642, "198", "02592082835", c);
            b.NumeroDocumento = "1008073";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //b.Instrucoes.Add("Não Receber após o vencimento");
            //b.Instrucoes.Add("Após o Vencimento pague somente no Bradesco");
            //b.Instrucoes.Add("Instrução 2");
            //b.Instrucoes.Add("Instrução 3");

            Instrucao_Safra instrucao = new Instrucao_Safra();
            instrucao.Descricao = "Instrução 1";

            b.Instrucoes.Add(instrucao);


            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Santander()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "2269", "130000946");
            c.Codigo = "1795082";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.20m, "101", "566612457800", c);

            //NOSSO NÚMERO
            //############################################################################################################################
            //Número adotado e controlado pelo Cliente, para identificar o título de cobrança.
            //Informação utilizada pelos Bancos para referenciar a identificação do documento objeto de cobrança.
            //Poderá conter número da duplicata, no caso de cobrança de duplicatas, número de apólice, no caso de cobrança de seguros, etc.
            //Esse campo é devolvido no arquivo retorno.
            b.NumeroDocumento = "0282033";

            b.Sacado = new Sacado("000.000.000-00", "Fulano de Silva");
            b.Sacado.Endereco.End = "SSS 154 Bloco J Casa 23";
            b.Sacado.Endereco.Bairro = "Testando";
            b.Sacado.Endereco.Cidade = "Testelândia";
            b.Sacado.Endereco.CEP = "70000000";
            b.Sacado.Endereco.UF = "DF";

            //Espécie Documento - [R] Recibo
            b.EspecieDocumento = new EspecieDocumento_Santander("17");

            boletoBancario.Boleto = b;
            boletoBancario.MostrarCodigoCarteira = true;

            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Sicoob()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);


            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "4444", "", "", "");

            c.Codigo = "123456";
            c.DigitoCedente = 7;
            c.Carteira = "1";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 10, "1", "897654321", c);
            b.NumeroDocumento = "119964";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Sicred()
        {

            DateTime vencimento = DateTime.Now.AddDays(1);

            Instrucao_Sicredi item1 = new Instrucao_Sicredi(9, 5);
            Instrucao_Sicredi item2 = new Instrucao_Sicredi();

            Cedente c = new Cedente("10.823.650/0001-90", "SAFIRALIFE", "0811", "81111");
            c.Codigo = "08111081111";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.1m, "1", "00000001", c);
            b.NumeroDocumento = "00000001";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            // Exemplo de como adicionar mais informações ao sacado
            b.Sacado.InformacoesSacado.Add(new InfoSacado("TÍTULO: " + "2541245"));

            item2.Descricao += " " + item1.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item1);



            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Sudameris()
        {
            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "0501", "6703255");

            c.Codigo = "13000";

            //Nosso número com 7 dígitos
            string nn = "0003020";
            //Nosso número com 13 dígitos
            //nn = "0000000003025";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 1642, "198", nn, c);// EnumEspecieDocumento_Sudameris.DuplicataMercantil);
            b.NumeroDocumento = "1008073";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //b.Instrucoes.Add("Não Receber após o vencimento");
            //b.Instrucoes.Add("Após o Vencimento pague somente no Sudameris");
            //b.Instrucoes.Add("Instrução 2");
            //b.Instrucoes.Add("Instrução 3");

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public string Unibanco()
        {
            // ----------------------------------------------------------------------------------------
            // Exemplo 1

            //DateTime vencimento = new DateTime(2001, 12, 31);

            //Cedente c = new Cedente("00.000.000/0000-00", "Next Consultoria", "1234", "5", "123456", "7");
            //c.Codigo = 123456;

            //BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 1000.00, "20", "1803029901", c);
            //b.NumeroDocumento = b.NossoNumero;

            // ----------------------------------------------------------------------------------------
            // Exemplo 2

            DateTime vencimento = DateTime.Now.AddDays(10);

            Cedente c = new Cedente("00.000.000/0000-00", "Next Consultoria Ltda.", "0123", "100618", "9");
            c.Codigo = "203167";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 2952.95m, "20", "1803029901", c);
            b.NumeroDocumento = b.NossoNumero;

            // ----------------------------------------------------------------------------------------

            //b.Instrucoes.Add("Não receber após o vencimento");
            //b.Instrucoes.Add("Após o vencimento pague somente no Unibanco");
            //b.Instrucoes.Add("Taxa bancária - R$ 2,95");
            //b.Instrucoes.Add("Emitido pelo componente Boleto.NET");

            // ----------------------------------------------------------------------------------------

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaHtmlEmbedded();
        }

        public byte[] ItauPDF()
        {
            DateTime vencimento = DateTime.Now.AddDays(1);

            Instrucao_Itau item1 = new Instrucao_Itau(9, 5);
            Instrucao_Itau item2 = new Instrucao_Itau(81, 10);
            Cedente c = new Cedente("10.823.650/0001-90", "SAFIRALIFE", "4406", "22324");
            //Na carteira 198 o código do Cedente é a conta bancária
            c.Codigo = "13000";

            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 0.1m, "176", "00000001", c, new EspecieDocumento(341, "1"));
            b.NumeroDocumento = "00000001";

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            // Exemplo de como adicionar mais informações ao sacado
            b.Sacado.InformacoesSacado.Add(new InfoSacado("TÍTULO: " + "2541245"));

            item2.Descricao += " " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item1);
            b.Instrucoes.Add(item2);

            // juros/descontos

            if (b.ValorDesconto == 0)
            {
                Instrucao_Itau item3 = new Instrucao_Itau(999, 1);
                item3.Descricao += ("1,00 por dia de antecipação.");
                b.Instrucoes.Add(item3);
            }

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario.MontaBytesPDF();
        }

        public void GeraArquivoCNAB400(int lote, List<Models.Boleto> Boletos, Models.BoletoConfiguracoes config, Models.NFeEmitente emit)
        {
            Util.UtilBradescoCobranca400 cnab = new Util.UtilBradescoCobranca400();

            //if (!Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\"))
            //{
            //    Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\");
            //}

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();

            if(string.IsNullOrEmpty(fd.SelectedPath))
            {
                MessageBox.Show("Selecione uma pasta de destino");
                return;
            }


            //string filepath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\" + lote.ToString().PadLeft(5, '0') + ".REM";
            string filepath = fd.SelectedPath + "\\" + lote.ToString().PadLeft(5, '0') + ".REM";
            StreamWriter xfile = new StreamWriter(filepath, false, Encoding.ASCII);


            Models.NFeEmitente em = new DAL.NFeEmitenteDAL().GetByID(1);

            //gera o header 
            string header = cnab.headerArquivo(Convert.ToInt32(config.Codigo), em.emi_xNome, lote);
            xfile.WriteLine(header);
             

            int qtdeBoletos = 1;
            decimal Soma = 0;
            foreach (var b in Boletos)
            {
                qtdeBoletos++;

                //transacao
                string transacao = cnab.Transacao(config.Cateira,
                                                  Convert.ToInt32(config.Agencia),
                                                  Convert.ToInt32(config.ContaCorrente),
                                                  Convert.ToInt32(config.DigitoContaCorrente),
                                                  b.IdBoleto,
                                                  b.NossoNumero,
                                                  b.NumeroDocumento,
                                                  (DateTime)b.Vencimento,
                                                  (decimal)b.ValorBoleto,
                                                  (DateTime)b.Emissao,
                                                  b.sacado_cpf,
                                                  b.sacado_nome,
                                                  b.sacado_endereco,
                                                  b.sacado_cep,
                                                  qtdeBoletos);
                xfile.WriteLine(transacao);
                qtdeBoletos++;
                string transacao6 = cnab.transacao6(config.Cateira, Convert.ToInt32(config.Agencia), Convert.ToInt32(config.ContaCorrente), b.IdBoleto, qtdeBoletos, b.NossoNumero);
                xfile.WriteLine(transacao6);
            }

            //trailer do lote
            qtdeBoletos++;
            string trailer = cnab.trailer(qtdeBoletos);
            xfile.WriteLine(trailer);

            xfile.Close();
            MessageBox.Show("Arquivo gerado com sucesso!");
            System.Diagnostics.Process.Start(
                "explorer.exe",
                string.Format("/select, \"{0}\"", filepath));

        }

        //public void GeraArquivoCNAB240(int lote, List<Models.Boleto> Boletos, Models.BoletoConfiguracoes config, Models.NFeEmitente emit)
        //{
        //    Util.UtilBradescoCobranca240 cnab = new Util.UtilBradescoCobranca240();

        //    if(!Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\"))
        //    {
        //        Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\");
        //    }


        //    string filepath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ArquivosBoletos\\" + lote.ToString().PadLeft(5, '0') + ".REM";
        //    StreamWriter xfile = new StreamWriter(filepath, false, Encoding.ASCII);

        //    //gera o header do arquivo
        //    xfile.WriteLine(cnab.headerArquivo(lote, 
        //                                       emit.emi_IE, 
        //                                       config.Convenio, 
        //                                       Convert.ToInt32(config.Agencia), 
        //                                       config.DigitoAgencia, 
        //                                       config.ContaCorrente, 
        //                                       config.DigitoContaCorrente.Length == 1 ? config.DigitoContaCorrente : config.DigitoContaCorrente.Substring(0, 1), 
        //                                       config.DigitoContaCorrente.Length > 1 ? config.DigitoContaCorrente.Substring(1, 1) : "", 
        //                                       emit.emi_xNome));

        //    //gera o header do lote
        //    xfile.WriteLine(cnab.headerLote(lote,
        //                                    emit.emi_IE,
        //                                    config.Convenio,
        //                                    Convert.ToInt32(config.Agencia),
        //                                    config.DigitoAgencia,
        //                                    config.ContaCorrente,
        //                                    config.DigitoContaCorrente.Length == 1 ? config.DigitoContaCorrente : config.DigitoContaCorrente.Substring(0, 1),
        //                                    config.DigitoContaCorrente.Length > 1 ? config.DigitoContaCorrente.Substring(1, 1) : "",
        //                                    emit.emi_xNome,
        //                                    "",
        //                                    "") );

        //    int qtdeBoletos = 0;
        //    decimal Soma = 0;
        //    foreach (var b in Boletos)
        //    {
        //        qtdeBoletos++;
        //        //gera o segmento P
        //        xfile.WriteLine(cnab.SegmentoP(lote,
        //                                       qtdeBoletos,
        //                                       Convert.ToInt32(config.Agencia),
        //                                       config.DigitoAgencia,
        //                                       Convert.ToInt32(config.ContaCorrente),
        //                                       config.DigitoContaCorrente.Length == 1 ? config.DigitoContaCorrente : config.DigitoContaCorrente.Substring(0, 1),
        //                                       config.DigitoContaCorrente.Length > 1 ? config.DigitoContaCorrente.Substring(1, 1) : "",
        //                                       Convert.ToInt32(config.NossoNumero),
        //                                       Convert.ToInt32(config.NossoNumeroDigito),
        //                                       b.NumeroDocumento,
        //                                       Convert.ToDateTime(b.Vencimento).ToString("ddMMyyyy"),
        //                                       Convert.ToDecimal(b.ValorBoleto),
        //                                       Convert.ToInt32(config.Agencia),
        //                                       config.DigitoAgencia,
        //                                       Convert.ToDateTime(b.Emissao).ToString("ddMMyyyy"),
        //                                       b.IdBoleto,
        //                                       Convert.ToInt32(config.Contrato)));

        //        qtdeBoletos++;

        //        xfile.WriteLine(cnab.SegmentoQ(lote,
        //                                       qtdeBoletos,
        //                                       b.sacado_cpf,
        //                                       b.sacado_nome,
        //                                       b.sacado_endereco,
        //                                       b.sacado_bairro,
        //                                       b.sacado_cep.Substring(0, 5),
        //                                       b.sacado_cep.Substring(5, 3),
        //                                       b.sacado_cidade,
        //                                       b.sacado_uf));

        //        Soma += Convert.ToDecimal(b.ValorBoleto);
        //    }

        //    //trailer do lote
        //    xfile.WriteLine(cnab.TrailerLote(lote,
        //                                     qtdeBoletos + 1 + 1 + 1,
        //                                     qtdeBoletos,
        //                                     Soma));

        //    xfile.WriteLine(cnab.TrailerArquivo(lote, qtdeBoletos + 1 + 1 + 1 + 1));


        //    xfile.Close();
        //    MessageBox.Show("Arquivo gerado com sucesso!");
        //    System.Diagnostics.Process.Start(
        //        "explorer.exe",
        //        string.Format("/select, \"{0}\"", filepath)); 

        //}

        public List<Models.Boleto> getBoletosCollectionByLote(int lote)
        { 
            return new BoletoDAL().getByLote(lote); 
        }
    }
}
