using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.ComponentModel;
using System.Configuration; 
using System.Globalization;
using System.IO; 
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions; 
using System.Xml.Linq;

namespace System.ServiceModelEvents
{
    public class VerifyConection
    {
        //DateTime datalimite = new DateTime(2020, 12, 19);
        public bool VerifyWSState(string SiglaWS, string SiglaUF, int TipoAmbiente, string NomeCertificado, string Versao, string proxy, string Chamada, string senha, string Licenca, out string msgDados)
        {
            msgDados = "ok";
            return true;
        }

        public string getTokenSecurity(string CNPJ)
        {
            //CNPJ NBF
            DateTime nbfDate = new DateTime(2025, 12, 15);
            if (DateTime.Now < nbfDate)
            {
                //diadema
                if (CNPJ == "02095918000197")
                    return "024f2757412807a02337a6d1fd10fdd1465300787df3af5b872692cb6f0973b0978ca18bdadee709c190a7e7a336bc324d54a4dea95a142de79510d145b21c5f";
                //São Roque
                if (CNPJ == "02095918000359")
                    return "6e0198215f8963c800d746247b9f4b823cbb538cf5383eec593a78f6a59f2ea3b8392c4cb4aba428a6b29fbeb87a2967f6379e540b596fea0c65a96c40e80906";
                //Goiania
                if (CNPJ == "15505075000100")
                    return "921e6132d1a66e0c1999e15ee2c87bc8c01db378326977a77b288a46ea0757bb7cdd5262ff45ef78474d5d4c419c6b843c6732864d759202c90ce99127f0bf44";
                //Recife
                if (CNPJ == "02095918000430")
                    return "a4a84a716412ebe4ac351ae4f8f028385edcdc5f072197a0c6113630ad7e59549026525e6d6b93453a5fbfbae79f18ef2c2e417b95ddba2b422fd5c1e90d0c2e";
            }

            DateTime assinantesDate = new DateTime(2022, 12, 5);
            if(DateTime.Now < assinantesDate)
            {
                if (CNPJ == "62958491000135")
                    return "23702a5fcbee4845f307306308f40252df5b0c98712c443fcd545c7f269241f4a98a3704ec696701e881059500114de062f1c5c38d1b9ab54f27baf7526de71d";
            }

            DateTime livrosDate = new DateTime(2022, 12, 15);
            if (DateTime.Now < livrosDate)
            {
                if (CNPJ == "62151188000126")
                    return "f4594ff070e5d45742445dcf1b4f38eae91a59026977075c1f25eb9352d8be440d47766261f66eaf00d66bf23d1bd33f5b2d30e4da7003b8fb761917eefb9d4d";
            }

            throw new HttpListenerException();
            return "";
        }

    }
}
