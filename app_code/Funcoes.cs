using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;
using System.Net.Mime;

namespace Site_Interessado.app_code
{
    public static class Funcoes
    {

        public static string FixupUrl(string Url)
        {
            if (Url.StartsWith("~"))
                return (HttpContext.Current.Request.ApplicationPath +
                         Url.Substring(1)).Replace("//", "/");
            return Url;
        }

        public static bool IsValidEmail(string EMail)
        { // Verifica se o valor passado é um Email válido
            bool Valido = false;

            if (EMail.Length > 0)
            {
                /* esta versão funciona mas admitia somente 3 caracteres na última porção como "com" mas falhava
                    no caso de "aero" porque tem 4 caracteres.
                    Passando de {2,3}$")) para {2,4}$")) funciona, mas se houver alguma alteração no futuro, para 5 caracteres por exemplo,
                    vai falhar novamente. 
                // Caracteres que não podem existir
                if (! System.Text.RegularExpressions.Regex.IsMatch(EMail, "[^@\\-\\.\\w]|^[_@\\.\\-]|[\\._\\-]{2}|[@\\.]{2}|(@)[^@]*\\1")) {
                    // Caracteres que tem que existir
                    if (System.Text.RegularExpressions.Regex.IsMatch(EMail, "@[\\w\\-]+\\.")) {
                        if (System.Text.RegularExpressions.Regex.IsMatch(EMail, "\\.[a-zA-Z]{2,4}$")) {
                            Valido = true;
                        }
                    }
                }
                */
                if (Regex.IsMatch(EMail,
                    @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
                {
                    Valido = true;
                }
            }

            return Valido;
        }

        public static string FormataDataBRtoUS(string data_)
        {
            if ((data_ != "") && (data_ != null))
            {
                //DateTime date1 = DateTime.Parse(data_);
                //return date1.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
                return data_.Substring(6, 4) + "/" + data_.Substring(3, 2) + "/" + data_.Substring(0, 2);
            }
            else
            {
                return "";
            }
        }

        public static bool IsValidDate(string sDate)
        { // Verifica se o valor passado é Data válida
            bool Valido = false;

            if (sDate.Length > 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(sDate, "^(0[1-9]|[12][0-9]|3[01])[-\\./](0[1-9]|1[012])[- /\\.](19|20)\\d\\d$"))
                {
                    Valido = true;
                }
            }

            return Valido;
        }

        public static string SecureHtml(string S)
        { // Retorna string sem comandos para SQL injection
            if (S.Length > 0)
            {
                // Troca aspas simples por duas aspas simples evitando SQL injection
                S = TrocaAspasSimples(S);

                string[] eliminar = { "select ", "drop ", "insert ", "delete ", "xp_", "update ", "having ", "--" };
                foreach (string sEliminar in eliminar)
                {
                    //S = S.Replace(sEliminar, ""); // não é case insensitive
                    S = ReplaceEx(S, sEliminar, "");
                }
            }

            return S;
        }

        public static string TrocaAspasSimples(string s)
        {
            // Substitui ' por '' - evita Sql injection e erro em SQL devido à ' como: John's Bar

            if (s.Contains("'"))
            {
                // Se já existe '' não pode trocar cada uma por ' senão vai dar ''''
                char aspas = Convert.ToChar(39);
                int tam = s.Length;
                bool achouAspas = false;

                StringBuilder builder = new StringBuilder();

                for (int x = 0; x < tam; x++)
                {
                    if (s[x] != aspas || !achouAspas)
                    { // Não é aspas ou é a 1a. ocorrência de aspas, portanto insere-a
                        builder.Append(s[x]);
                        if (s[x] == aspas)
                        {
                            builder.Append(aspas); // Coloca mais uma, duplicando as aspas
                            achouAspas = true;
                        }
                        else
                        {
                            achouAspas = false;
                        }
                    }
                }
                s = builder.ToString();
            }

            return s;
        }

        private static string ReplaceEx(string original, string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                 position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];

            return new string(chars, 0, count);
        }

        public static bool EnviarEMail(string ParaMail, string Assunto, string Corpo, string Anexo, string comCopia)
        {

            string EMailSMTP = System.Configuration.ConfigurationManager.AppSettings["EMailSMTP"].ToString();
            string EMailUsername = System.Configuration.ConfigurationManager.AppSettings["EMailUsername"].ToString();
            string EMailPassword = System.Configuration.ConfigurationManager.AppSettings["EMailPassword"].ToString();
            string EMailOrigem = System.Configuration.ConfigurationManager.AppSettings["EMailOrigem"].ToString();
            int Port = 587;
            try
            {
                Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EMailPort"].ToString());
            }
            catch
            {
                Port = 587;
            }

            bool ssl = false;
            try
            {
                ssl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EMailSSL"].ToString());
            }
            catch { }

            return EnviarEMailByNetMail(EMailSMTP, EMailUsername, EMailPassword,
                                        EMailOrigem, ParaMail, Assunto, Corpo, Anexo, comCopia, Port, ssl);

        }
        //----------------------------------------------------------------------
        public static bool EnviarEMaila(string EMailOrigem, string ParaMail, string Assunto, string Corpo, string Anexo, string comCopia)
        {

            string EMailSMTP = System.Configuration.ConfigurationManager.AppSettings["EMailSMTP"].ToString();
            string EMailUsername = System.Configuration.ConfigurationManager.AppSettings["EMailUsername"].ToString();
            string EMailPassword = System.Configuration.ConfigurationManager.AppSettings["EMailPassword"].ToString();
            int Port = 587;
            try
            {
                Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EMailPort"].ToString());
            }
            catch
            {
                Port = 587;
            }

            bool ssl = false;
            try
            {
                ssl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EMailSSL"].ToString());
            }
            catch { }

            return EnviarEMailByNetMail(EMailSMTP, EMailUsername, EMailPassword,
                                        EMailOrigem, ParaMail, Assunto, Corpo, Anexo, comCopia, Port, ssl);

        }
        //----------------------------------------------------------------------
        public static bool EnviarEMailByNetMail(string HostName,
                                                   string UserName, string Password,
                                                   string DeMail, string ParaMail,
                                                   string Assunto, string Corpo,
                                                   string Anexo, string comCopia, int Port, bool ssl)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new SmtpClient();
                System.Net.NetworkCredential basicAuthenticationInfo =
                    new System.Net.NetworkCredential(UserName, Password);
                client.Host = HostName;
                client.UseDefaultCredentials = false;
                client.Credentials = basicAuthenticationInfo;
                client.Port = Port;
                client.EnableSsl = ssl;

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(DeMail);
                message.To.Add(new System.Net.Mail.MailAddress(ParaMail));
                //message.To.Add(new MailAddress("recipient2@foo.bar.com"));
                //message.To.Add(new MailAddress("recipient3@foo.bar.com"));
                if (comCopia != "")
                {
                    string[] cc = null;
                    if (comCopia.IndexOf(",") > -1)
                    {
                        cc = comCopia.Split(',');
                    }
                    else if (comCopia.IndexOf(";") > -1)
                    {
                        cc = comCopia.Split(';');
                    }
                    else
                    {
                        message.CC.Add(new MailAddress(comCopia));
                    }

                    if (cc != null)
                    {
                        for (int x = 0; x < cc.Length; x++)
                        {
                            message.CC.Add(new MailAddress(cc[x]));
                        }
                    }
                }

                // Seta encoding
                message.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                message.SubjectEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");

                /* message.SubjectEncoding
                    No projeto da Strong estava retornando assunto como 
                        =?iso-8859-1?Q?Altera=E7=E3o - CQFGV - Programa Certifica=E7=E3o FGV de Qualidade?=
                    Então mudei para utf-8 e resolveu mas deixei como função separada em funcoes_adm.cs 
                */

                if (Anexo != "")
                {
                    string FilePath = HttpContext.Current.Server.MapPath(
                        System.Configuration.ConfigurationManager.AppSettings["virtualPath"].ToString());

                    // Os arquivos vem separados por \n\r - é preciso trocar ambos
                    string Anexos = ChangeCharInString(Anexo, '\n', ";");
                    Anexos = ChangeCharInString(Anexos, '\r', "");
                    string[] Arquivos = Anexos.Split(new char[] { ';' });

                    foreach (string Arquivo in Arquivos)
                    {
                        if (Arquivo != "")
                        {
                            message.Attachments.Add(new System.Net.Mail.Attachment(FilePath + Arquivo,
                                                                                   MediaTypeNames.Application.Octet));
                        }
                    }
                }

                message.Subject = Assunto;
                message.IsBodyHtml = true;
                message.Body = Corpo;

                client.Send(message);

                message.Dispose(); // Isto é fundamental senão mantém os arquivos anexados abertos, não sendo permitido modificá-los

                return true;
            }
            catch
            {
                return false; // Verifique se o e-mail é alfmarc.psc.br ou axisfocus.com e, neste caso, se existe realmente, senão vai falhar aqui
            }

            /* somente usar durante desenvolvimento
            catch (Exception ex){
                string Mensagem = "Erro: " + ex.Message.ToString() + "\r\n" +
                ex.StackTrace.ToString();
                Say(Mensagem);
                f.debugAdd(Mensagem);
                return false;
            }
            */
        }

        public static string ChangeCharInString(string S, char De, string Para)
        { // Troca char por char ou string
            string finalS = "";

            for (int counter = 0; counter < S.Length; counter++)
            {
                if (S[counter] == De)
                {
                    finalS = finalS + Para.ToString();
                }
                else
                {
                    finalS = finalS + S[counter];
                }
            }
            return finalS;
        }

    }//
}//