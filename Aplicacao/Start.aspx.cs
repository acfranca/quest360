using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Security;
using System.Web.Services;
using System.Web.Script.Services;
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
    public partial class Start : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    //Seta Ambiente
                    this.SetaAmbiente();
                }
            }
            catch
            {
                //Redireciona para o acesso restrito
                Response.Redirect("Aplicacao/Acesso.aspx");
            }
        }

        protected void hpSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Acesso.aspx");
        }

        private void SetaAmbiente()
        {
            //Seta os valores da Sessão
            this.lblName.Text = Session["NmRepresentante"].ToString();
            this.lblPerfil.Text = Session["NmPerfil"].ToString();
            this.hdTxtCodUser.Text = Session["CdRepresentante"].ToString();
            this.hdTxtNmUser.Text = Session["NmRepresentante"].ToString();
            this.hdTxtPfUser.Text = Session["NmPerfil"].ToString();
        }

        private List<string> CarregarDadosRepresentante(string pID)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Pega os dados do usuário através do código na Sessão
            DataTable dtRepresentante = new Representante().Selecionar(Convert.ToInt64(pID));

            //Preenche os dados do usuário logado...
            if (dtRepresentante.Rows.Count > 0)
            {
                //Alimenta o Array com as Informações
                lstReturn.Add(dtRepresentante.Rows[0]["NOME"].ToString());
                lstReturn.Add(dtRepresentante.Rows[0]["EMAIL"].ToString());
                lstReturn.Add(dtRepresentante.Rows[0]["PERFIL"].ToString());
                lstReturn.Add(dtRepresentante.Rows[0]["PESSOA"].ToString().Equals("F") ? dtRepresentante.Rows[0]["CPF"].ToString() : dtRepresentante.Rows[0]["CNPJ"].ToString());
                lstReturn.Add(dtRepresentante.Rows[0]["PER_LICENCA"].ToString());
                lstReturn.Add(dtRepresentante.Rows[0]["PER_DISPOSITIVO"].ToString());
            }

            return lstReturn;
        }

        private List<string> CarregarVlrLicenca()
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Pega os dados do usuário através do código na Sessão
            DataTable dtVlrLicenca = new LicencaValor().Selecionar();

            //Preenche os dados do usuário logado...
            if (dtVlrLicenca.Rows.Count > 0)
            {
                //Alimenta o Array com as Informações
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_TRIMESTRAL"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_SEMESTRAL"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_ANUAL"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_TABLET_7"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_SUP_MESA_7"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_TABLET_10"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["VLR_SUP_MESA_10"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["DTA_CRIACAO"].ToString());
                lstReturn.Add(dtVlrLicenca.Rows[0]["NOME"].ToString());
            }

            return lstReturn;
        }

        private List<string> AlterarSenha(string pID, string pSenha)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega os dados do usuário através do código na Sessão
                new Representante().AlterarSenha(Convert.ToInt64(pID), FormsAuthentication.HashPasswordForStoringInConfigFile(pSenha, "MD5"));

                lstReturn.Add("Senha alterada com sucesso!");
            }
            catch
            {
                lstReturn.Add("Erro ao alterar senha!");
            }

            return lstReturn;
        }

        private List<string> ResetarSenha(string pID)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Gera nova Senha
                string pSenha = new Funcoes().alfanumericoAleatorio(6);

                //Pega os dados do usuário através do código na Sessão
                new Representante().AlterarSenha(Convert.ToInt64(pID), FormsAuthentication.HashPasswordForStoringInConfigFile(pSenha, "MD5"));

                lstReturn.Add("</b> foi alterada com sucesso.<br>Anote a nova senha: <b>" + pSenha + "</b>");
            }
            catch
            {
                lstReturn.Add("Erro ao alterar senha!");
            }

            return lstReturn;
        }

        private List<string> AlterarValorLicenca(string pVlrTrimestral, string pVlrSemestral, string pVlrAnual, string pVlrTablet7, string pVlrSupMesa7, string pVlrTablet10, string pVlrSupMesa10, string pVlrChao, string pRepresentante)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega os dados do usuário através do código na Sessão
                new LicencaValor().Incluir(Convert.ToDecimal(pVlrTrimestral), Convert.ToDecimal(pVlrSemestral), Convert.ToDecimal(pVlrAnual), Convert.ToDecimal(pVlrTablet7), Convert.ToDecimal(pVlrSupMesa7), Convert.ToDecimal(pVlrTablet10), Convert.ToDecimal(pVlrSupMesa10), Convert.ToDecimal(pVlrChao), Convert.ToInt32(pRepresentante));

                lstReturn.Add("Valores alterados com sucesso!");
            }
            catch
            {
                lstReturn.Add("Erro ao alterar os valores!");
            }

            return lstReturn;
        }

        private List<string> SalvarCliente(string pCodigo, string pNome, string pResponsavel, string pEmail, string pTelefone, string pEndereco, string pCidade, string pUF, string pCEP, string pTipoPessoa, string pDoc, string pRepresentante)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Aplica a regra de qual documento deve ser preenchido
            string pCPF = pTipoPessoa.Equals("F") ? pDoc : string.Empty;
            string pCNPJ = string.IsNullOrEmpty(pCPF) ? pDoc : string.Empty;

            try
            {
                if (string.IsNullOrEmpty(pCodigo))
                {
                    new Cliente().Incluir(pNome, pResponsavel, Convert.ToInt32(pRepresentante), pEmail, pTelefone, pEndereco, pCidade, pUF, pCEP, Convert.ToChar(pTipoPessoa), pCPF, pCNPJ);
                    lstReturn.Add("Dados do cliente incluído com sucesso.");
                }
                else
                {
                    new Cliente().Alterar(Convert.ToInt64(pCodigo), pResponsavel, pTelefone, pEndereco, pCidade, pUF, pCEP, Convert.ToChar(pTipoPessoa), pCPF, pCNPJ);
                    lstReturn.Add("Dados do cliente alterado com sucesso.");
                }
            }
            catch
            {
                lstReturn.Add("Erro ao incluir clientes!");
            }

            return lstReturn;
        }

        private List<string> CarregarDadosCliente(string pCliente)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Pega os dados do usuário através do código na Sessão
            DataTable dtClientes = new Cliente().Selecionar(Convert.ToInt64(pCliente), int.MinValue, string.Empty, string.Empty);

            //Preenche os dados do usuário logado...
            if (dtClientes.Rows.Count > 0)
            {
                //Alimenta o Array com as Informações
                lstReturn.Add(dtClientes.Rows[0]["CODIGO"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["NOME"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["RESPONSAVEL"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["EMAIL"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["TELEFONE"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["ENDERECO"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["CIDADE"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["UF"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["CEP"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["TIPO_PESSOA"].ToString());
                lstReturn.Add(dtClientes.Rows[0]["TIPO_PESSOA"].ToString().Equals("J") ? dtClientes.Rows[0]["CNPJ"].ToString() : dtClientes.Rows[0]["CPF"].ToString());
            }

            return lstReturn;
        }

        private List<string> CarregarListaUsers()
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega os dados do usuário através do código na Sessão
                DataTable dtUsers = new Representante().Selecionar(long.MinValue);

                //Declara string que irá gerar a grid
                StringBuilder strGridUsers = new StringBuilder();

                if (dtUsers.Rows.Count > 0)
                {
                    //Lista os clientes do usuário logado...
                    foreach (DataRow dr in dtUsers.Rows)
                    { 
                        strGridUsers.Append("<div class='row'>"
                               + "  <div class='col-12M menu'> "
                               + "      <ul><li><a href=\"javascript:void();\" onclick=\"EditarDadosUsers('divGridUsersEdit','" + dr["CODIGO"].ToString() + "');\">" + dr["NOME"].ToString() + "</a></li></ul> "
                               + "  </div> "
                               + "  <div class='col-6B menu'> "
                               + "      <ul><li><a href=\"javascript:void();\" onclick=\"EditarDadosUsers('divGridUsersEdit','" + dr["CODIGO"].ToString() + "');\">" + dr["NOME"].ToString() + "</a></li></ul> "
                               + "  </div> "
                               + "  <div class='col-3B menu'> "
                               + "      <ul><li><a href=\"javascript:void();\" onclick=\"EditarDadosUsers('divGridUsersEdit','" + dr["CODIGO"].ToString() + "');\">" + dr["PERFIL"].ToString() + "</a></li></ul> "
                               + "  </div> "
                               + "  <div class='col-3B menu'> "
                               + "      <ul><li><a href=\"javascript:void();\" onclick=\"ResetSenha('" + dr["CODIGO"].ToString() + "','" + dr["NOME"].ToString() + "');\"><span class='icon fa-key'></span></a></li></ul> "
                               + "  </div> "
                               + " </div> ");
                    }

                    lstReturn.Add(strGridUsers.ToString());
                }
                else
                {
                    lstReturn.Add("Não foram encontrados usuários cadastrados.");
                }
            }
            catch
            {
                lstReturn.Add("Erro ao listar usuários!");
            }

            return lstReturn;
        }

        private List<string> CarregarDadosUsers(string pUsers)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Pega os dados do usuário através do código na Sessão
            DataTable dtUsers = new Representante().Selecionar(Convert.ToInt64(pUsers));

            //Preenche os dados do usuário logado...
            if (dtUsers.Rows.Count > 0)
            {
                //Alimenta o Array com as Informações
                lstReturn.Add(dtUsers.Rows[0]["CODIGO"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["NOME"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["EMAIL"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["TELEFONE"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["PESSOA"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["PESSOA"].ToString().Equals("J") ? dtUsers.Rows[0]["CNPJ"].ToString() : dtUsers.Rows[0]["CPF"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["PERFIL"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["ATIVO"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["ENDERECO"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["CIDADE"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["UF"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["PER_LICENCA"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["PER_DISPOSITIVO"].ToString());
                lstReturn.Add(dtUsers.Rows[0]["DTA_CRIACAO"].ToString());
            }

            return lstReturn;
        }
        
        private List<string> CarregarDadosClienteLicenca(string pClienteLicenca)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Pega os dados do usuário através do código na Sessão
            DataTable dtClientesLicenca = new ClienteLicenca().Selecionar(Convert.ToInt64(pClienteLicenca), long.MinValue, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            //Preenche os dados do registro logado...
            if (dtClientesLicenca.Rows.Count > 0)
            {
                //Calcula o valor total da comissão
                decimal _VlrTotalComissaoLicenca = string.IsNullOrEmpty(dtClientesLicenca.Rows[0]["VLR_COMISSAO_LICENCA"].ToString()) ? 0 : Convert.ToDecimal(dtClientesLicenca.Rows[0]["VLR_COMISSAO_LICENCA"].ToString());
                decimal _VlrTotalComissaoDispositivo = string.IsNullOrEmpty(dtClientesLicenca.Rows[0]["VLR_COMISSAO_DISPOSITIVO"].ToString()) ? 0 : Convert.ToDecimal(dtClientesLicenca.Rows[0]["VLR_COMISSAO_DISPOSITIVO"].ToString());

                //Alimenta o Array com as Informações
                lstReturn.Add(dtClientesLicenca.Rows[0]["CLIENTE"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["VIGENCIA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["QTDE_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["CHAVE_LICENCA"].ToString());
                lstReturn.Add(DateTime.Parse(dtClientesLicenca.Rows[0]["DTA_VIGENCIA_INICIO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy"));
                lstReturn.Add(DateTime.Parse(dtClientesLicenca.Rows[0]["DTA_VIGENCIA_TERMINO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy"));
                lstReturn.Add(dtClientesLicenca.Rows[0]["QTDE_SUP_MESA_7"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["QTDE_SUP_MESA_10"].ToString());
                lstReturn.Add(Convert.ToDecimal(dtClientesLicenca.Rows[0]["VLR_TOTAL"]).ToString("C2"));
                lstReturn.Add(dtClientesLicenca.Rows[0]["OBS_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["SIT_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["SIT_PAGAMENTO"].ToString());
                lstReturn.Add(string.IsNullOrEmpty(dtClientesLicenca.Rows[0]["DTA_PAGAMENTO"].ToString()) ? "" : DateTime.Parse(dtClientesLicenca.Rows[0]["DTA_PAGAMENTO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy"));
                lstReturn.Add(dtClientesLicenca.Rows[0]["VLR_TOTAL_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["VLR_TOTAL_DISPOSITIVO"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["NOME_CLIENTE"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["NOME_REPRESENTANTE"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["PER_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["PER_DISPOSITIVO"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["VLR_COMISSAO_LICENCA"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["VLR_COMISSAO_DISPOSITIVO"].ToString());
                lstReturn.Add(dtClientesLicenca.Rows[0]["SIT_COMISSAO_PAGTO"].ToString());
                lstReturn.Add(string.IsNullOrEmpty(dtClientesLicenca.Rows[0]["DTA_COMISSAO_PAGTO"].ToString()) ? "" : DateTime.Parse(dtClientesLicenca.Rows[0]["DTA_COMISSAO_PAGTO"].ToString(), CultureInfo.CurrentCulture).ToString("dd/MM/yy"));
                lstReturn.Add(Convert.ToString(_VlrTotalComissaoLicenca + _VlrTotalComissaoDispositivo));
                lstReturn.Add(dtClientesLicenca.Rows[0]["CODIGO"].ToString());
            }

            return lstReturn;
        }

        private List<string> SalvarRepresentante(string pID, string pNome, string pEmail, string pTelefone, string pEndereco, string pCidade, string pUF, string pPessoa, string pDoc, string pAtivo, string pPerfil, string pPerLicenca, string pPerDispositivo)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Aplica a regra de qual documento deve ser preenchido
            string pCPF = pPessoa.Equals("F") ? pDoc : string.Empty;
            string pCNPJ = string.IsNullOrEmpty(pCPF) ? pDoc : string.Empty;

            try
            {
                if (string.IsNullOrEmpty(pID))
                {
                    //Gera a Senha
                    string pSenha = new Funcoes().alfanumericoAleatorio(6);

                    new Representante().Incluir(pNome, pEmail, pTelefone, pEndereco, pCidade, pUF, FormsAuthentication.HashPasswordForStoringInConfigFile(pSenha, "MD5"), Convert.ToChar(pPessoa), pCPF, pCNPJ, Convert.ToChar(pAtivo), pPerfil, Convert.ToDecimal(pPerLicenca), (string.IsNullOrEmpty(pPerDispositivo)? 0 : Convert.ToDecimal(pPerDispositivo)));
                    lstReturn.Add("Dados do usuário incluído com sucesso.<br>Nova Senha: <b>" + pSenha + "</b>");
                }
                else
                {
                    new Representante().Alterar(Convert.ToInt64(pID), pNome, pTelefone, pEndereco, pCidade, pUF, Convert.ToChar(pPessoa), pCPF, pCNPJ, Convert.ToChar(pAtivo), pPerfil, Convert.ToDecimal(pPerLicenca), (string.IsNullOrEmpty(pPerDispositivo) ? 0 : Convert.ToDecimal(pPerDispositivo)));
                    lstReturn.Add("Dados do usuário alterado com sucesso.");
                }
            }
            catch
            {
                lstReturn.Add("Erro ao salvar dados do usuário!");
            }

            return lstReturn;
        }

        private List<string> CarregarComboCliente(string pRepresentante)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega os dados do cliente
                DataTable dtClientes = new Cliente().Selecionar(long.MinValue, (string.IsNullOrEmpty(pRepresentante) ? int.MinValue : Convert.ToInt32(pRepresentante)), string.Empty, string.Empty);

                //Declara string que irá gerar a grid
                StringBuilder strClientePorUser = new StringBuilder();
                StringBuilder strStatusPorUser = new StringBuilder();
                StringBuilder strExtratoPorUser = new StringBuilder();
                StringBuilder strGridOption = new StringBuilder();

                if (dtClientes.Rows.Count > 0)
                {
                    strClientePorUser.Append("<select id='lstLicClientePorUser' style='color: #e53c19;'>");
                    strClientePorUser.Append("<option value='' selected='selected'>Todos Clientes</option>");
                    strStatusPorUser.Append("<select id='lstPesquisaStatusPorUser' style='color: #e53c19;'>");
                    strStatusPorUser.Append("<option value='' selected='selected'>Todos Clientes</option>");
                    strExtratoPorUser.Append("<select id='lstExtratoPorUser' style='color: #e53c19;'>");
                    strExtratoPorUser.Append("<option value='' selected='selected'>Todos Clientes</option>");

                    //Lista os clientes do usuário logado...
                    foreach (DataRow dr in dtClientes.Rows)
                        strGridOption.Append("<option value='" + dr["CODIGO"].ToString() + "'>" + dr["NOME"].ToString() + "</option>");

                    strClientePorUser.Append(strGridOption.ToString());
                    strStatusPorUser.Append(strGridOption.ToString());
                    strExtratoPorUser.Append(strGridOption.ToString());

                    strClientePorUser.Append("</select>");
                    strStatusPorUser.Append("</select>");
                    strExtratoPorUser.Append("</select>");

                    lstReturn.Add(strClientePorUser.ToString());
                    lstReturn.Add(strStatusPorUser.ToString());
                    lstReturn.Add(strExtratoPorUser.ToString());
                }
                else
                {
                    lstReturn.Add("<select id='lstLicClientePorUser' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                    lstReturn.Add("<select id='lstPesquisaStatusPorUser' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                    lstReturn.Add("<select id='lstExtratoPorUser' style='color: #e53c19;'><option value=''>Erro ao listar clientes!</option></select>");
                }
            }
            catch
            {
                lstReturn.Add("<select id='lstLicClientePorUser' style='color: #e53c19;'><option value=''>Erro ao listar clientes!</option></select>");
                lstReturn.Add("<select id='lstPesquisaStatusPorUser' style='color: #e53c19;'><option value=''>Erro ao listar clientes!</option></select>");
                lstReturn.Add("<select id='lstExtratoPorUser' style='color: #e53c19;'><option value=''>Erro ao listar clientes!</option></select>");
            }

            return lstReturn;
        }

        private List<string> CarregarComboClientePorUser(string pRepresentante)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega os dados do cliente
                DataTable dtClientes = new Cliente().Selecionar(long.MinValue, Convert.ToInt32(pRepresentante), string.Empty, string.Empty);

                //Declara string que irá gerar a grid
                StringBuilder strClienteLicenca = new StringBuilder();

                if (dtClientes.Rows.Count > 0)
                {
                    strClienteLicenca.Append("<select id='lstLicCliente' style='color: #e53c19;'>");

                    //Lista os clientes do usuário logado...
                    foreach (DataRow dr in dtClientes.Rows)
                        strClienteLicenca.Append("<option value='" + dr["CODIGO"].ToString() + "'>" + dr["NOME"].ToString() + "</option>");

                    strClienteLicenca.Append("</select>");

                    lstReturn.Add(strClienteLicenca.ToString());
                }
                else
                {
                    lstReturn.Add("<select id='lstLicCliente' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                }
            }
            catch
            {
                lstReturn.Add("<select id='lstLicCliente' style='color: #e53c19;'><option value=''>Erro ao listar clientes!</option></select>");
            }

            return lstReturn;
        }

        private List<string> CarregarComboUsers(string pUserLogado, string pNomeUserLogado, string pPerfil)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            try
            {
                //Pega todos Representantes
                DataTable dtUsers = new Representante().Selecionar(long.MinValue);

                //Declara string que irá gerar o combo
                StringBuilder strUsers = new StringBuilder();
                StringBuilder strRepre = new StringBuilder();
                StringBuilder strRepreExt = new StringBuilder();
                StringBuilder strOption = new StringBuilder();

                if (dtUsers.Rows.Count > 0)
                {
                    strUsers.Append("<select id='lstStatusRepresentante' style='color: #e53c19;'>");
                    strUsers.Append("<option value='' selected='selected'>Todos Representantes</option>");
                    strRepre.Append("<select id='lstPesqCliRepresentante' style='color: #e53c19;'>");
                    strRepreExt.Append("<select id='lstPesqExtRepresentante' style='color: #e53c19;'>");

                    //Lista os usuários...
                    foreach (DataRow dr in dtUsers.Rows)
                        strOption.Append("<option value='" + dr["CODIGO"].ToString() + "'>" + dr["NOME"].ToString() + "</option>");

                    strUsers.Append(strOption.ToString());
                    strUsers.Append("</select>");

                    if (pPerfil.Equals("Administrador"))
                    {
                        strRepre.Append("<option value='' selected='selected'>Todos Representantes</option>");
                        strRepre.Append(strOption.ToString());

                        strRepreExt.Append("<option value='' selected='selected'>Todos Representantes</option>");
                        strRepreExt.Append(strOption.ToString());
                    }
                    else
                    {
                        strRepre.Append("<option value='" + pUserLogado + "'>" + pNomeUserLogado + "</option>");
                        strRepreExt.Append("<option value='" + pUserLogado + "'>" + pNomeUserLogado + "</option>");
                    }

                    strRepre.Append("</select>");
                    strRepreExt.Append("</select>");

                    lstReturn.Add(strUsers.ToString());
                    lstReturn.Add(strRepre.ToString());
                    lstReturn.Add(strRepreExt.ToString());
                }
                else
                {
                    lstReturn.Add("<select id='lstStatusRepresentante' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                    lstReturn.Add("<select id='lstPesqCliRepresentante' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                    lstReturn.Add("<select id='lstPesqExtRepresentante' style='color: #e53c19;'><option value=''>Não existe cliente cadastrado</option></select>");
                }
            }
            catch
            {
                lstReturn.Add("<select id='lstStatusRepresentante' style='color: #e53c19;'><option value=''>Erro ao listar representantes!</option></select>");
                lstReturn.Add("<select id='lstPesqCliRepresentante' style='color: #e53c19;'><option value=''>Erro ao listar representantes!</option></select>");
                lstReturn.Add("<select id='lstPesqExtRepresentante' style='color: #e53c19;'><option value=''>Erro ao listar representantes!</option></select>");
            }

            return lstReturn;
        }

        private List<string> SalvarClienteLicenca(string pCliente, string pVigInicio, string pVigTermino, string pVigencia, string pQtdeLicenca, string pQtdeTablet7, string pQtdeSupMesa7, string pQtdeTablet10, string pQtdeSupMesa10, string pQtdeSupChao, string pVlrTrimestral, string pVlrSemestral, string pVlrAnual, string pVlrTablet7, string pVlrSupMesa7, string pVlrTablet10, string pVlrSupMesa10, string pVlrSupChao, string pVlrTotal, string pPerLicenca, string pPerDispositivo, string pUser, string pVlrLicenca, string pVlrDispositivo, string pObsLicenca)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            string pChaveLicenca = new Funcoes().alfanumericoAleatorio(20).ToUpper();
            pChaveLicenca = (pChaveLicenca.Substring(4, 4) + DateTime.Now.Second.ToString().PadLeft(2, '0') + pChaveLicenca.Substring(10, 2) + DateTime.Now.Millisecond.ToString().PadLeft(2, '0') + new Funcoes().alfanumericoAleatorio(15).ToUpper() + pChaveLicenca.Substring(13, 5));

            try
            {
                //Calcula Comissão dos Representantes
                decimal pVlrLic = Convert.ToDecimal(pVlrLicenca.Replace('.', ',')) * (Convert.ToDecimal(pPerLicenca) / 100);
                decimal pVlrDisp = Convert.ToDecimal(pVlrDispositivo.Replace('.', ',')) * (Convert.ToDecimal(pPerDispositivo) / 100);

                new ClienteLicenca().Incluir(Convert.ToInt64(pCliente), pChaveLicenca, Convert.ToDateTime(pVigInicio), Convert.ToDateTime(pVigTermino), Convert.ToChar(pVigencia), Convert.ToInt32(pQtdeLicenca), Convert.ToInt32(pQtdeTablet7), Convert.ToInt32(pQtdeSupMesa7), Convert.ToInt32(pQtdeTablet10), Convert.ToInt32(pQtdeSupMesa10), Convert.ToInt32(pQtdeSupChao), Convert.ToDecimal(pVlrTrimestral), Convert.ToDecimal(pVlrSemestral), Convert.ToDecimal(pVlrAnual), Convert.ToDecimal(pVlrTablet7), Convert.ToDecimal(pVlrSupMesa7), Convert.ToDecimal(pVlrTablet10), Convert.ToDecimal(pVlrSupMesa10), Convert.ToDecimal(pVlrSupChao), Convert.ToDecimal(pVlrLicenca.Replace('.', ',')), Convert.ToDecimal(pVlrDispositivo.Replace('.', ',')), Convert.ToDecimal(pVlrTotal.Replace('.',',')), Convert.ToDecimal(pPerLicenca), (string.IsNullOrEmpty(pPerDispositivo) ? 0 : Convert.ToDecimal(pPerDispositivo)), pVlrLic, pVlrDisp, pObsLicenca.ToUpper());
                lstReturn.Add("Licença incluída com sucesso.");
            }
            catch (Exception ex)
            {
                lstReturn.Add(ex.Message + "Erro ao incluir clientes!");
            }

            return lstReturn;
        }

        private List<string> PesquisarListaClienteLicenca(string pCodigo, string pCliente, string pRepresentante, string pSitLicenca, string pSitPagto, string pForm)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Declara string que irá gerar a grid
            StringBuilder strGridCliente = new StringBuilder();

            //Valida qual formulário foi chamado a Pesquisa
            string pFuncaoJS = pForm.Equals("Status") ? "<a href=\"javascript:void();\" onclick=\"EditarDadosStatus('divGridStatusEdit','" : "<a href=\"javascript:void();\" onclick=\"EditarDadosClienteLicenca('divGridLicencaEdit','";

            try
            {
                //Pega os dados do usuário através do código na Sessão
                DataTable dtClientes = new ClienteLicenca().Selecionar((string.IsNullOrEmpty(pCodigo) ? long.MinValue : Convert.ToInt64(pCodigo)), (string.IsNullOrEmpty(pCliente) ? long.MinValue : Convert.ToInt64(pCliente)), pSitLicenca, pSitPagto, string.Empty, string.Empty, string.Empty);

                //Lista as licenças...
                foreach (DataRow dr in dtClientes.Rows)
                {
                    //Se usuário não for Admin, mostra somente os clientes dele
                    if (!string.IsNullOrEmpty(pRepresentante))
                        if (!pRepresentante.Equals(dr["CODIGO_REPRESENTANTE"].ToString()))
                            continue;

                    //Lista os clientes do usuário logado...
                    strGridCliente.Append("<div class='row'>"
                    + "  <div class='col-12M menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_CLIENTE"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-4B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_CLIENTE"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-4B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_REPRESENTANTE"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["SIT_LICENCA"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["SIT_PAGAMENTO"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + " </div> ");
                }

                //Verifica se não teve registro
                if (string.IsNullOrEmpty(strGridCliente.ToString()))
                {
                    strGridCliente.Append("<div class='row'>"
                       + "  <div class='col-12M menu'> "
                       + "      <ul><li>Não foram encontradas Licenças.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>Não foram encontradas Licenças.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + " </div> ");
                }

                lstReturn.Add(strGridCliente.ToString());
            }
            catch
            {
                strGridCliente.Append("<div class='row'>"
                   + "  <div class='col-12M menu'> "
                   + "      <ul><li>Erro ao listar licenças. Contate o Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>Erro ao listar licenças.</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>Contate o Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>&nbsp;</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>&nbsp;</li></ul> "
                   + "  </div> "
                   + " </div> ");

                lstReturn.Add(strGridCliente.ToString());
            }

            return lstReturn;
        }

        private List<string> SalvarStatus(string pID, string pSitLicenca, string pSitPagto, string pDtaPagto, string pSitPagtoComissao, string pDtaPagtoComissao, string pObsPagto, string pCodUser)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();
            
            try
            {
                //Pega a Data do Pagamento
                DateTime dtPagto = string.IsNullOrEmpty(pDtaPagto) ? DateTime.MinValue : Convert.ToDateTime(pDtaPagto);
                DateTime DtaPagtoComissao = string.IsNullOrEmpty(pDtaPagtoComissao) ? DateTime.MinValue : Convert.ToDateTime(pDtaPagtoComissao);

                //Trata a Observação do Pagamento se houver
                string vObsPagamento = string.IsNullOrEmpty(pObsPagto) ? string.Empty : "<br />Em: " + DateTime.Now.ToString() + " - " + pObsPagto.ToUpper();

                //Alterar registro ClienteLicenca
                new ClienteLicenca().Alterar(Convert.ToInt64(pID), pSitLicenca, pSitPagto, dtPagto, pSitPagtoComissao, DtaPagtoComissao, vObsPagamento, Convert.ToInt64(pCodUser));
                lstReturn.Add("Dados alterado com sucesso.");
            }
            catch
            {
                lstReturn.Add("Erro ao alterar dados. Verifique o formato da data de pagamento!");
            }

            return lstReturn;
        }

        private List<string> PesquisarCliente(string pRepresentante, string pNome, string pResponsavel)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Declara string que irá gerar a grid
            StringBuilder strGridCliente = new StringBuilder();

            //Valida qual formulário foi chamado a Pesquisa
            string pFuncaoJS = "<a href=\"javascript:void();\" onclick=\"EditarDadosCliente('divGridClienteEdit','";

            try
            {
                //Pega os dados do usuário através do código na Sessão
                DataTable dtClientes = new Cliente().Selecionar(long.MinValue, (string.IsNullOrEmpty(pRepresentante) ? int.MinValue : Convert.ToInt32(pRepresentante)), pNome, pResponsavel);

                if (dtClientes.Rows.Count > 0)
                {
                    //Lista as licenças...
                    foreach (DataRow dr in dtClientes.Rows)
                    {
                        //Lista os clientes do usuário logado...
                        strGridCliente.Append("<div class='row'>"
                       + "  <div class='col-12M menu'> "
                       + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME"].ToString() + "</a></li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME"].ToString() + "</a></li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["RESPONSAVEL"].ToString() + "</a></li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_REPRESENTANTE"].ToString() + "</a></li></ul> "
                       + "  </div> "
                       + " </div> ");
                    }

                    lstReturn.Add(strGridCliente.ToString());
                }
                else
                {
                    strGridCliente.Append("<div class='row'>"
                       + "  <div class='col-12M menu'> "
                       + "      <ul><li>Não foram encontradas Clientes.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>Não foram encontradas Clientes.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + " </div> ");

                    lstReturn.Add(strGridCliente.ToString());
                }
            }
            catch
            {
                strGridCliente.Append("<div class='row'>"
                   + "  <div class='col-12M menu'> "
                   + "      <ul><li>Erro ao listar Clientes. Contate o Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>Erro ao listar Clientes.</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>Contate o Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>&nbsp;</li></ul> "
                   + "  </div> "
                   + " </div> ");

                lstReturn.Add(strGridCliente.ToString());
            }

            return lstReturn;
        }

        private List<string> PesquisarListaExtrato(string pCliente, string pSitPagtoLicenca, string pSitPagtoComissao, string pVigencia, string pSitLicenca, string pRepresentante)
        {
            //Declara array de retorno
            List<string> lstReturn = new List<string>();

            //Declara string que irá gerar a grid
            StringBuilder strGridCliente = new StringBuilder();

            //Valida qual formulário foi chamado a Pesquisa
            string pFuncaoJS = "<a href=\"javascript:void();\" onclick=\"EditarDadosExtrato('divGridExtratoEdit','";

            try
            {
                decimal pVlrComLic = 0;
                decimal pVlrComDisp = 0;
                decimal pVlrComTotal = 0;

                //Pega os dados do usuário através do código na Sessão
                DataTable dtClientes = new ClienteLicenca().Selecionar(long.MinValue, (string.IsNullOrEmpty(pCliente) ? long.MinValue : Convert.ToInt64(pCliente)), pSitLicenca, pSitPagtoLicenca, pSitPagtoComissao, pVigencia, string.Empty);

                //Lista as licenças...
                foreach (DataRow dr in dtClientes.Rows)
                {
                    //Se usuário não for Admin, mostra somente os clientes dele
                    if (!string.IsNullOrEmpty(pRepresentante))
                        if (!pRepresentante.Equals(dr["CODIGO_REPRESENTANTE"].ToString()))
                            continue;

                    pVlrComLic = Convert.ToDecimal(dr["VLR_COMISSAO_LICENCA"].ToString());
                    pVlrComDisp = Convert.ToDecimal(dr["VLR_COMISSAO_DISPOSITIVO"].ToString());
                    pVlrComTotal = pVlrComLic + pVlrComDisp;

                    //Lista os clientes do usuário logado...
                    strGridCliente.Append("<div class='row'>"
                    + "  <div class='col-12M menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_CLIENTE"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-4B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["NOME_CLIENTE"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">R$ " + pVlrComLic.ToString("N2") + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">R$ " + pVlrComDisp.ToString("N2") + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">R$ " + pVlrComTotal.ToString("N2") + "</a></li></ul> "
                    + "  </div> "
                    + "  <div class='col-2B menu'> "
                    + "      <ul><li>" + pFuncaoJS + dr["CODIGO"].ToString() + "');\">" + dr["SIT_COMISSAO_PAGTO"].ToString() + "</a></li></ul> "
                    + "  </div> "
                    + " </div> ");
                }

                //Verifica se não teve registro
                if (string.IsNullOrEmpty(strGridCliente.ToString()))
                {
                    strGridCliente.Append("<div class='row'>"
                       + "  <div class='col-12M menu'> "
                       + "      <ul><li>Não foram encontradas Licenças.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-4B menu'> "
                       + "      <ul><li>Não foram encontradas Licenças.</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + "  <div class='col-2B menu'> "
                       + "      <ul><li>&nbsp;</li></ul> "
                       + "  </div> "
                       + " </div> ");
                }

                lstReturn.Add(strGridCliente.ToString());

            }
            catch
            {
                strGridCliente.Append("<div class='row'>"
                   + "  <div class='col-12M menu'> "
                   + "      <ul><li>Erro ao listar licenças. Contate o Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-4B menu'> "
                   + "      <ul><li>Erro ao listar licenças.</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>Contate o</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>Administrador!</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>&nbsp;</li></ul> "
                   + "  </div> "
                   + "  <div class='col-2B menu'> "
                   + "      <ul><li>&nbsp;</li></ul> "
                   + "  </div> "
                   + " </div> ");

                lstReturn.Add(strGridCliente.ToString());
            }

            return lstReturn;
        }

        #endregion

        #region WServices

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarDadosUser(string pID)
        {
            return new Start().CarregarDadosRepresentante(pID);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSAlterarSenha(string pID, string pSenha)
        {
            return new Start().AlterarSenha(pID, pSenha);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarVlrLicenca()
        {
            return new Start().CarregarVlrLicenca();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSAlterarValorLicenca(string pVlrTrimestral, string pVlrSemestral, string pVlrAnual, string pVlrTablet7, string pVlrSupMesa7, string pVlrTablet10, string pVlrSupMesa10, string pVlrChao, string pRepresentante)
        {
            return new Start().AlterarValorLicenca(pVlrTrimestral, pVlrSemestral, pVlrAnual, pVlrTablet7, pVlrSupMesa7, pVlrTablet10, pVlrSupMesa10, pVlrChao, pRepresentante);
        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static List<string> WSCarregarListaCliente(string pPerfil, string pUser)
        //{
        //    return new Start().CarregarListaCliente(pPerfil, pUser);
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSSalvarCliente(string pID, string pNome, string pResponsavel, string pEmail, string pTelefone, string pEndereco, string pCidade, string pUF, string pCEP, string pPessoa, string pDoc, string pCodUser)
        {
            return new Start().SalvarCliente(pID, pNome, pResponsavel, pEmail, pTelefone, pEndereco, pCidade, pUF, pCEP, pPessoa, pDoc, pCodUser);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarDadosCliente(string pCliente)
        {
            return new Start().CarregarDadosCliente(pCliente);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarListaUsers()
        {
            return new Start().CarregarListaUsers();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarDadosUsers(string pUsers)
        {
            return new Start().CarregarDadosUsers(pUsers);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSSalvarRepresentante(string pID, string pNome, string pEmail, string pTelefone, string pEndereco, string pCidade, string pUF, string pPessoa, string pDoc, string pAtivo, string pPerfil, string pPerLicenca, string pPerDispositivo)
        {
            return new Start().SalvarRepresentante(pID, pNome, pEmail, pTelefone, pEndereco, pCidade, pUF, pPessoa, pDoc, pAtivo, pPerfil, pPerLicenca, pPerDispositivo);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSResetarSenha(string pID)
        {
            return new Start().ResetarSenha(pID);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarComboCliente(string pID)
        {
            return new Start().CarregarComboCliente(pID);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarComboClientePorUser(string pID)
        {
            return new Start().CarregarComboClientePorUser(pID);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarComboUsers(string pUserLogado, string pNomeUserLogado, string pPerfil)
        {
            return new Start().CarregarComboUsers(pUserLogado, pNomeUserLogado, pPerfil);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSSalvarClienteLicenca(string pCliente, string pVigInicio, string pVigTermino, string pVigencia, string pQtdeLicenca, string pQtdeTablet7, string pQtdeSupMesa7, string pQtdeTablet10, string pQtdeSupMesa10, string pQtdeSupChao, string pVlrTrimestral, string pVlrSemestral, string pVlrAnual, string pVlrTablet7, string pVlrSupMesa7, string pVlrTablet10, string pVlrSupMesa10, string pVlrSupChao, string pVlrTotal, string pPerLicenca, string pPerDispositivo, string pUser, string pVlrLicenca, string pVlrDispostivo, string pObsLicenca)
        {
            return new Start().SalvarClienteLicenca(pCliente, pVigInicio, pVigTermino, pVigencia, pQtdeLicenca, (string.IsNullOrEmpty(pQtdeTablet7) ? "0" : pQtdeTablet7), (string.IsNullOrEmpty(pQtdeSupMesa7) ? "0" : pQtdeSupMesa7), (string.IsNullOrEmpty(pQtdeTablet10) ? "0" : pQtdeTablet10), (string.IsNullOrEmpty(pQtdeSupMesa10) ? "0" : pQtdeSupMesa10), (string.IsNullOrEmpty(pQtdeSupChao) ? "0" : pQtdeSupChao), pVlrTrimestral, pVlrSemestral, pVlrAnual, pVlrTablet7, pVlrSupMesa7, pVlrTablet10, pVlrSupMesa10,  pVlrSupChao, pVlrTotal, pPerLicenca, pPerDispositivo, pUser, pVlrLicenca, pVlrDispostivo, pObsLicenca);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSPesquisarListaClienteLicenca(string pID, string pCliente, string pUser, string pSitLicenca, string pSitPagto, string pForm)
        {
            return new Start().PesquisarListaClienteLicenca(pID, pCliente, pUser, pSitLicenca, pSitPagto, pForm);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSPesquisarListaExtrato(string pCliente, string pSitPagtoLicenca, string pSitPagtoComissao, string pVigencia, string pSitLicenca, string pUser)
        {
            return new Start().PesquisarListaExtrato(pCliente, pSitPagtoLicenca, pSitPagtoComissao, pVigencia, pSitLicenca, pUser);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSCarregarDadosClienteLicenca(string pClienteLicenca)
        {
            return new Start().CarregarDadosClienteLicenca(pClienteLicenca);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSSalvarStatus(string pID, string pSitLicenca, string pSitPagto, string pDtaPagto, string pSitPagtoComissao, string pDtaPagtoComissao, string pObsPagto, string pCodUser)
        {
            return new Start().SalvarStatus(pID, pSitLicenca, pSitPagto, pDtaPagto, pSitPagtoComissao, pDtaPagtoComissao, pObsPagto, pCodUser);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> WSPesquisarCliente(string pRepresentante, string pNome, string pResponsavel)
        {
            return new Start().PesquisarCliente(pRepresentante, pNome, pResponsavel);
        }
        #endregion
    }
}
