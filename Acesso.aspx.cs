using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using _WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestRep._BackEnd;

namespace WebApplication
{
    public partial class Acesso : System.Web.UI.Page
    {
        DataTable dtRepresentante = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidaAcessoSistema())
                {
                    //Autentica o login do usuário
                    FormsAuthentication.SetAuthCookie("Admin", false);

                    //Guardar informações na Sessão
                    Session["CdRepresentante"] = this.dtRepresentante.Rows[0]["CODIGO"].ToString();
                    Session["NmRepresentante"] = this.dtRepresentante.Rows[0]["NOME"].ToString();
                    Session["NmPerfil"] = this.dtRepresentante.Rows[0]["PERFIL"].ToString();

                    //Redireciona para o acesso restrito
                    Response.Redirect("Aplicacao/Start.aspx");
                }
            }
            catch
            {
                //Mostra msg de erro
                this.lblMsg.Text = "Erro ao conectar com o servidor. Aguarde e tente novamente mais tarde.";
            }
        }

        private bool ValidaAcessoSistema()
        {
            //Pega os dados do usuário através do e-mail
            this.dtRepresentante = new Representante().ValidarAcesso(this.email.Text);

            //Se o usuário não estiver cadastrado...
            if (this.dtRepresentante.Rows.Count.Equals(0))
            {
                this.lblMsg.Text = "Representante Inexistente.";
                return false;
            }

            //Se o usuário estiver Inativo
            if (this.dtRepresentante.Rows[0]["ATIVO"].ToString().Equals("N"))
            {
                this.lblMsg.Text = "Representante Inativo.";
                return false;
            }

            //Se a senha do usuário estiver inválida
            if (!this.dtRepresentante.Rows[0]["SENHA"].ToString().Equals(FormsAuthentication.HashPasswordForStoringInConfigFile(this.password.Text, "MD5")))
            {
                this.lblMsg.Text = "Senha Incorreta.";
                return false;
            }

            return true;
        }
    }
}