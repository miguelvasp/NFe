using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFe_Util_2G;
using NotaEletronica.Models;
using NotaEletronica.DAL;
using NotaEletronica.Util;
using NotaEletronica.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Xml.Linq;
using System.IO;
using System.ServiceModelEvents;

namespace NotaEletronica.BLL
{
    public class BLNFe40
    {
        #region variaveis funcionais
        NFe n = new NFe();
        NFeXML x = new NFeXML();
        public NFeDAL dal = new NFeDAL();
        NFeProdutoDAL pdal = new NFeProdutoDAL();
        NFeXMLDAL xdal = new NFeXMLDAL();
        NFeParametro p = new NFeParametro();
        NFeParametroDAL prdal = new NFeParametroDAL();
        NFeEmitente emi = new NFeEmitente();
        private string versao = "4.0";
        NFe_Util_2G.Util dll = new NFe_Util_2G.Util();
        VerifyConection _dll = new VerifyConection();
        List<NFeProduto> prod;
        public string MsgErro = "";
        public string strChaveNotaFiscal = "";
        double TotalPIS = 0;
        double TotalCOFINS = 0;
        int IdNota;
        string NomeCertificado;


        string xmlAnexoEmail = "";
        string pdfAnexoEmail = "";
        string xmlCanceladoEmail = "";
        System.ServiceModelEvents.VerifyConection ssv = new VerifyConection();

        #endregion

        #region VariaveisDanfe
        private int? IdNotaFiscal;
        private int? ide_cUF;
        private string ide_natOp;
        private int? ide_indPag;
        private int? ide_mode;
        private int? ide_serie;
        private int? ide_nNF;
        private DateTime ide_dEmi;
        private DateTime ide_dSaiEnt;
        private int? ide_tpNF;
        private int? ide_cMunFG;
        private int? ide_tpImp;
        private int? ide_finNFe;
        private int? ide_tpEmis;
        private int? ide_procEmi;
        private string ide_verProc;
        private string ide_NFref;
        private string ide_CondPagDesc;
        private string TP_PESSOA;
        private string dest_CNPJ;
        private string dest_CPF = "";
        private string dest_xNome;
        private string dest_xFant;
        private string dest_xlgr;
        private string dest_nro;
        private string dest_xCpl;
        private string dest_xBairro;
        private int? dest_cMun;
        private string dest_xMun;
        private string dest_UF;
        private string dest_CEP;
        private string dest_cPais;
        private string dest_xPais;
        private string dest_fone;
        private string dest_IE;
        private string dest_IESUF;
        private string dest_email;
        private int? indIEDest;
        private int? INF_ITEM;
        private string Prod_cProd;
        private string Prod_cEAN;
        private string Prod_xProd;
        private string Prod_NCM;
        private string Prod_ExTIPI;
        private string Prod_genero;
        private string Prod_CFOP;
        private string Prod_uCOM;
        private decimal? Prod_qCom;
        private decimal? Prod_vUnCom;
        private decimal? Prod_vProd;
        private string Prod_cEANTrib;
        private string Prod_uTrib;
        private decimal? Prod_qTrib;
        private decimal? Prod_vUnTrib;
        private decimal? Prod_vFrete;
        private int? Prod_vSeguro;
        private decimal? prod_Vdesc;
        private string Prod_DI;
        private string Prod_DetEspecifico;
        private string Prod_infAdProd;
        private string icms_orig;
        private string icms_CST;
        private int? icms_modBC;
        private int? icms_pRedBC;
        private decimal? icms_vBC;
        private decimal? icms_pICMS;
        private decimal? icms_vICMS;
        private int? icms_modBCST;
        private int? icms_pmVAST;
        private int? icms_pRedBCST;
        private decimal? icms_BCST;
        private decimal? icms_vICMSST;
        private decimal? icms_pICMSST;
        private string ipi_clEnq;
        private string ipi_CNPJProd;
        private string ipi_cSelo;
        private int? ipi_qSelo;
        private string ipi_cEnq;
        private string ipi_CST;
        private decimal? ipi_vBC;
        private decimal? ipi_pIPI;
        private decimal? ipi_vIPI;
        private int? ipi_qUnid;
        private int? ipi_vUnid;
        private string pis_CST;
        private int? pis_vBC;
        private decimal? pis_pPIS;
        private int? pis_vPIS;
        private int? pis_qBCProd;
        private int? pis_vAliqProd;
        private string cofins_CST;
        private int? cofins_vBC;
        private decimal? cofins_pCOFINS;
        private int? cofins_vCOFINS;
        private int? cofins_qBCProd;
        private int? cofins_vAliqProd;
        private decimal? tot_vBC;
        private decimal? tot_vICMS;
        private decimal? tot_vBCST;
        private decimal? tot_vST;
        private decimal? tot_vProd;
        private decimal? tot_vFrete;
        private decimal? tot_vSeg;
        private decimal? tot_vDesc;
        private int? tot_vII;
        private decimal? tot_vIPI;
        private decimal? tot_vPIS;
        private decimal? tot_vCOFINS;
        private decimal? tot_vOutro;
        private decimal? tot_vNF;
        private int? CodigoNF;
        private int? tra_modFrete;
        private string tra_transportadora;
        private string tra_retTransp;
        private string tra_veicTransp;
        private string tra_reboque;
        private string tra_vol;
        private string tra_CNPJ;
        private string tra_CPF;
        private string tra_xNome;
        private string tra_IE;
        private string tra_xEnder;
        private string tra_xMun;
        private string tra_UF;
        private string veic_Placa;
        private string veic_UF;
        private string veic_RNTC;
        private decimal? vol_qVol;
        private string vol_esp;
        private string vol_Marca;
        private string vol_nVol;
        private decimal? vol_pesoL;
        private decimal? vol_pesoB;
        private string vol_lacres;
        private string nroRecibo;
        private string Protocolo;
        private string ChaveAut;
        private int? Ambiente;
        private string emi_CNPJ;
        private string emi_xNome;
        private string emi_xFant;
        private string emi_xLgr;
        private string emi_IE;
        private string emi_nro;
        private string emi_xCpl;
        private string emi_xBairro;
        private int? emi_cMun;
        private string emi_xMun;
        private string emi_UF;
        private string emi_CEP;
        private string emi_cPais;
        private string emi_xPais;
        private string emi_Fone;
        private string emi_IEST;
        private string emi_IM;
        private string emi_CNAE;
        private string emi_CRT;
        private string infAdic;
        #endregion

        //Carrega os dados ao criar o objeto
        public BLNFe40(int Id, string NomeCert, int IdEmitente)
        {
            NomeCertificado = NomeCert;
            IdNota = Id;
            n = dal.GetByID(Id);
            prod = pdal.getByIdNFe(Id);
            x = xdal.getByNFeId(Id);
            if (x == null)
            {
                x = new NFeXML();
                x.IdNFe = Id;
            }
            p = prdal.Get().ToList()[0];
            emi = new NFeEmitenteDAL().GetByID(IdEmitente);
        }


        #region Utilitarios

        public string SalvarXML(string XMLPath)
        {
            try
            {
                MsgErro = "";
                string XML = "";
                if (string.IsNullOrEmpty(n.Protocolo))
                {
                    XML = GeraXMLAssinada();
                }
                else
                {
                    XML = x.NFe_XML;
                }


                //Adiciona o numero da chave 
                string xmlPathCanc = XMLPath;
                string xmlPathCCe = XMLPath;
                xmlPathCanc += $"\\{n.ide_nNF}-nfeCanc.xml";
                XMLPath += $"\\{n.ide_nNF}-nfeProc.xml";
                xmlPathCCe += $"\\{n.ide_nNF}-nfeCCe.xml";


                if (File.Exists(XMLPath))
                {
                    File.Delete(XMLPath);
                }

                //Se a nota estiver cancelada salva o xml de cancelamento
                if (!string.IsNullOrEmpty(x.NFeCancelaXML))
                {
                    using (StreamWriter outfilec = new StreamWriter(xmlPathCanc, true))
                    {
                        outfilec.Write(x.NFeCancelaXML);
                        outfilec.Close();
                        xmlCanceladoEmail = xmlPathCanc;
                    }
                }

                if (!string.IsNullOrEmpty(x.CCeXML))
                {
                    using (StreamWriter outfilec = new StreamWriter(xmlPathCCe, true))
                    {
                        outfilec.Write(x.CCeXML);
                        outfilec.Close();
                    }
                }


                using (StreamWriter outfile = new StreamWriter(XMLPath, true))
                {
                    if (string.IsNullOrEmpty(MsgErro))
                    {
                        outfile.Write(XML);
                        outfile.Close();
                        xmlAnexoEmail = XMLPath;
                        return $"NFe {n.ide_nNF} salvo em {XMLPath}";
                    }
                    else
                    {
                        return MsgErro;
                    }

                }
            }
            catch (Exception ex)
            {
                return $"NFe {n.ide_nNF} Não pode ser salva. {MsgErro} - {ex.Message}";
            }
        }

        public bool ValidarXML(out string msgResultado)
        {
            if (!string.IsNullOrEmpty(n.Protocolo))
            {
                msgResultado = "Nota fiscal com autorização de uso";
                return true;
            }


            //valida os campos
            List<string> listaValida = Util.ValidadorNFe.Validar(n);
            if (listaValida.Count > 0)
            {
                msgResultado = $"Nota fiscal {n.ide_nNF} inválida, preencha as informações faltantes \r\n";
                foreach (var s in listaValida)
                {
                    msgResultado += s + "\r\n";
                }
                return false;
            }


            bool arquivoOk = true;
            string XML = GeraXMLAssinada();
            string msg = "";
            int qtdeErros = 0;
            int CodResult = dll.ValidaXML(XML, 68, out msgResultado, out qtdeErros, out msg);
            msgResultado = msg;
            if (CodResult != 5501)
            {
                arquivoOk = false;
                n.MsgRetorno = msgResultado;
            }
            else
            {
                n.MsgRetorno = msgResultado;
            }
            dal.Update(n);
            dal.Save();
            return arquivoOk;
        }

        public string GetVersao()
        {
            return dll.Versao();
        }

        public string TransmitirNFe()
        {
            try
            {
                string siglaWS = p.SiglaWS;
                string NFe = GeraXML();
                string msgDados = "";
                string msgRetWS = "";
                int cStat = 0;
                string msgResultado = "";
                string nroProtocolo = "";
                string dhProtocolo = "";
                string proxy = "";
                string usuario = "";
                string senha = "";
                string NFAssinada = "";
                string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);

                if (!string.IsNullOrEmpty(n.Recibo))
                {
                    string consultaRetorno = this.ConsultarProcessamento();
                    if (!string.IsNullOrEmpty(n.Protocolo))
                        return consultaRetorno;
                }


                //Envia a Nota Fiscal para a SEFAZ
                string XMLNFeProc = dll.EnviaNFSincrono(siglaWS, NFe, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, out nroProtocolo, out dhProtocolo, out NFAssinada, proxy, usuario, senha, licenca);
                     
                //Salva o XML para usar depois
                x.NFe_XML = XMLNFeProc;
                if (x.IdNFeXML == 0)
                {
                    xdal.Insert(x);
                }
                else
                {
                    xdal.Update(x);
                }
                xdal.Save();
                System.Threading.Thread.Sleep(1000);
                

                if (cStat == 100) //nota autorizada
                {
                    //atualiza o xml da nota
                    x.NFe_XML = XMLNFeProc;
                    xdal.Update(x);
                    xdal.Save();
                    n.Protocolo = nroProtocolo;
                    n.DtAutorizacao = DataAutorizacao(XMLNFeProc);
                    n.MsgRetorno = msgResultado;
                    n.NFeStatus = "NF-e Autorizada";
                    dal.Update(n);
                    dal.Save();
                }
                else
                {
                    n.MsgRetorno = msgResultado;
                    dal.Update(n);
                    dal.Save();
                }
                return msgResultado;
                 
            }
            catch (Exception ex)
            {
                return "Erro na transmissão da nota fiscal: " + ex.Message;
            }

        }

        public string DownloadNFe()
        {
            try
            {
                //if(string.IsNullOrEmpty(n.ChaveAut))
                //{
                //    return "Chave de acesso não gerada.";
                //}

                int cStat = 0;
                string msgResultado = "";
                string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);

                string xml = dll.DownloadNFWeb(NomeCertificado, "35161202095918000197550010000213811189129472", emi.emi_CNPJ, out cStat, out msgResultado, licenca);
                return xml;

            }
            catch (Exception ex)
            {
                return "Erro na consulta: " + ex.Message;
            }
        }

        public string ConsultarProcessamento()
        {
            return "";
            try
            {
                int CodReturn = 0;
                string msg = "";
                string siglaWS = p.SiglaWS;
                int tipoAmbiente = Convert.ToInt32(p.Ambiente);
                string NFeAssinada = GeraXML();
                NFeAssinada = dll.Assinar(NFeAssinada, "infNFe", NomeCertificado, out CodReturn, out msg);
                string nroRecibo = n.Recibo;
                string msgDados = "";
                int cStat = 0;
                string msgResultado = "";
                string nroProtocolo = "";
                string cMsg = "";
                string xMsg = "";
                string msgRetWS = "";
                string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);
                string dhProtocolo = "";

                if (!_dll.VerifyWSState(siglaWS, siglaWS, (int)p.Ambiente, NomeCertificado, "4.00", "", "getService", "", licenca, out msgDados))
                {
                    return msgDados;
                }

                string XMLNFeProc = dll.BuscaNFe2G(siglaWS, tipoAmbiente, ref NFeAssinada, nroRecibo, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, out nroProtocolo, out dhProtocolo, out cMsg, out xMsg, "", "", "", licenca);

                if (cStat == 100) //nota autorizada
                {
                    //atualiza o xml da nota
                    x.NFe_XML = XMLNFeProc;
                    xdal.Update(x);
                    xdal.Save();
                    n.Protocolo = nroProtocolo;
                    n.DtAutorizacao = DataAutorizacao(XMLNFeProc);
                    n.MsgRetorno = msgResultado;
                    n.NFeStatus = "NF-e Autorizada";
                    dal.Update(n);
                    dal.Save();
                }
                else
                {
                    n.MsgRetorno = msgResultado;
                    dal.Update(n);
                    dal.Save();
                }
                return msgResultado;
            }
            catch (Exception ex)
            {
                return "Erro Consulta do processamento: " + ex.Message;
            }
        }

        public string CancelaNotaFiscal(string Justificativa)
        {
            try
            {
                string siglaWS = p.SiglaWS;
                int tipoAmbiente = Convert.ToInt32(p.Ambiente);
                string msgDados = "";
                string msgRetWS = "";
                int cStat = 0;
                string msgResultado = "";
                string chaveNFe = n.ChaveAut;
                string nProtocolo = n.Protocolo;
                string dhEvento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string nProtocoloCanc = "";
                string dProtocoloCanc = "";
                string proxy = "";
                string usuario = "";
                string senha = "";
                string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);

                if (!_dll.VerifyWSState(siglaWS, siglaWS, (int)p.Ambiente, NomeCertificado, "4.00", "", "getService", "", licenca, out msgDados))
                {
                    return msgDados;
                }

                string CancelaNFe = dll.CancelaNFEvento(siglaWS, tipoAmbiente, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, chaveNFe, nProtocolo, Justificativa, dhEvento, out nProtocoloCanc, out dProtocoloCanc, proxy, usuario, senha, licenca);

                if (cStat == 135 || cStat == 155)
                {
                    n.ProtocoloCancelamento = nProtocoloCanc;
                    n.DtCancelamento = DateTime.Now;
                    n.Justificativa = Justificativa;
                    n.MsgRetorno = msgResultado;
                    n.NFeStatus = "NFe Cancelada por Evento";
                    dal.Update(n);
                    dal.Save();

                    x.NFeCancelaXML = CancelaNFe;
                    xdal.Update(x);
                    xdal.Save();


                    return $"NF-e { n.ide_nNF } cancelada com sucesso!";
                }
                else
                {
                    return $"Erro: Cancelamento de nota fiscal { n.ide_nNF }\n\r { msgResultado }";
                }
            }
            catch (Exception ex)
            {
                return $"Erro ao cancelar a nota fiscal: { ex.Message } ";
            }

        }

        public string CartaCorrecao(string texto)
        {
            try
            {
                string siglaWS = p.SiglaWS;
                int tipoAmbiente = Convert.ToInt32(p.Ambiente);
                string msgDados = "";
                string msgRetWS = "";
                int cStat = 0;
                string msgResultado = "";
                string chaveNFe = n.ChaveAut;
                string nProtocolo = "";
                string dhEvento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string nProtocoloCanc = "";
                string dProtocoloCanc = "";
                string proxy = "";
                string usuario = "";
                string senha = "";
                string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);

                if (!_dll.VerifyWSState(siglaWS, siglaWS, (int)p.Ambiente, NomeCertificado, "4.00", "", "getService", "", licenca, out msgDados))
                {
                    return msgDados;
                }

                string cce = dll.EnviaCCe2G(siglaWS,
                                            tipoAmbiente,
                                            NomeCertificado,
                                            "4.00",
                                            out msgDados,
                                            out msgRetWS,
                                            out cStat,
                                            out msgResultado,
                                            chaveNFe,
                                            texto,
                                            0,
                                            1,
                                            dhEvento,
                                            out nProtocolo,
                                            out dProtocoloCanc,
                                            proxy,
                                            usuario,
                                            senha,
                                            licenca
                                            );

                if (cStat == 135)
                {
                    n.ProtocoloCancelamento = nProtocoloCanc;
                    n.DtCancelamento = DateTime.Now;
                    n.CCeTexto = texto;
                    n.MsgRetorno = msgResultado;
                    dal.Update(n);
                    dal.Save();

                    x.CCeXML = cce;
                    xdal.Update(x);
                    xdal.Save();


                    return $"NF-e { n.ide_nNF } Carta de correção enviada com sucesso!";
                }
                else
                {
                    return $"Erro: Carta de correção de nota fiscal { n.ide_nNF }\n\r { msgResultado }";
                }
            }
            catch (Exception ex)
            {
                return $"Erro ao cancelar a nota fiscal: { ex.Message } ";
            }

        }

        public string GetXMLAutorizado()
        {
            string XML = x.NFe_XML;
            return XML;
        }

        public string InutilizarNFe(NFeInutiliza obj, out int statusChamada)
        {
            string siglaWS = p.SiglaWS;
            int tipoAmbiente = Convert.ToInt32(p.Ambiente);
            string msgDados = "";
            string msgRetWS = "";
            int cStat = 0;
            string msgResultado = "";
            string dhEvento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string nProtocolo = "";
            string dProtocolo = "";
            string proxy = "";
            string usuario = "";
            string senha = "";
            string licenca = ssv.getTokenSecurity(emi.emi_CNPJ);
            string cUf = emi.emi_cMun.Substring(0, 2);

            string xml = dll.InutilizaNroNF2G(
                    siglaWS,
                    tipoAmbiente,
                    NomeCertificado,
                    "4.00",
                    out msgDados,
                    out msgRetWS,
                    out cStat,
                    out msgResultado,
                    cUf,
                    DateTime.Now.ToString("yy"),
                    emi.emi_CNPJ,
                    "55",
                    obj.Serie,
                    obj.Numero,
                    obj.Numero,
                    obj.Justificativa,
                    out nProtocolo,
                    out dProtocolo,
                    "",
                    "",
                    "",
                    licenca
                );

            //dll.InutilizaNroNF2G(siglaWS, tipoAmbiente, NomeCertificado, "4.00", out msgDados, out msgRetWS, out cStat, out msgResultado, cUf, DateTime.Now.ToString("yy"), )
            statusChamada = cStat;
            if (cStat == 102)
            {
                obj.Protocolo = nProtocolo;
                obj.Data = DateTime.Now;
                obj.XMLInut = xml;
                NFeInutilizaDAL indal = new NFeInutilizaDAL();
                indal.Insert(obj);
                indal.Save();
            }

            return msgResultado;

        }



        public string GeraDanfe()
        {
            //Busca o xml
            string XML = x.NFe_XML;
            if (!String.IsNullOrEmpty(XML))
            {
                //Monta as pastas
                string Folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string ChaveAut = n.ide_nNF.ToString();
                string FileName = Folder + "\\Temp\\NFe" + ChaveAut + ".pdf";

                if (!Directory.Exists(Folder + "\\Temp"))
                {
                    Directory.CreateDirectory(Folder + "\\Temp");
                }

                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                string msg = "";
                //Gera o pdf
                CreateDanfe(XML, FileName, out msg);
                //MessageBox.Show(msg);
                System.Threading.Thread.Sleep(1000);
                pdfAnexoEmail = FileName;
                return FileName;

            }
            else
            {
                return "";
            }

        }

        public void ImprimirDanfe()
        {
            string XML = x.NFe_XML;
            string msg = "";
            PrintDanfe(XML, out msg);
            System.Threading.Thread.Sleep(1000);
        }

        private void CreateDanfe(string XML, string FilePath, out string msg)
        {
            string Message = "";
            try
            {

                NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
                string DirectoryName = System.IO.Path.GetDirectoryName(FilePath);
                string FileName = System.IO.Path.GetFileName(FilePath);

                if (!FileName.ToLower().Contains(".pdf"))
                {
                    FileName += ".pdf";
                }
                objUtil.geraPdfDANFE(XML, "", "S", "N", "N", "", "L", "[ARQUIVO=" + FileName + "][PASTA=" + DirectoryName + "]", out Message);

                msg = Message;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

        }

        private void PrintDanfe(string XML, out string msg)
        {
            string Message = "";
            try
            {

                NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
                objUtil.geraPdfDANFE(XML, "", "S", "N", "N", "", "L", "[IMPRIMIR=1][SumatraPDF]", out Message);

                msg = Message;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

        }
        #endregion


        #region metodos XML


        private string GeraChaveNFe()
        {
            string cs_codigoseguranca = "MGASOLUCOES";
            string msgResultado = "";
            string cNF = "";
            string cDV = "";
            string Chave = "";
            string CNPJEmitente = emi.emi_CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            int resultado = dll.CriaChaveNFe2G(emi.emi_cMun.ToString().Substring(0, 2), Convert.ToDateTime(n.ide_dEmi).Year.ToString().Substring(2, 2), Convert.ToDateTime(n.ide_dEmi).Month.ToString(), CNPJEmitente, n.ide_mode.ToString(), n.ide_serie.ToString(), n.ide_nNF.ToString(), n.ide_tpEmis.ToString(), cs_codigoseguranca, out msgResultado, out cNF, out cDV, out Chave);

            //codigo 5601 chave ok
            if (resultado == 5601)
            {
                n.ChaveAut = Chave;
                n.cDV = Convert.ToInt32(cDV);
                n.ide_cNF = Convert.ToInt32(cNF);
                dal.Update(n);
                dal.Save();
            }
            else
            {
                MsgErro += $"Erro ChaveNFe: { msgResultado } \n\r";
            }
            return Chave;

        }

        private string Identificador()
        {
            TotalPIS = 0;
            TotalCOFINS = 0;
            try
            {
                string InfXML = "";
                //CFOP cfop = new CFOPDAL().GetByID((int)NF.IdCFOP);
                ide_NFref = n.ide_NFref;
                string NFReferenciadas = string.IsNullOrEmpty(ide_NFref) ? "" : dll.NFeRef(ide_NFref);
                string idDest = emi.emi_UF == n.dest_UF ? "1" : "2";
                if (n.dest_UF.ToUpper() == "EX") idDest = "3";
                ide_cUF = n.ide_cUF;
                ide_natOp = Util.Util.MudaLetra(n.ide_natOp);
                ide_indPag = (int)n.ide_indPag;
                ide_mode = (int)n.ide_mode;
                ide_serie = Convert.ToInt32(n.ide_serie);
                ide_nNF = Convert.ToInt32(n.ide_nNF);
                ide_dEmi = Convert.ToDateTime(n.ide_dEmi);
                ide_tpNF = (int)n.ide_tpNF;
                ide_cMunFG = n.ide_cMunFG;
                ide_tpImp = 1;
                ide_finNFe = (int)n.ide_finNFe;
                ide_tpEmis = (int)n.ide_tpEmis;
                //InfXML = dll.identificador400(Convert.ToInt32(ide_cUF),
                //                                 (int)n.ide_cNF,
                //                                 ide_natOp,
                //                                 Convert.ToInt32(ide_mode),
                //                                 Convert.ToInt32(ide_serie),
                //                                 Convert.ToInt32(ide_nNF),
                //                                 ide_dEmi.ToString("yyyy-MM-ddT00:00:00-03:00"),
                //                                 "",
                //                                 Convert.ToInt32(ide_tpNF),
                //                                 Convert.ToInt32(idDest),
                //                                 ide_cMunFG.ToString(),
                //                                 NFReferenciadas,
                //                                 Convert.ToInt32(ide_tpImp),
                //                                 Convert.ToInt32(ide_tpEmis),
                //                                 (int)n.cDV,
                //                                 Convert.ToInt32(p.Ambiente),
                //                                 Convert.ToInt32(ide_finNFe),
                //                                 (int)n.ide_indFinal,
                //                                 (int)n.ide_indPres,
                //                                 0,
                //                                 "000",
                //                                 "",
                //                                 "");

                InfXML = dll.identificador202006(Convert.ToInt32(ide_cUF),
                                                               (int)n.ide_cNF,
                                                               ide_natOp,
                                                               Convert.ToInt32(ide_mode),
                                                               Convert.ToInt32(ide_serie),
                                                               Convert.ToInt32(ide_nNF),
                                                               ide_dEmi.ToString("yyyy-MM-ddT00:00:00-03:00"),
                                                               "",
                                                               Convert.ToInt32(ide_tpNF),
                                                               Convert.ToInt32(idDest),
                                                               ide_cMunFG.ToString(),
                                                               NFReferenciadas,
                                                               Convert.ToInt32(ide_tpImp),
                                                               Convert.ToInt32(ide_tpEmis),
                                                               (int)n.cDV,
                                                               Convert.ToInt32(p.Ambiente),
                                                               Convert.ToInt32(ide_finNFe),
                                                               (int)n.ide_indFinal,
                                                               (int)n.ide_indPres,
                                                               0,
                                                               "000",
                                                               "",
                                                               "",
                                                               0);



                return InfXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Identificador { ex.Message } \n";
                return "";
            }
        }

        private string Emitente()
        {
            string EmitXML = "";
            emi_CNPJ = emi.emi_CNPJ;
            emi_xNome = Util.Util.MudaLetra(emi.emi_xNome);
            emi_xFant = "";
            emi_xLgr = Util.Util.MudaLetra(emi.emi_xLgr);
            emi_IE = Util.Util.MudaLetra(emi.emi_IE);
            emi_nro = emi.emi_nro;
            emi_xCpl = Util.Util.MudaLetra(emi.emi_xCpl);
            emi_xBairro = Util.Util.MudaLetra(emi.emi_xBairro);
            emi_cMun = Convert.ToInt32(emi.emi_cMun);
            emi_xMun = Util.Util.MudaLetra(emi.emi_xMun);
            emi_UF = emi.emi_UF;
            emi_CEP = emi.emi_CEP.Replace("-", "");
            emi_cPais = "1058";
            emi_xPais = "BRASIL";
            emi_Fone = Util.Util.MudaLetra(emi.emi_Fone);
            emi_IEST = "";
            emi_IM = "";
            emi_CNAE = "";
            emi_CRT = emi.emi_CRT.ToString();
            try
            {

                EmitXML = dll.emitente2G(emi_CNPJ,
                                             "",
                                             emi_xNome,
                                             emi_xFant,
                                             emi_xLgr,
                                             emi_nro,
                                             emi_xCpl,
                                             emi_xBairro,
                                             emi_cMun.ToString(),
                                             emi_xMun,
                                             emi_UF,
                                             emi_CEP,
                                             emi_cPais,
                                             emi_xPais,
                                             emi_Fone,
                                             emi_IE,
                                             "",
                                             "",
                                             "",
                                             emi_CRT);
                return EmitXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Emitente { ex.Message } \n";
                return "";
            }
        }

        private string Destinatario()
        {
            TP_PESSOA = n.dest_CNPJ.Length == 14 ? "J" : "F";
            if (TP_PESSOA == "F") { dest_CPF = n.dest_CPF; } else { dest_CNPJ = n.dest_CNPJ; }
            if (Convert.ToInt32(p.Ambiente) == 1)
            {
                dest_xNome = Util.Util.MudaLetra(n.dest_xNome);
            }
            else
            {
                dest_xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
            }


            dest_xFant = Util.Util.MudaLetra(n.dest_xFant);
            dest_xlgr = Util.Util.MudaLetra(n.dest_xlgr);
            dest_nro = n.dest_nro;
            dest_xCpl = Util.Util.MudaLetra(n.dest_xCpl);
            dest_xBairro = Util.Util.MudaLetra(n.dest_xBairro);
            dest_cMun = Convert.ToInt32(n.dest_cMun);
            dest_xMun = Util.Util.MudaLetra(n.dest_xMun);
            dest_UF = n.dest_UF;
            dest_CEP = n.dest_CEP.Replace("-", "");
            dest_cPais = n.dest_cPais;
            dest_xPais = Util.Util.MudaLetra(n.dest_xPais);
            dest_fone = n.dest_fone;
            dest_IE = Util.Util.MudaLetra(n.dest_IE);
            dest_IESUF = "";
            dest_email = n.dest_email;
            indIEDest = Convert.ToInt32(n.dest_indIEDest);

            try
            {
                string DestXML = "";
                DestXML = dll.destinatario310(dest_CNPJ,
                                                  dest_CPF,
                                                  "",
                                                  dest_xNome,
                                                  dest_xlgr,
                                                  dest_nro,
                                                  dest_xCpl,
                                                  dest_xBairro,
                                                  dest_cMun.ToString(),
                                                  dest_xMun,
                                                  dest_UF,
                                                  dest_CEP,
                                                  dest_cPais,
                                                  dest_xPais,
                                                  dest_fone,
                                                  indIEDest.ToString(),
                                                  dest_IE,
                                                  dest_IESUF,
                                                  "",
                                                  dest_email);
                return DestXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Destinatário { ex.Message } \n";
                return "";
            }
        }

        private string Detalhe()
        {
            try
            {
                string DetalheXML = "";

                int Contador = 0;
                foreach (var i in prod)
                {
                    string cProd = Util.Util.MudaLetra(i.cProd);
                    string cEAN = string.IsNullOrEmpty(i.cEAN) ? "SEM GTIN" : i.cEAN;
                    string xProd = Util.Util.MudaLetra(i.xProd);
                    string NCM = i.NCM;
                    string NVE_Opc = "";
                    string EXTIPI = "";
                    string uCom = i.uCom;
                    double qCom = (double)i.qCom;
                    double vUnCom = (double)i.vUnCom;
                    double vProd = Convert.ToDouble(i.qCom * i.vUnCom);
                    string cEANTrib = string.IsNullOrEmpty(i.cEANTrib) ? "SEM GTIN" : i.cEANTrib;
                    string uTrib = uCom;
                    double qTrib = qCom;
                    double vUnTrib = vUnCom;
                    double vFrete = (double)i.vFrete;
                    double vSeg = (double)i.vSeg;
                    double vDesc = (double)i.vDesc;
                    double vOutro = 0;
                    int indTot = 1;
                    string DI = "";
                    string detExport_Opc = "";
                    string DetEspecifico = "";
                    string xPed = "";
                    string nItemPed = "";
                    string nFCI_Opc = "";
                    int CFOP = Convert.ToInt32(i.CFOP);
                    string Cest = i.CEST;
                    string cBenf = i.cBenf;
                    //verifica se o CEST foi informado e gera o grupo com CEST

                    if (!string.IsNullOrEmpty(i.cProdANP))
                    {
                        DetEspecifico = dll.comb400(i.cProdANP, i.descANP, 0, 0, 0, 0, "", 0, i.UFCons, 0, 0, 0, "");
                    }

                    string ProdutoXML = dll.produto400(
                                               cProd,
                                               cEAN,
                                               xProd,
                                               NCM,
                                               NVE_Opc,
                                               Cest, "", "", 
                                               cBenf,
                                               EXTIPI,
                                               CFOP,
                                               uCom,
                                               qCom.ToString(),
                                               vUnCom.ToString(),
                                               vProd,
                                               cEANTrib,
                                               uTrib,
                                               qTrib.ToString(),
                                               vUnTrib.ToString(),
                                               vFrete,
                                               vSeg,
                                               vDesc,
                                               vOutro,
                                               indTot,
                                               DI,
                                               detExport_Opc,
                                               DetEspecifico,
                                               xPed,
                                               nItemPed,
                                               nFCI_Opc, ""
                                               );


                    string ICMS = dll.icms400(i.ICMS_origem,
                                            i.ICMS_CST,
                                            Convert.ToInt32(i.ICMS_modBC),
                                            Convert.ToDouble(i.ICMS_pRedBCST),
                                            Convert.ToDouble(i.ICMS_vBC),
                                            Convert.ToDouble(i.ICMS_pICMS),
                                            Convert.ToDouble(i.ICMS_vICMS),
                                            Convert.ToInt32(i.ICMS_modBCST),
                                            Convert.ToDouble(i.ICMS_pMVAST),
                                            Convert.ToDouble(i.ICMS_pRedBCST),
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0,
                                            0.00,
                                            "",
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00,
                                            0.00);

                    string PIS = dll.PIS(i.PIS_CST,
                                      Convert.ToDouble(i.PIS_vBC),
                                      Convert.ToDouble(i.PIS_pPis),
                                      Convert.ToDouble(i.PIS_vPis),
                                      Convert.ToDouble(i.pis_qBCProd),
                                      Convert.ToDouble(i.pis_vAliqProd));

                    string cofins = dll.COFINS(i.COFINS_CST,
                                               Convert.ToDouble(i.COFINS_vBC),
                                               Convert.ToDouble(i.COFINS_pCofins),
                                               Convert.ToDouble(i.COFINS_vCofins),
                                               Convert.ToDouble(i.cofins_qBCProd),
                                               Convert.ToDouble(i.cofins_vAliqProd));

                    string IPI = dll.IPI400(
                                         i.ipi_CNPJProd,
                                         i.ipi_cSelo,
                                         Convert.ToDouble(i.ipi_qSelo),
                                         i.IPI_Enq,
                                         i.IPI_CST,
                                         Convert.ToDouble(i.IPI_vBC),
                                         Convert.ToDouble(i.IPI_pIpi),
                                         Convert.ToDouble(i.IPI_vIPI),
                                         Convert.ToDouble(i.ipi_qUnid),
                                         Convert.ToDouble(i.ipi_vUnid));


                    double ValorTotalImpostos = Convert.ToDouble(i.ICMS_vICMS + i.PIS_vPis + i.COFINS_vCofins + i.IPI_vIPI);

                    string ImpostosXML = dll.imposto310(ValorTotalImpostos, ICMS, IPI, "", PIS, "", cofins, "", "");

                    Contador++;
                    DetalheXML += dll.detalhe310(Contador, ProdutoXML, ImpostosXML, "", 0, 0);
                    //detalheNT2021004(string obsContItem_Opc, string obsFiscoItem_Opc)
                }

                return DetalheXML;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Detalhe { ex.Message } \n";
                return "";
            }

        }

        private string Totais()
        {
            try
            {
                tot_vBC = (decimal)n.tot_vBC;
                tot_vICMS = (decimal)n.tot_vICMS;
                tot_vBCST = (decimal)n.tot_vBCST;
                tot_vST = (decimal)n.tot_vST;
                tot_vProd = (decimal)n.tot_vProd;
                tot_vFrete = (decimal)n.tot_vFrete;
                tot_vSeg = (decimal)n.tot_vSeg;
                tot_vDesc = (decimal)n.tot_vDesc;
                tot_vII = 0;
                tot_vIPI = (decimal)n.tot_vIPI;
                //tot_vPIS = (decimal)TotalPIS;
                //tot_vCOFINS = (decimal)TotalCOFINS;
                tot_vOutro = 0;
                tot_vNF = (decimal)n.tot_vNF;
                double tot_trib = (double)tot_vICMS + (double)tot_vIPI + TotalPIS + TotalCOFINS;
                string totalICMS = dll.totalICMS400((double)tot_vBC,
                                              (double)tot_vICMS,
                                              (double)tot_vBCST,
                                              (double)tot_vST,
                                              (double)tot_vProd,
                                              (double)tot_vFrete,
                                              (double)tot_vSeg,
                                              (double)tot_vDesc,
                                              (double)tot_vII,
                                              (double)tot_vIPI,
                                              TotalPIS,
                                              TotalCOFINS,
                                              (double)tot_vOutro,
                                              (double)tot_vNF,
                                              tot_trib,
                                              0.00,
                                              0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
                return "<total>" + totalICMS + "</total>";
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Totais { ex.Message } \n";
                return "";
            }
        }

        private string getVencimentos()
        {
            return "";
            //try
            //{
            //    int contador = 0;
            //    string xmlVenc = "";
            //    foreach(var v in venc)
            //    {
            //        xmlVenc += dll.dup("", Convert.ToDateTime(v.Vencimento), Convert.ToDouble(v.Valor));
            //    }
            //    string cob = dll.cobr(n.ide_nNF.ToString(), 0, 0, 0, xmlVenc);
            //    return cob;

            //}
            //catch (Exception ex)
            //{
            //    MsgErro += $"Erro Observação { ex.Message } \n";
            //    return "";
            //}
        }

        private string Transportadora()
        {
            try
            {
                string modFrete = n.tra_modFrete;
                tra_retTransp = "";
                //tra_veicTransp = transp.tra_veicTransp;
                //tra_reboque = transp.tra_reboque;
                tra_CNPJ = n.tra_CNPJ;
                tra_CPF = n.tra_CPF;
                tra_xNome = n.tra_xNome;
                tra_IE = n.tra_IE;
                tra_xEnder = n.tra_xEnder;
                tra_xMun = n.tra_xMun;
                tra_UF = n.tra_UF;
                veic_Placa = n.veic_Placa;
                veic_UF = n.veic_UF;
                veic_RNTC = n.veic_RNTC;
                vol_qVol = n.vol_qVol;
                vol_esp = n.vol_esp;
                vol_Marca = n.vol_Marca;
                vol_nVol = n.vol_nVol;
                vol_pesoL = n.vol_pesoL;
                vol_pesoB = n.vol_pesoB;
                vol_lacres = n.vol_lacres;



                string tra_transportadora = dll.transporta(Util.Util.MudaLetra(tra_CNPJ),
                                                                  Util.Util.MudaLetra(tra_CPF),
                                                                  Util.Util.MudaLetra(tra_xNome),
                                                                  Util.Util.MudaLetra(tra_IE),
                                                                  Util.Util.MudaLetra(tra_xEnder),
                                                                  Util.Util.MudaLetra(tra_xMun),
                                                                  tra_UF);


                string tra_vol = dll.vol((double)vol_qVol,
                                                Util.Util.MudaLetra(vol_esp),
                                                Util.Util.MudaLetra(vol_Marca),
                                                Util.Util.MudaLetra(vol_nVol),
                                                (double)vol_pesoL,
                                                (double)vol_pesoB,
                                                Util.Util.MudaLetra(vol_lacres));

                string veiculo_transp = "";
                if (!string.IsNullOrEmpty(veic_Placa))
                    veiculo_transp = dll.veicTransp(veic_Placa, veic_UF, veic_RNTC);

                //se os volumes estao igual a zero nem colocar
                if ((double)vol_qVol == 0.00)
                {
                    tra_vol = "";
                }


                string Transportador = dll.transportador2G(modFrete,
                                                                tra_transportadora,
                                                                tra_retTransp,
                                                                veiculo_transp,
                                                                tra_reboque,
                                                                "",
                                                                "",
                                                                tra_vol);

                return Transportador;
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Transportador { ex.Message } \n";
                return "";
            }

        }

        private string pag()
        {
            //string detPag = dll.detPag("", string.IsNullOrEmpty(n.pag_tPag) ? "99" : n.pag_tPag, Convert.ToDouble(n.pag_vPag == null ? 0 : n.pag_vPag), "", "", "", "");
            string detPag = dll.detPag("", string.IsNullOrEmpty(n.pag_tPag) ? "99" : n.pag_tPag, 0, "", "", "", "");

            return dll.pagamento400(detPag, 0);
        }

        private string responsavelTecnico()
        {
            string respXml = "";
            respXml = dll.infRespTec(emi.emi_CNPJ,
                                     emi.emi_xContato,
                                     emi.emi_xContatoEmail,
                                     emi.emi_Fone,
                                     emi.emi_idCSRT,
                                     emi.emi_CSRT,
                                     emi.emi_chaveNFe);

            return respXml;
        }

        private string exporta()
        {
            string xml = "";
            if (!string.IsNullOrEmpty(n.UFSaidaPais) && !string.IsNullOrEmpty(n.xLocEmbarq))
            {
                xml = dll.exporta310(n.UFSaidaPais, n.xLocEmbarq, "");
            }

            return xml;
        }

        private string InfAdicional(int Id)
        {
            try
            {
                return dll.infAdic("", n.infAdic.Replace("\n", " "), "", "", "");
            }
            catch (Exception ex)
            {
                MsgErro += $"Erro Observação { ex.Message } \n";
                return "";
            }
        }

        private string GeraXML()
        {
            try
            {
                string NFeXML = "";
                if (String.IsNullOrEmpty(n.ChaveAut))
                {
                    GeraChaveNFe();
                }

                string sIdentificador = Identificador();
                string sEmitente = Emitente();
                string sDestinatario = Destinatario();
                string sLocalRetirada = "";// = LocalRetirada(); //Implementar
                string sLocalEntrega = "";//= LocalEntrega(); //Implementar
                string sDetalhe = Detalhe();
                string sTotais = Totais();
                string sTransportadora = Transportadora();
                string sInfAdicional = InfAdicional(IdNota);
                string vencimentos = getVencimentos();
                string sPagamento = pag();
                string exportar = exporta();
                string responsavel_tecnico = responsavelTecnico();
                //NFeXML = dll.NFe310("4.00", n.ChaveAut, sIdentificador, sEmitente, "", sDestinatario, sLocalRetirada, sLocalEntrega, sDetalhe, sTotais, sTransportadora, 
                //vencimentos, sPagamento, sInfAdicional, exportar, "", "", "");







                //chamada para a Nota técnica 2018/05
                NFeXML = dll.NFe201805("4.00",
                                       n.ChaveAut,
                                       sIdentificador,
                                       sEmitente,
                                       "",
                                       sDestinatario,
                                       sLocalRetirada,
                                       sLocalEntrega,
                                       sDetalhe,
                                       sTotais,
                                       sTransportadora,
                                       vencimentos,
                                       sPagamento,
                                       sInfAdicional,
                                       exportar,
                                       "",
                                       "",
                                       "",
                                       responsavel_tecnico);

                int CodReturn = 0;
                string msg = "";
                string resultado = "";
                NFeXML = dll.EliminaIdentacaoXML(NFeXML, out CodReturn, out msg);

                if (CodReturn != 7320)
                {
                    MsgErro += $"Erro Elimar Identação: {msg}";
                }

                if (!string.IsNullOrEmpty(MsgErro))
                {
                    frmErro frme = new frmErro("Aconteceram os seguintes erros ao processar a sua solicitação\n\r\n\r" + MsgErro);
                    frme.ShowDialog();
                    return "";
                }

                return NFeXML;
            }
            catch (Exception ex)
            {
                frmErro frme = new frmErro("Aconteceram os seguintes erros ao processar a sua solicitação\n\r\n\r" + ex.ToString());
                frme.ShowDialog();
                return "";
            }

        }

        private string GeraXMLAssinada()
        {
            try
            {
                string NFeXML = GeraXML();

                //Assina o XML
                int CodReturn = 0;
                string msg = "";
                NFeXML = dll.Assinar(NFeXML, "infNFe", NomeCertificado, out CodReturn, out msg);

                if (CodReturn != 5300)
                {
                    MsgErro += $"Erro Assinatura: {msg}";
                }

                //Remove a identação do arquivo XML
                CodReturn = 0;
                msg = "";
                NFeXML = dll.EliminaIdentacaoXML(NFeXML, out CodReturn, out msg);

                if (CodReturn != 7320)
                {
                    MsgErro += $"Erro Elimar Identação: {msg}";
                }

                if (!string.IsNullOrEmpty(MsgErro))
                {
                    frmErro frme = new frmErro("Aconteceram os seguintes erros ao processar a sua solicitação\n\r\n\r" + MsgErro);
                    frme.ShowDialog();
                    return "";
                }

                return NFeXML;
            }
            catch (Exception ex)
            {
                frmErro frme = new frmErro("Aconteceram os seguintes erros ao processar a sua solicitação\n\r\n\r" + ex.ToString());
                frme.ShowDialog();
                return "";
            }
        }

        #endregion

        #region Auxiliares
        private DateTime DataAutorizacao(string XML)
        {
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
            TextReader tr = new StringReader(XML);
            XDocument arquivo = XDocument.Load(tr);
            var nfeProc = arquivo.Element(ns + "nfeProc");
            var protNFe = nfeProc.Element(ns + "protNFe");
            var infProt = protNFe.Element(ns + "infProt");
            string dhRecbto = infProt.Element(ns + "dhRecbto").Value;
            string ano = dhRecbto.Substring(0, 4);
            string mes = dhRecbto.Substring(5, 2);
            string dia = dhRecbto.Substring(8, 2);
            string hora = dhRecbto.Substring(11, 8);
            dhRecbto = dia + "/" + mes + "/" + ano + " " + hora;
            DateTime dhReceb = Convert.ToDateTime(dhRecbto);
            return dhReceb;
        }

        public Boleto NovoBoleto(int Id, int IdBanco)
        {
            BoletoDocumentoDAL dDal = new BoletoDocumentoDAL();

            if (dDal.getCount("NFe", Id) > 0)
            {
                return null;
            }

            NFeVencimentosDAL vencDal = new NFeVencimentosDAL();
            var vencimentos = vencDal.getByIdNFe(Id);
            foreach (var venc in vencimentos.Where(x => x.Valor > 0).ToList())
            {
                BoletoDAL bdal = new BoletoDAL();
                var config = new BoletoConfiguracoesDAL().getByBanco(IdBanco);



                if (config == null)
                {
                    throw new Exception("Configurações inexistentes para o banco informado!");
                    return null;
                }
                Boleto b = new Boleto();
                b.Vencimento = Convert.ToDateTime(venc.Vencimento).AddDays(Convert.ToDouble(config.nroDias));
                b.Instrucao = config.CodigoInstrucao;
                b.nroDias = config.nroDias;
                b.cedente_cpf = emi.emi_CNPJ;
                b.cedente_nome = emi.emi_xNome;
                b.cedente_agencia = config.Agencia;
                b.cedente_digitoagencia = config.DigitoAgencia;
                b.cedente_conta = config.ContaCorrente;
                b.cedente_digitoconta = config.DigitoContaCorrente;
                b.cedente_codigo = config.Codigo;
                b.numeroBanco = Convert.ToInt32(config.numeroBanco);
                b.ValorBoleto = Convert.ToDecimal(venc.Valor);
                b.Carteira = config.Cateira;


                //b.NossoNumero = config.NossoNumero;
                b.NumeroDocumento = n.ide_nNF.ToString();
                b.sacado_cpf = n.dest_CNPJ;
                b.sacado_nome = n.dest_xNome;
                b.sacado_endereco = n.dest_xlgr + " " + n.dest_nro;
                b.sacado_bairro = n.dest_xBairro;
                b.sacado_cidade = n.dest_xMun;
                b.sacado_cep = n.dest_CEP;
                b.sacado_uf = n.dest_UF;
                b.DiasAposVencimento = config.nroDias;
                b.IdDocumentoEletronico = Id;
                b.TipoDocumento = "NFe";
                b.Situacao = "Em Digitação";
                b.Emissao = DateTime.Now;
                b.Convenio = config.Convenio;
                b.EnviouEmail = "N";
                b.Impressao = "N";

                bdal.Insert(b);
                bdal.Save();

                UtilBradescoCobranca400 util = new UtilBradescoCobranca400();
                b.NossoNumero = util.NossoNumero(b.Carteira, b.IdBoleto);
                bdal.Update(b);
                bdal.Save();


                BoletoDocumento bd = new BoletoDocumento() { IdBoleto = b.IdBoleto, IdDocumento = Id, TipoDocumento = "NFe" };
                dDal.Insert(bd);
                dDal.Save();

                venc.IdBoleto = b.IdBoleto;
                vencDal.Update(venc);
                vencDal.Save();
            }

            return new Boleto();
        }

        public void EnviarNFeEmail()
        {
            //Monta o email 
            var param = new NFeParametroDAL().Get().ToList()[0];
            TEmail em = new TEmail();
            em.de = param.eEmail;

            string listaEmails = "";
            //traz os emails
            var emails = new NFeEmailDAL().getByNFeId(n.IdNFe);

            if (emails.Count == 1)
            {
                listaEmails = emails[0].email.Trim().TrimEnd(',');
            }

            if (emails.Count > 1)
            {
                foreach (var email in emails)
                {
                    listaEmails += email.email.Trim().TrimEnd(',') + ",";
                }
            }

            em.para = listaEmails.Trim().TrimEnd(',').Trim();
            em.Anexo = xmlAnexoEmail;
            em.Anexo2 = pdfAnexoEmail;
            em.Anexo3 = xmlCanceladoEmail;
            em.Assunto = "Nota Fiscal Eletrônica";
            em.Mensagem += "\r\nSegue em anexo nota fiscal " + n.ide_nNF.ToString();
            em.NotaFiscal = n.ide_nNF;
            em.Status = "Na fila";
            em.Data = DateTime.Now;
            TEmailDAL emdal = new TEmailDAL();
            emdal.Insert(em);
            emdal.Save();
        }

        #endregion

        #region Dispose
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
