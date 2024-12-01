using NotaEletronica.DAL;
using NotaEletronica.Models; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NotaEletronica.Util
{
    public static class Util
    {
        const string senha = "12345";

        public enum TypeString
        {
            Text,
            Numeric,
            CNPJ,
            CPF,
            Date,
            Int,
            CEP,
            Telephone,
            Currency
        }

        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }

        public static bool EnviarEmail(string Assunto, string mensagem, string destinatario, string Anexo1, string Anexo2, string Anexo3, NFeParametro eMail)
        {
            // = new NFE_ParametrosDAL().Get().ToList()[0];

            string sUserName = eMail.eEmail;
            string sPassword = eMail.eSenha;
            string sBobdy = mensagem;

            MailMessage objEmail = new MailMessage();
            destinatario = destinatario.Replace(";", ",");
            string[] emails = destinatario.Split(',');
            foreach(var s in emails)
            {
                if(!string.IsNullOrEmpty(s.Trim()))
                {
                    if(emailIsValid(s.Trim()))
                    {
                        objEmail.To.Add(s.Trim());
                    }
                }
            }

            if(objEmail.To.Count == 0)
            {
                return false;
            }
            
            objEmail.From = new MailAddress(sUserName.Trim());
            objEmail.Subject = Assunto;
            objEmail.IsBodyHtml = true;
            objEmail.Body = sBobdy;

            string strSmtp = eMail.eSMTP;
            int porta = Convert.ToInt32(eMail.ePort);
            bool ssl = eMail.eSSL;

            if(!String.IsNullOrEmpty(Anexo1))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Anexo1);
                objEmail.Attachments.Add(attachment);
            }

            if (!String.IsNullOrEmpty(Anexo2))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Anexo2);
                objEmail.Attachments.Add(attachment);
            }

            if (!String.IsNullOrEmpty(Anexo3))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Anexo3);
                objEmail.Attachments.Add(attachment);
            }

            SmtpClient smtp = new SmtpClient(strSmtp, porta /* TLS */);
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = ssl;
            smtp.Credentials = new NetworkCredential(sUserName, sPassword, "");
            try
            {
                smtp.Send(objEmail);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Aconteceu um erro: " + ex.Message);
                return false;
            }
        }

        public static void showBalloon(string body)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(5000, "ERP MGA - Informação", body, ToolTipIcon.Info);
        }

        

        public static string MudaLetra(string value)
        {
            if(value == null)
            {
                return "";
            }
            string Aux = "";
            string Valor = value.Trim();
            string ValueToReturn = "";
            for (int i = 0; i < Valor.Length; i++)
            {
                Aux = Valor.Substring(i, 1).ToUpper();
                switch (Aux)
                {
                    case "À": Aux = "A"; break;
                    case "Â": Aux = "A"; break;
                    case "Ã": Aux = "A"; break;
                    case "Á": Aux = "A"; break;
                    case "É": Aux = "E"; break;
                    case "Ê": Aux = "E"; break;
                    case "È": Aux = "E"; break;
                    case "Í": Aux = "I"; break;
                    case "Ì": Aux = "I"; break;
                    case "Î": Aux = "I"; break;
                    case "Ô": Aux = "O"; break;
                    case "Õ": Aux = "O"; break;
                    case "Ó": Aux = "O"; break;
                    case "Ò": Aux = "O"; break;
                    case "Ú": Aux = "U"; break;
                    case "Ù": Aux = "U"; break;
                    case "Û": Aux = "U"; break;
                    case "Ü": Aux = "U"; break;
                    case "Ç": Aux = "C"; break;
                    case "<": Aux = ""; break;
                    case ">": Aux = ""; break;
                    case "/": Aux = " "; break;
                    case ",": Aux = ""; break;
                    case "-": Aux = ""; break;
                    case "º": Aux = ""; break;
                    case "&": Aux = ""; break;
                    case ";": Aux = ""; break;
                    case "(": Aux = ""; break;
                    case ")": Aux = ""; break;
                    case "*": Aux = ""; break;
                    case "├": Aux = ""; break;
                    case ".": Aux = ""; break;               }
                ValueToReturn += Aux;
            }
            return ValueToReturn.Replace("  ", " ");
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Efetua a criptografia de uma string
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Criptografar(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Efetua a descriptografia de uma string
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Descriptografar(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }

         
        public static string ExcelNumbertoLetter(int Column)
        {
            string Letter = "";
            switch (Column)
            {
                case 1: Letter = "A"; break;
                case 2: Letter = "B"; break;
                case 3: Letter = "C"; break;
                case 4: Letter = "D"; break;
                case 5: Letter = "E"; break;
                case 6: Letter = "F"; break;
                case 7: Letter = "G"; break;
                case 8: Letter = "H"; break;
                case 9: Letter = "I"; break;
                case 10: Letter = "J"; break;
                case 11: Letter = "K"; break;
                case 12: Letter = "L"; break;
                case 13: Letter = "M"; break;
                case 14: Letter = "N"; break;
                case 15: Letter = "O"; break;
                case 16: Letter = "P"; break;
                case 17: Letter = "Q"; break;
                case 18: Letter = "R"; break;
                case 19: Letter = "S"; break;
                case 20: Letter = "T"; break;
                case 21: Letter = "U"; break;
                case 22: Letter = "V"; break;
                case 23: Letter = "W"; break;
                case 24: Letter = "X"; break;
                case 25: Letter = "Y"; break;
                case 26: Letter = "Z"; break;
                case 27: Letter = "AA"; break;
                case 28: Letter = "AB"; break;
                case 29: Letter = "AC"; break;
                case 30: Letter = "AD"; break;
                case 31: Letter = "AE"; break;
                case 32: Letter = "AF"; break;
                case 33: Letter = "AG"; break;
                case 34: Letter = "AH"; break;
                case 35: Letter = "AI"; break;
                case 36: Letter = "AJ"; break;
                case 37: Letter = "AK"; break;
                case 38: Letter = "AL"; break;
                case 39: Letter = "AM"; break;
                case 40: Letter = "AN"; break;
                case 41: Letter = "AO"; break;
                case 42: Letter = "AP"; break;
                case 43: Letter = "AQ"; break;
                case 44: Letter = "AR"; break;
                case 45: Letter = "AS"; break;
                case 46: Letter = "AT"; break;
                case 47: Letter = "AU"; break;
                case 48: Letter = "AV"; break;
                case 49: Letter = "AW"; break;
                case 50: Letter = "AX"; break;
                case 51: Letter = "AY"; break;
                case 52: Letter = "AZ"; break;
                case 53: Letter = "BA"; break;
                case 54: Letter = "BB"; break;
                case 55: Letter = "BC"; break;
                case 56: Letter = "BD"; break;
                case 57: Letter = "BE"; break;
                case 58: Letter = "BF"; break;
                case 59: Letter = "BG"; break;
                case 60: Letter = "BH"; break;
                case 61: Letter = "BI"; break;
                case 62: Letter = "BJ"; break;
                case 63: Letter = "BK"; break;
                case 64: Letter = "BL"; break;
                case 65: Letter = "BM"; break;
                case 66: Letter = "BN"; break;
                case 67: Letter = "BO"; break;
                case 68: Letter = "BP"; break;
                case 69: Letter = "BQ"; break;
                case 70: Letter = "BR"; break;
                case 71: Letter = "BS"; break;
                case 72: Letter = "BT"; break;
                case 73: Letter = "BU"; break;
                case 74: Letter = "BV"; break;
                case 75: Letter = "BW"; break;
                case 76: Letter = "BX"; break;
                case 77: Letter = "BY"; break;
                case 78: Letter = "BZ"; break;
                case 79: Letter = "CA"; break;
                case 80: Letter = "CB"; break;
                case 81: Letter = "CC"; break;
                case 82: Letter = "CD"; break;
                case 83: Letter = "CE"; break;
                case 84: Letter = "CF"; break;
                case 85: Letter = "CG"; break;
                case 86: Letter = "CH"; break;
                case 87: Letter = "CI"; break;
                case 88: Letter = "CJ"; break;
                case 89: Letter = "CK"; break;
                case 90: Letter = "CL"; break;
                case 91: Letter = "CM"; break;
                case 92: Letter = "CN"; break;
                case 93: Letter = "CO"; break;
                case 94: Letter = "CP"; break;
                case 95: Letter = "CQ"; break;
                case 96: Letter = "CR"; break;
                case 97: Letter = "CS"; break;
                case 98: Letter = "CT"; break;
                case 99: Letter = "CU"; break;
                case 100: Letter = "CV"; break;
                case 101: Letter = "CW"; break;
                case 102: Letter = "CX"; break;
                case 103: Letter = "CY"; break;
                case 104: Letter = "CZ"; break;
            }
            return Letter;
        }

        public static bool ExisteElemento(XElement pElementoPai, XNamespace ns, string pElemento)
        {
            bool exist = false;

            if (pElementoPai != null)
            {
                if (pElementoPai.Element(ns + pElemento) != null)
                {
                    exist = true;
                }
            }

            return exist;
        }
         
        public static string FormatString(string Value, TypeString tType)
        {
            try
            {
                switch (tType)
                {
                    case TypeString.CNPJ:
                        return string.Format("{0}.{1}.{2}/{3}-{4}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3), Value.Substring(8, 4), Value.Substring(12, 2));
                    case TypeString.CPF:
                        return string.Format("{0}.{1}.{2}-{3}", Value.Substring(0, 3), Value.Substring(3, 3), Value.Substring(6, 3), Value.Substring(9, 2));
                    case TypeString.Date:
                        if (Convert.ToDateTime(Value) == Convert.ToDateTime("1/1/1900"))
                            return string.Empty;
                        else
                            return Convert.ToDateTime(Value).ToString("dd/MM/yyyy");
                    case TypeString.Numeric:
                        return Convert.ToDouble(Value).ToString("#,##0.00");
                    case TypeString.Int:
                        return Convert.ToInt64(Value).ToString("#,##0");
                    case TypeString.Text:
                        return Value;
                    case TypeString.CEP:
                        return string.Format("{0}{1}-{2}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3));
                    case TypeString.Telephone:
                        Value = Value.Replace("-", "").Replace(" ", "").Replace(".", "");
                        return string.Format("{0}-{1}", Value.Substring(0, Value.Length - 4), Value.Substring(Value.Length - 4, 4));
                    case TypeString.Currency:
                        return Convert.ToDouble(Value).ToString("C");
                    default:
                        return Value;
                }
            }
            catch
            {
                return Value;
            }
        }

        public static string GetAppSettings(string prtChave)
        {
            return ConfigurationManager.AppSettings[prtChave];
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static bool IsNumber(string Value)
        {
            bool ok = true;
            try
            {
                decimal a = Convert.ToDecimal(Value);
            }
            catch(Exception ex)
            {
                ok = false;
            }
            return ok;
        }

        public static object IsNull(object Parametro1, object Parametro2)
        {
            if (Parametro1 == null)
            {
                return Parametro2;
            }
            else
            {
                return Parametro1;
            }
        }
         
        /// <summary>
        /// Retirar todos os caracteres não numéricos
        /// </summary>
        /// <param name="toNormalize"></param>
        /// <returns>Retorna somente números</returns>
        public static string OnlyNumbers(string toNormalize)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static Bitmap _currentBitmap;

        public static Bitmap CurrentBitmap
        {
            get
            {
                return _currentBitmap;
            }
            set
            {
                _currentBitmap = value;
            }
        }

        public static Image ResizeImage(int newWidth, int newHeight)
        {
            Image imgPhoto = _currentBitmap;
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;
                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;
            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                (sourceHeight * nPercent)) / 2);
            }
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bmPhoto.MakeTransparent(Color.White);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
            grPhoto.Dispose();
            imgPhoto.Dispose();

            return bmPhoto;
        }

        public static void ResizeImageNoTransparency(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }
                _currentBitmap = (Bitmap)bmap.Clone();
            }
        }

        public static void SetAppSettings(string prtChave, string prtTexto)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[prtChave].Value = prtTexto;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string PreencheCampoString(string Value, int Tamanho)
        {
            string Retorno = Value == null ? "" : Value;

            //Verifica se a string é maior que o tamanho solicitado
            if (Retorno.Length > Tamanho)
            {
                Retorno = Value.ToString().Substring(0, Tamanho);
            }

            //Preenche os campos faltantes em branco
            int iSize = Retorno.Length;
            for (int i = iSize; i < Tamanho; i++)
            {
                Retorno += " ";
            }
            return Retorno.ToUpper();
        }
        
        public static string PreencheCampoData(DateTime Value, int Tamanho)
        {

            string Retorno = Value.ToString("ddMMyyyy");

            //Verifica se a string é maior que o tamanho solicitado
            if (Retorno.Length > Tamanho)
            {
                Retorno = Value.ToString("ddMMyyyy");
            }
            return Retorno;
        }
        public static string PreencheCampoHora(DateTime Value, int Tamanho)
        {

            string Retorno = Value.ToString("HHmmss");

            //Verifica se a string é maior que o tamanho solicitado
            if (Retorno.Length > Tamanho)
            {
                Retorno = Value.ToString("HHmmss");
            }
            return Retorno;
        }

        public static string PreencheCampoDecimal(decimal Value, int Tamanho)
        {
            var valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###.##}", Value);

            return valorFormatado.ToString().Replace(",", "").Replace(".", "").PadLeft(Tamanho + 2, '0');
        }

        public static string PreencheCampoInt(int? Value, int Tamanho)
        {
            string Retorno = Value.ToString();

            if (Value != null)
            {
                //Verifica se a string é maior que o tamanho solicitado
                if (Retorno.Length > Tamanho)
                {
                    return Retorno = Value.ToString().Substring(0, Tamanho);
                }
            }

            //Preenche os campos faltantes com zero
            Retorno = Value.ToString().PadLeft(Tamanho, '0');

            return Retorno;
        }

        public static string FormatarCpfCnpj(string strCpfCnpj) 
        { 
            if (strCpfCnpj.Length <= 11) 
            { 
                MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00"); 
                mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11)); 
                return mtpCpf.ToString(); 
            } 
            else 
            { 
                MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00"); 
                mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11)); 
                return mtpCnpj.ToString(); 
            } 
        }
         
        public static string ZerosEsquerda(string strString, int intTamanho) 
        { 
            string strResult = ""; 
            for (int intCont = 1; intCont <= (intTamanho - strString.Length); intCont++) 
            { 
                strResult += "0"; 
            } 
            return strResult + strString; 
        }

        public static string DigitoModulo11(string Numero)
        {
            string NumeroAtual;
            string digito;
            int soma;
            int peso;
            int resto;
            int ix;
            try
            {
                NumeroAtual = Numero;
                soma = 0;
                peso = 2;
                for(int i = NumeroAtual.Length; i > 1; i--)
                {
                    soma = soma + Convert.ToInt32(NumeroAtual[i]) * peso; //soma
                    peso = peso + 1; //adiconando o peso
                    if (peso > 7)
                    {
                        peso = 2;
                    } 
                }
                resto = (soma % 11);
                digito = (11 - resto).ToString();
                if(Convert.ToInt32(digito) == 10)
                {
                    digito = "P";
                }
                else if(Convert.ToInt32(digito) == 11)
                {
                    digito = "0";
                }
                return digito;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static decimal? IsNumberZero(string valor)
        {
            try
            {
                return Convert.ToDecimal(valor);
            }
            catch
            {
                return null;
            }
        }

        public static int? IsIntZero(string valor)
        {
            try
            {
                return Convert.ToInt32(valor);
            }
            catch
            {
                return null;
            }
        }

        public static string ToString(object o)
        {
            return o == null ? "" : o.ToString();
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(",", "").Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

    }
}
