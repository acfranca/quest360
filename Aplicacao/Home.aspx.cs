using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Security;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestRep._BackEnd;
using _WebControls;

namespace QuestRep.WebApplication.Aplicacao
{
    public partial class Home : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) {

                //Seta Ambiente
                this.SetaAmbiente();

                //Habilita Menu
                this.MostraSecao(this.scClient);
            }
        }
        protected void hpCliente_Click(object sender, EventArgs e)
        {
            //Mostra Seção Cliente
            this.MostraSecao(this.scClient);

            //Mostra Grid Clientes
            this.MostraListaClientes(true);

            //Limpa Formulário Cliente
            this.LimpaFormularioCliente();
        }
        protected void hpUser_Click(object sender, EventArgs e)
        {
            //Limpa o campos Msg
            this.lblMsgUser.Text = "<br />";
            this.MostraSecao(this.scUser);
        }
        protected void hpConfig_Click(object sender, EventArgs e)
        {
            this.MostraSecao(this.scAdmin);
        }
        protected void hpSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Acesso.aspx");
        }
        protected void btnSenha_Click(object sender, EventArgs e)
        {
            if (this.ValidaPreenchimentoSenha())
            {
                //Pega os dados do usuário através do código na Sessão
                new Representante().AlterarSenha(Convert.ToInt64(Session["CdRepresentante"].ToString()), FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtUserSenha.Text, "MD5"));

                //Mostra Msg de Sucesso
                this.lblMsgUser.Text = "Senha alterada com sucesso!";
            }
        }
        protected void btnNovoCliente_Click(object sender, EventArgs e) {
            this.MostraListaClientes(false);

            //Limpa o campos Msg
            this.lblMsgCli.Text = "<br />";
        }
        protected void btnCadCliente_Click(object sender, EventArgs e) {

            //Valida prenchimentos dos campos obrigatórios
            if (!this.ValidaPreenchimentoCliente())
                return;

            //Verifica qual tipo de documento foi preenchido
            string strCNPJ = this.ddlCliPessoa.SelectedValue.Equals("J") ? this.txtCliDoc.Text : string.Empty;
            string strCPF = string.IsNullOrEmpty(strCNPJ) ? this.txtCliDoc.Text : string.Empty;

            //Incluir novo cliente
            //new Cliente().Incluir(this.txtCliNome.Text
            //    , this.txtCliResponsavel.Text
            //    , this.txtCliEmail.Text
            //    , Convert.ToChar(this.ddlCliPessoa.SelectedValue)
            //    , strCPF
            //    , strCNPJ
            //    , Convert.ToInt64(Session["CdRepresentante"].ToString())
            //    , Convert.ToDateTime(this.txtCliVigenciaInicio.Text)
            //    , Convert.ToDateTime(this.txtCliVigenciaTermino.Text)
            //    , Convert.ToChar(this.ddlCliVigencia.SelectedValue)
            //    , Convert.ToInt32(this.txtCliQtdeLicenca.Text)
            //    , Convert.ToInt32(this.txtCliQtdeTablet.Text)
            //    , Convert.ToInt32(this.txtCliQtdeSupMesa.Text)
            //    , Convert.ToInt32(this.txtCliQtdeSupChao.Text)
            //    , Convert.ToDecimal(this.txtCliTotal.Text.Remove(0, 2))
            //    );

            //Mostra mensagem com sucesso
            this.lblMsgCli.Text = "Registro salvo com sucesso";

            //Limpa Formulário Cliente
            this.LimpaFormularioCliente();

            //Carrega Lista Clientes
            this.CarregaListaClientes();
        }
        protected void btnCadVoltar_Click(object sender, EventArgs e)
        {
            //Mostra Grid Clientes
            this.MostraListaClientes(true);

            //Limpa Formulário Cliente
            this.LimpaFormularioCliente();
        }
        protected void _ValueChanged(object sender, EventArgs e)
        {
            //Calcula Saldo Total
            this.CalculaSaldoTotal();
        }
        protected void _ValueVigenciaChanged(object sender, EventArgs e)
        {
            //Calcula Início Vigência
            this.txtCliVigenciaInicio.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");

            //Calcula os dias de Vigência
            double _DiasVigencia = this.ddlCliVigencia.SelectedValue.Equals("T") ? 90 : this.ddlCliVigencia.SelectedValue.Equals("S") ? 180 : 365;

            //Calcula Fim Vigência
            this.txtCliVigenciaTermino.Text = Convert.ToDateTime(this.txtCliVigenciaInicio.Text).AddDays(_DiasVigencia).ToString("dd/MM/yyyy");

            //Calcula Saldo Total
            this.CalculaSaldoTotal();
        }
        #endregion

        #region Métodos
        private void MostraSecao(System.Web.UI.HtmlControls.HtmlGenericControl sc)
        {
            this.scClient.Visible = false;
            this.scUser.Visible = false;
            this.scAdmin.Visible = false;

            sc.Visible = true;
        }
        private void SetaAmbiente()
        {
            //Seta os valores da Sessão
            this.lblName.Text = Session["NmRepresentante"].ToString();
            this.lblPerfil.Text = Session["NmPerfil"].ToString();
            this.txtCliRepresentante.Text = this.lblName.Text;

            //Oculta o botão Configuração se o usuário for um representante
            this.hpConfig.Visible = !this.lblPerfil.Text.Equals("Representante");

            //Carrega Dados Usuário
            this.CarregaDadosRepresentante();

            //Carrega Lista Clientes
            this.CarregaListaClientes();

            //Limpa Formulário Cliente
            this.LimpaFormularioCliente();
        }
        private void CarregaDadosRepresentante()
        {
            //Pega os dados do representante através do código na Sessão
            DataTable dtRepresentante = new Representante().Selecionar(Convert.ToInt64(Session["CdRepresentante"].ToString()));

            //Preenche os dados do usuário logado...
            if (dtRepresentante.Rows.Count > 0)
            {
                this.txtUserNome.Text = dtRepresentante.Rows[0]["NOME"].ToString();
                this.txtUserEmail.Text = dtRepresentante.Rows[0]["EMAIL"].ToString();
                this.txtUserPerfil.Text = dtRepresentante.Rows[0]["PERFIL"].ToString();
                this.txtUserDoc.Text = dtRepresentante.Rows[0]["PESSOA"].ToString().Equals("F") ? dtRepresentante.Rows[0]["CPF"].ToString() : dtRepresentante.Rows[0]["CNPJ"].ToString();
            }
        }
        private void CarregaListaClientes()
        {
            //Pega os dados do usuário através do código na Sessão
            DataTable dtClientes = new Cliente().Selecionar(long.MinValue, (this.lblPerfil.Text.Equals("Administrador") ? int.MinValue : Convert.ToInt32(Session["CdRepresentante"].ToString())), string.Empty, string.Empty);

            //Declara string que irá gerar a grid
            StringBuilder strGridCliente = new StringBuilder();

            //Lista os clientes do usuário logado...
            foreach (DataRow dr in dtClientes.Rows)
                strGridCliente.Append("<div class='row'><div class='col-9 menu'><ul><li>"
                    + dr["NOME"].ToString()
                    + "</li></ul></div><div class='col-3A menu'><ul><li>"
                    + DateTime.Parse(dr["DTA_VIGENCIA_INICIO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy")
                    + " - " + DateTime.Parse(dr["DTA_VIGENCIA_TERMINO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy")
                    + "</li></ul></div><div class='col-3B menu'><ul><li>"
                    + DateTime.Parse(dr["DTA_VIGENCIA_TERMINO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy")
                    + "</li></ul></div></div>");

            this.lblGridCliente.Text = strGridCliente.ToString();
        }
        private void LimpaFormularioCliente()
        {
            //Limpar Formulário
            this.txtCliNome.Text = string.Empty;
            this.txtCliResponsavel.Text = string.Empty;
            this.txtCliEmail.Text = string.Empty;
            this.txtCliDoc.Text = string.Empty;
            this.ddlCliPessoa.SelectedIndex = -1;
            this.ddlCliVigencia.SelectedIndex = -1;
            this.txtCliQtdeLicenca.Text = "0";
            this.txtCliQtdeTablet.Text = "0";
            this.txtCliQtdeSupMesa.Text = "0";
            this.txtCliQtdeSupChao.Text = "0";
            this.txtCliTotal.Text = "R$ 0,00";

            //Seta Início Vigência
            this.txtCliVigenciaInicio.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");

            //Seta Fim Vigência
            this.txtCliVigenciaTermino.Text = Convert.ToDateTime(this.txtCliVigenciaInicio.Text).AddDays(90).ToString("dd/MM/yyyy");

        }
        private void MostraListaClientes(bool pMostrar)
        {
            this.divGridCliente.Visible = pMostrar;
            this.divCadCliente.Visible = !pMostrar;
        }
        private bool ValidaPreenchimentoSenha()
        {
            //Limpa o campos Msg
            this.lblMsgUser.Text = string.Empty;

            if (string.IsNullOrEmpty(this.txtUserSenha.Text.Trim()))
                this.lblMsgUser.Text = "Senha é obrigatório.";

            else if (string.IsNullOrEmpty(this.txtUserConfirma.Text.Trim()))
                this.lblMsgUser.Text = "Confirma Senha é obrigatório.";

            else if (!(this.txtUserSenha.Text.Equals(this.txtUserConfirma.Text.Trim())))
                this.lblMsgUser.Text = "Os campos Senha e Confirma Senha não estão iguais.";

            return string.IsNullOrEmpty(this.lblMsgUser.Text);
        }
        private bool ValidaPreenchimentoCliente()
        {
            //Limpa o campos Msg
            this.lblMsgCli.Text = string.Empty;

            if (string.IsNullOrEmpty(this.txtCliNome.Text.Trim()))
                this.lblMsgCli.Text = "Nome é obrigatório.";

            else if (string.IsNullOrEmpty(this.txtCliEmail.Text.Trim()))
                this.lblMsgCli.Text = "E-mail é obrigatório.";

            else if (string.IsNullOrEmpty(this.txtCliDoc.Text.Trim()))
                this.lblMsgCli.Text = "CPF/CNPJ é obrigatório.";

            else if ((this.txtCliQtdeLicenca.Text.Equals("0")))
                this.lblMsgCli.Text = "Qtde. de Licença é obrigatório.";

            return string.IsNullOrEmpty(this.lblMsgCli.Text);
        }
        private bool CalculaSaldoTotal()
        {
            //Valida o preenchimento dos campos
            this.txtCliQtdeLicenca.Text = new Funcoes().IsNumber(this.txtCliQtdeLicenca.Text) ? this.txtCliQtdeLicenca.Text : "0";
            this.txtCliQtdeTablet.Text = new Funcoes().IsNumber(this.txtCliQtdeTablet.Text) ? this.txtCliQtdeTablet.Text : "0";
            this.txtCliQtdeSupMesa.Text = new Funcoes().IsNumber(this.txtCliQtdeSupMesa.Text) ? this.txtCliQtdeSupMesa.Text : "0";
            this.txtCliQtdeSupChao.Text = new Funcoes().IsNumber(this.txtCliQtdeSupChao.Text) ? this.txtCliQtdeSupChao.Text : "0";

            //Pega o valor da vigência
            decimal _VlrVigencia = this.ddlCliVigencia.SelectedValue.Equals("T") ? Convert.ToDecimal("199,90") : this.ddlCliVigencia.SelectedValue.Equals("S") ? Convert.ToDecimal("359,82") : Convert.ToDecimal("647,68");

            //Calcula o valor da Licença
            decimal _TotalLicenca = Convert.ToInt32(this.txtCliQtdeLicenca.Text) * _VlrVigencia;

            //Calcula o valor do Tablet
            decimal _TotalTablet = Convert.ToInt32(this.txtCliQtdeTablet.Text) * Convert.ToDecimal("605,00");

            //Calcula o valor do Suporte de Mesa
            decimal _TotalSupMesa = Convert.ToInt32(this.txtCliQtdeSupMesa.Text) * Convert.ToDecimal("285,00");

            //Calcula o valor do Suporte de Chão
            decimal _TotalSupChao = Convert.ToInt32(this.txtCliQtdeSupChao.Text) * Convert.ToDecimal("2390,00");

            //Calcula o valor total
            this.txtCliTotal.Text = Convert.ToDecimal(_TotalLicenca + _TotalTablet + _TotalSupMesa + _TotalSupChao).ToString("c2");
            
            return false;
        }
        #endregion
    }
}