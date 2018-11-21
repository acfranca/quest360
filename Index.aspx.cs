using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using System.Configuration;
using _WebControls;

namespace WebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSEnviarEmail(string pNome, string pEmail, string pDescricao)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Dispara o envio de e-mail
            string resultado = new Index().DispararEmail(pNome, pEmail, pDescricao);

            if (resultado.Equals("True"))
                lstReturn.Add(resultado);
            else
                lstReturn.Add(resultado);

            return lstReturn;
        }

        #region Métodos Envia Email
        private string DispararEmail(string pNome, string pEmail, string pDescricao)
        {
            //Instancia classe que irá ler dados do web.config
            AppSettingsReader obj = new AppSettingsReader();

            //Descriptografa senha do e-mail
            string vPassword = new Funcoes().DecryptString(obj.GetValue("DefaultMailPassWord", typeof(String)).ToString());

            try
            {
                EnviaEmail SendEmail = new EnviaEmail();

                SendEmail.Assunto = "Contato através do Site Quest360";
                SendEmail.Corpo = this.CorpoEmail(pNome, pEmail, "Contato - Site Quest360", pDescricao);
                SendEmail.Destinatarios = obj.GetValue("DefaultMailAddressDestino", typeof(String)).ToString();

                SendEmail.EmailSend(
                      obj.GetValue("DefaultMailHost", typeof(String)).ToString()
                    , int.Parse(obj.GetValue("DefaultMailPort", typeof(String)).ToString())
                    , obj.GetValue("DefaultMailAddressRemetente", typeof(String)).ToString()
                    , obj.GetValue("DefaultMailDisplayName", typeof(String)).ToString()
                    , vPassword
                    , obj.GetValue("DefaultMailEnableSSL", typeof(String)).ToString().Equals("S")
                    );

                return "True";
            }
            catch
            {
                //Mostra Msg Log de Erro;
                return "O Suporte Técnico já foi acionado. Pedimos a gentileza de tentar mais tarde.";
            }
        }
        private string CorpoEmail(string pNome, string pEmail, string pAssunto, string pDescricao)
        {
            //Monta texto do contato
            StringBuilder strCorpo = new StringBuilder();

            strCorpo.Append("<table style='width:400px; padding:0;' cellspacing='4'>");
            strCorpo.Append("<tr><td style='border: thin solid #CCCCCC; font-family:Arial; font-size:small; color:#525a74; padding:4px; width: 30%;'>Nome:</td><td width='70%'>");
            strCorpo.Append(pNome + "</td></tr>");
            strCorpo.Append("<tr><td style='border: thin solid #CCCCCC; font-family:Arial; font-size:small; color:#525a74; padding:4px; width: 30%;'>Email:</td><td width='70%'>");
            strCorpo.Append(pEmail + "</td></tr>");
            strCorpo.Append("<tr><td style='border: thin solid #CCCCCC; font-family:Arial; font-size:small; color:#525a74; padding:4px; width: 30%;'>Assunto:</td><td width='70%'>");
            strCorpo.Append(pAssunto + "</td></tr>");
            strCorpo.Append("<tr><td style='border: thin solid #CCCCCC; font-family:Arial; font-size:small; color:#525a74; padding:4px; width: 30%;'>Descrição:</td><td width='70%'>");
            strCorpo.Append(pDescricao + "</td></tr></table>");

            return strCorpo.ToString();
        }
        #endregion
    }
}