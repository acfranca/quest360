<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="QuestRep.WebApplication.Aplicacao.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
		<title>Quest360 | Acesso Representante</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />

        <link rel="icon" href="images/favicon.ico">

		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
        <link rel="stylesheet" href="assets/css/grid.css" />
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
		<!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->

    </head>
    <body style="background-color: #f5fafa;">
        <!-- Header -->
		<div id="header">
			<div class="top">

                <form id="frmTop" runat="server">

				    <!-- Dados Usuário Logado -->
				    <div id="logo">
					    <span class="image avatar48"><img src="images/avatar.jpg" alt="" /></span>
					    <h1 id="title"><asp:Label ID="lblName" runat="server" Text="" style="font-size: 0.80em;"></asp:Label></h1>
					    <p><asp:Label ID="lblPerfil" runat="server" Text=""></asp:Label></p>
                        <asp:TextBox ID="hdTxtCodUser" runat="server" disabled="false" style="display: none;"></asp:TextBox>
                        <asp:TextBox ID="hdTxtNmUser" runat="server" disabled="false" style="display: none;"></asp:TextBox>
                        <asp:TextBox ID="hdTxtPfUser" runat="server" disabled="false" style="display: none;"></asp:TextBox>
				    </div>

				    <!-- Menu -->
				    <nav id="nav">
					    <ul>
						    <li><a href="javascript:void();" onclick="javascript:ControlSecao('scClient');" id="hpCliente" class="skel-layers-ignoreHref"><span class="icon fa-th">Gerenciar Clientes</span></a></li>
                            <li><a href="javascript:void();" onclick="javascript:ControlSecao('scLicenca');" id="hpLicenca" class="skel-layers-ignoreHref"><span class="icon fa-key">Gerenciar Licença</span></a></li>
                            <li><a href="javascript:void();" onclick="javascript:ControlSecao('scExtrato');" id="hpExtratos" class="skel-layers-ignoreHref"><span class="icon fa-wpforms">Meus Extratos</span></a></li>
						    <li><a href="javascript:void();" onclick="javascript:ControlSecao('scUser');" id="hpUser" class="skel-layers-ignoreHref"><span class="icon fa-user">Meus Dados</span></a></li>
                            <li><a href="javascript:void();" onclick="javascript:ControlSecao('scStatus');" id="hpStatus" class="skel-layers-ignoreHref" style="display: none;"><span class="icon fa-usd">Gerenciar Pagamento</span></a></li>
                            <li><a href="javascript:void();" onclick="javascript:ControlSecao('scConfigLic');" id="hpConfigLic" class="skel-layers-ignoreHref" style="display: none;"><span class="icon fa-cogs">Configurar Licença</span></a></li>
                            <li><a href="javascript:void();" onclick="javascript:ControlSecao('scConfigUser');" id="hpConfigUser" class="skel-layers-ignoreHref" style="display: none;"><span class="icon fa-users">Configurar Usuários</span></a></li>
						    <li><asp:LinkButton ID="hpSair" runat="server" Text="<span class='icon fa-power-off'>Sair</span>" class="skel-layers-ignoreHref" onclick="hpSair_Click"></asp:LinkButton></li>
					    </ul>
				    </nav>

                </form>

			</div>
		</div>

		<!-- Main -->
		<div id="main">

			<!-- Bem-vindo -->
			<section id="scBemVindo" class="two">
				<div class="container">

					<header>
                        <div class="row">
							<div class="12u$">
						    <h2>Bem-Vindo a</h2>
							</div><br /><br />
                            <div class="12u$">
                                <h2>Área Restrita do Quest360</h2>
                            </div>
                        </div>
					</header>
                </div>
            </section>

			<!-- Clientes -->
			<section id="scClient" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Gerenciar Clientes</h2>
					</header>
                    <div id="divGridClienteList">
                        <form method="post">

                            <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <input type="text" id="txtPesqCliNome" style="color: #e53c19;" placeholder="Entre com o Nome do Cliente"/>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Responsável:</div>
                                    <input type="text" id="txtPesqCliResponsavel" style="color: #e53c19;" placeholder="Entre com o Nome do Responsável"/>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <div id="lstDivPesqCliRepresentante" style="color: red;"></div>
                                    <p class="pBotao"><a href="javascript:void();" onclick="PesquisarCliente();"><span class="icon fa-search">&nbsp;&nbsp;Pequisar</span></a></p>
							    </div>
                            </div>
                        </form>
                        <div class="row">
                            <div class="col-12M menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>
                            <div class="col-4B menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>
                            <div class="col-4B menu">
                                <ul><ol>RESPONSÁVEL</ol></ul>
                            </div>
                            <div class="col-4B menu">
                                <ul><ol>REPRESENTANTE</ol></ul>
                            </div>
                        </div>

                        <div id="divListaCliente" style="color: red;"></div>
                        <br />
                        <a href="javascript:void();" class="button" onclick="MostrarDetalheCliente('divGridClienteEdit');">&nbsp;&nbsp;Novo Cliente&nbsp;&nbsp;</a>

                    </div>

                    <div id="divGridClienteEdit" style="display: none;">

                        <form method="post" action="javascript:SalvarCliente();">

                            <input type="text" id="txtCodCliente" disabled="disabled" style="display: none;" />
						    <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Nome:</div>
                                    <input type="text" id="txtCliNome" style="color: #e53c19;" placeholder="Entre com o Nome do Cliente"/>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Responsável:</div>
                                    <input type="text" id="txtCliResp" style="color: #e53c19;" placeholder="Entre com o Nome do Responsável"/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">E-mail:</div>
                                    <input type="text" id="txtCliEmail" style="color: #e53c19;" placeholder="Entre com o E-mail"/>
                                </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Telefone:</div>
                                    <input type="text" id="txtCliTel" style="color: #e53c19;" placeholder="Entre com o Telefone"/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Endereço:</div>
                                    <input type="text" id="txtCliEnd" style="color: #e53c19;" placeholder="Entre com o Endereço"/>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cidade:</div>
                                    <input type="text" id="txtCliCid" style="color: #e53c19;" placeholder="Entre com a Cidade"/>
                                </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Estado:</div>
                                    <select id="lstCliUF" style="color: #e53c19;">
                                        <option value="SP" selected="selected">São Paulo</option>
                                        <option value="AC">Acre</option>
                                        <option value="AL">Alagoas</option>
                                        <option value="AP">Amapá</option>
                                        <option value="AM">Amazonas</option>
                                        <option value="BA">Bahia</option>
                                        <option value="CE">Ceará</option>
                                        <option value="DF">Distrito Federal</option>
                                        <option value="ES">Espírito Santo</option>
                                        <option value="GO">Goiás</option>
                                        <option value="MA">Maranhão</option>
                                        <option value="MT">Mato Grosso</option>
                                        <option value="MS">Mato Grosso do Sul</option>
                                        <option value="MG">Minas Gerais</option>
                                        <option value="PA">Pará</option>
                                        <option value="PB">Paraíba</option>
                                        <option value="PR">Paraná</option>
                                        <option value="PE">Pernambuco</option>
                                        <option value="PI">Piauí</option>
                                        <option value="RJ">Rio de Janeiro</option>
                                        <option value="RN">Rio Grande do Norte</option>
                                        <option value="RS">Rio Grande do Sul</option>
                                        <option value="RO">Rondônia</option>
                                        <option value="RR">Roraima</option>
                                        <option value="SC">Santa Catarina</option>
                                        <option value="SE">Sergipe</option>
                                        <option value="TO">Tocantins</option>
                                    </select>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CEP:</div>
                                    <input type="text" id="txtCliCEP" style="color: #e53c19;" placeholder="Entre com o CEP"/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pessoa:</div>
                                    <select id="lstCliPessoa" style="color: #e53c19;">
                                        <option value="J" selected="selected">Jurídica</option>
                                        <option value="F">Física</option>
                                    </select>
                                </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CPF/CNPJ:</div>
                                    <input type="text" id="txtCliDoc" style="color: #e53c19;" placeholder="Entre com CPF/CNPJ"/>
                                </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheCliente('divGridClienteList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;&nbsp;&nbsp;
                                    <input type="submit" value="&nbsp;&nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp;&nbsp;" />
                                    <br /><br /><div id="divMsgCliente" style="color: red;"></div>
							    </div>
                            </div>
                        </form>

                    </div>

				</div>
			</section>
            
			<!-- Licenças -->
			<section id="scLicenca" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Gerenciar Licença</h2>
					</header>

                    <div id="divGridLicencaList">
                        
                        <form method="post">
                            <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <div id="lstDivLicClientePorUser" style="color: red;"></div>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <select id="lstLicClienteSitLic" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="ATIVO">ATIVO</option>
                                        <option value="INATIVO">INATIVO</option>
                                        <option value="SOLICITADO">SOLICITADO</option>
                                        <option value="CANCELADO">CANCELADO</option>
                                    </select>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Pagto:</div>
                                    <select id="lstLicClienteSitPag" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="AGUARDANDO">AGUARDANDO</option>
                                        <option value="PAGO">PAGO</option>
                                    </select>
                                    <p class="pBotao"><a href="javascript:void();" onclick="PesquisarListaClienteLicenca();"><span class="icon fa-search">&nbsp;&nbsp;Pequisar</span></a></p>
							    </div>
                            </div>
                        </form>
                        <div class="row">
                            <div class="col-12M menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>

                            <div class="col-4B menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>
                            <div class="col-4B menu">
                                <ul><ol>REPRESENTANTE</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>LICENÇA</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>PAGTO.</ol></ul>
                            </div>
                        </div>

                        <div id="divListaClienteLicenca" style="color: red;"></div>
                        <br />
                        <a href="javascript:void();" class="button" onclick="MostrarDetalheClienteLicenca('divGridLicencaEdit', 'S');">&nbsp;&nbsp;Nova Licença&nbsp;&nbsp;</a>
                    </div>

                    <div id="divGridLicencaEdit" style="display: none;">
                        
                        <input type="text" id="hdTxtVlrLicenca" disabled="disabled" style="display: none;" value="0" />
                        <input type="text" id="hdTxtVlrDispositivo" disabled="disabled" style="display: none;" value="0" />

                        <form method="post" action="javascript:SalvarClienteLicenca();">

						    <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <div id="lstDivLicCliente" style="color: red;"></div>
                                    <input type="text" id="txtLicClienteOculto" style="color: #e53c19; display: none;" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência:</div>
                                    <select id="lstLicVigencia" onchange="CalculaVigencia();" style="color: #e53c19;">
                                        <option value="T" selected="selected">Trimestral</option>
                                        <option value="S">Semestral</option>
                                        <option value="A">Anual</option>
                                        <option value="C">Cortesia 30 Dias</option>
                                        <option value="D">Cortesia 60 Dias</option>
                                    </select>
                                </div>
                                <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;"><div id="divLstPrecoLicenca"></div></div>
                                    <input type="text" id="txtLicQtde" onkeyup="CalculaValorTotalLicenca();" maxlength="7" style="color: #e53c19;" placeholder="Entre com qtde. de licença."/>
							    </div>

							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Chave da Licença:</div>
                                    <input type="text" id="txtLicChave" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Início:</div>
                                    <input type="text" id="txtLicVigInicio" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Término:</div>
                                    <input type="text" id="txtLicVigTermino" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    

							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;"><div id="divLstPrecoSupMesa7"></div></div>
                                    <input type="text" id="txtLicQtdeSupMesa7" onkeyup="CalculaValorTotalLicenca();" maxlength="7" disabled="disabled" style="color: #e53c19;" placeholder="Entre com a qtde. suporte de mesa."/>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;"><div id="divLstPrecoSupMesa10"></div></div>
                                    <input type="text" id="txtLicQtdeSupMesa10" onkeyup="CalculaValorTotalLicenca();" maxlength="7" style="color: #e53c19;" placeholder="Entre com a qtde. suporte de mesa."/>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Total de Investimento:</div>
                                    <input type="text" id="txtLicTotal" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>

                                <div class="4u 12u$(mobile)" style="display:none;">&nbsp;</div>
							    <div class="4u 12u$(mobile)" style="display:none;">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;"><div id="divLstPrecoTablet7"></div></div>
                                    <input type="text" id="txtLicQtdeTablet7" onkeyup="CalculaValorTotalLicenca();" maxlength="7" disabled="disabled" style="background-color: #e0e0e0; color: #e53c19;" placeholder="Entre com a qtde. de tablet."/>
							    </div>
							    <div class="4u$ 12u$(mobile)" style="display:none;">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;"><div id="divLstPrecoTablet10"></div></div>
                                    <input type="text" id="txtLicQtdeTablet10" onkeyup="CalculaValorTotalLicenca();" maxlength="7" style="background-color: #e0e0e0; color: #e53c19;" placeholder="Entre com a qtde. de tablet."/>
							    </div>

                                <div class="12u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Observação:</div>
                                    <input type="text" id="txtLicObservacaoLicenca" maxlength="400" style="color: #e53c19;" placeholder="Entre com alguma observação se houver."/>
                                </div>

							    <div class="col-12 menu" id="divBotaoClienteLicenca" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheClienteLicenca('divGridLicencaList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;&nbsp;&nbsp;
                                    <input type="submit" value="&nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp;" />
							    </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <div id="divMsgClienteLicenca" style="color: red;"></div>
							    </div>
                            </div>

						    <div class="row" id="divStatusClienteLicenca" style="display: none;">
                                <div class="12u$ 12u$(mobile)">
                                    <h2>Status Licença</h2>
                                </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <input type="text" id="txtLicPagtoSitLicenca" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Pagamento:</div>
                                    <input type="text" id="txtLicPagtoSitPagto" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pago Em:</div>
                                    <input type="text" id="txtLicPagtoData" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheClienteLicenca('divGridLicencaList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>
							    </div>
                            </div>

                        </form>

                    </div>

				</div>
			</section>

            <!--Meus Extratos-->
			<section id="scExtrato" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Meus Extratos</h2>
					</header>

                    <div id="divGridExtratoList">
                        
                        <form method="post">
                            <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <div id="lstDivExtratoPorUser" style="color: red;"></div>
							    </div>
							    <div class="3u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pagto. Licença:</div>
                                    <select id="lstLicExtratoSitPag" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="AGUARDANDO">AGUARDANDO</option>
                                        <option value="PAGO">PAGO</option>
                                    </select>
							    </div>
							    <div class="3u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pagto. Comissão:</div>
                                    <select id="lstLicExtratoSitPagComissao" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="AGUARDANDO">AGUARDANDO</option>
                                        <option value="PAGO">PAGO</option>
                                    </select>
							    </div>
                                <div class="3u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência:</div>
                                    <select id="lstExtratoVigencia" onchange="CalculaVigencia();" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Vigências</option>
                                        <option value="T">Trimestral</option>
                                        <option value="S">Semestral</option>
                                        <option value="A">Anual</option>
                                        <option value="C">Cortesia - 30 Dias</option>
                                        <option value="D">Cortesia - 60 Dias</option>
                                    </select>
                                </div>
                                <div class="3u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <select id="lstLicExtratoSitLic" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="ATIVO">ATIVO</option>
                                        <option value="INATIVO">INATIVO</option>
                                        <option value="SOLICITADO">SOLICITADO</option>
                                        <option value="CANCELADO">CANCELADO</option>
                                    </select>
                                </div>
                                <div class="3u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <div id="lstDivPesqExtRepresentante" style="color: red;"></div>
                                </div>
    							<div class="3u$ 12u$(mobile)">
                                    <br /><a href="javascript:void();" onclick="PesquisarListaExtrato();"><span class="icon fa-search">&nbsp;&nbsp;Pequisar</span></a>
							    </div>
                            </div>
                        </form>
                        <br /><br />
                        <div class="row">
                            <div class="col-12M menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>

                            <div class="col-4B menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>LICENÇA</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>DISPOSITIVO</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>TOTAL</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>COMISSÃO</ol></ul>
                            </div>
                        </div>

                        <div id="divListaExtrato" style="color: red;"></div>
                    </div>

                    <div id="divGridExtratoEdit" style="display: none;">
                        
                        <form method="post">

						    <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Chave da Licença:</div>
                                    <input type="text" id="txtExtChave" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <input type="text" id="txtExtNome" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <input type="text" id="txtExtResp" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência:</div>
                                    <select id="lstExtVigencia" disabled="disabled">
                                        <option value="T" selected="selected">Trimestral</option>
                                        <option value="S">Semestral</option>
                                        <option value="A">Anual</option>
                                        <option value="C">Cortesia - 30 Dias</option>
                                        <option value="D">Cortesia - 60 Dias</option>
                                    </select>
                                </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Início:</div>
                                    <input type="text" id="txtExtVigInicio" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Término:</div>
                                    <input type="text" id="txtExtVigTermino" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <input type="text" id="txtExtPagtoSitLicenca" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Pagamento:</div>
                                    <input type="text" id="txtExtPagtoSitPagto" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pago Em:</div>
                                    <input type="text" id="txtExtPagtoData" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Licença:</div>
                                    <input type="text" id="txtExtVlrLicenca" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">% Comissão Licença:</div>
                                    <input type="text" id="txtExtPerComLicenca" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Comissão Licença:</div>
                                    <input type="text" id="txtExtVlrComLicenca" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Dispositivo:</div>
                                    <input type="text" id="txtExtVlrDisp" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">% Comissão Dispositivo:</div>
                                    <input type="text" id="txtExtPerComDisp" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Comissão Dispositivo:</div>
                                    <input type="text" id="txtExtVlrComDisp" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Comissão:</div>
                                    <input type="text" id="txtExtComSituacao" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pago Em:</div>
                                    <input type="text" id="txtExtComPagoEm" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Total Comissão:</div>
                                    <input type="text" id="txtExtComVlrTotal" disabled="disabled" />
							    </div>

							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheExtrato('divGridExtratoList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;&nbsp;&nbsp;
							    </div>
                            </div>
                        </form>

                    </div>

                </div>
            </section>

			<!-- Meus Dados -->
			<section id="scUser" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Meus Dados</h2>
					</header>

                    <form method="post" action="javascript:AlterarSenha();">

						<div class="row">
                            <div class="12u 12u$(mobile)"><hr /></div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Nome:</div>
                                <input type="text" id="txtUserNome" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">E-mail:</div>
                                <input type="text" id="txtUserEmail" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Perfil:</div>
                                <input type="text" id="txtUserPerfil" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CPF/CNPJ:</div>
                                <input type="text" id="txtUserDoc" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Percentual Licenca:</div>
                                <input type="text" id="txtUserPerc" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Percentual Dispositivo:</div>
                                <input type="text" id="txtUserPercDispositivo" style="background-color: #e0e0e0;" disabled="disabled" />
							</div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Senha:</div>
                                <input type="password" id="txtUserSenha" style="color: #e53c19;" placeholder="Entre com a nova senha"/>
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Confirme a Nova Senha:</div>
                                <input type="password" id="txtUserConfirma" style="color: #e53c19;" placeholder="Confirme a nova senha"/>
							</div>
							<div class="12u$">
                                <input type="submit" value="Alterar Senha" />
                                <br /><br /><div id="divMsgUser" style="color: red;"></div>
							</div>
						</div>

                    </form>

				</div>
			</section>

            <!--Gerenciar Pagto-->
			<section id="scStatus" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Gerenciar Pagamento</h2>
					</header>

                    <div id="divGridStatusList">
                        
                        <form method="post">
                            <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <div id="lstDivStatusClienteLicencaPorUser" style="color: red;"></div>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <select id="lstPesquisaStatusSitLic" style="color: #e53c19;">
                                        <option value="" selected="selected">Todas Situações</option>
                                        <option value="ATIVO">ATIVO</option>
                                        <option value="INATIVO">INATIVO</option>
                                        <option value="SOLICITADO">SOLICITADO</option>
                                        <option value="CANCELADO">CANCELADO</option>
                                    </select>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <div id="lstDivStatusUsers" style="color: red;"></div>
                                    <p class="pBotao"><a href="javascript:void();" onclick="PesquisarListaStatus();"><span class="icon fa-search">&nbsp;&nbsp;Pequisar</span></a></p>
							    </div>
                            </div>
                        </form>
                        <div class="row">
                            <div class="col-12M menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>

                            <div class="col-4B menu">
                                <ul><ol>CLIENTE</ol></ul>
                            </div>
                            <div class="col-4B menu">
                                <ul><ol>REPRESENTANTE</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>LICENÇA</ol></ul>
                            </div>
                            <div class="col-2B menu">
                                <ul><ol>PAGTO.</ol></ul>
                            </div>
                        </div>
                        <div id="divStatusListaClienteLicenca" style="color: red;"></div>
                    </div>

                    <div id="divGridStatusEdit" style="display: none;">

                        <form method="post" action="javascript:SalvarStatus();">
                            <input type="text" id="txtStatusCodClienteLicenca" disabled="disabled" style="display: none;" />
						    <div class="row">
                                <div class="12u 12u$(mobile)"><hr /></div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Chave da Licença:</div>
                                    <input type="text" id="txtStatusChave" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cliente:</div>
                                    <input type="text" id="txtStatusCliente" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <input type="text" id="txtStatusRepresentante" style="background-color: #e0e0e0;" disabled="disabled" />
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Licença:</div>
                                    <select id="lstStatusSitLic" style="color: #e53c19;">
                                        <option value="ATIVO" selected="selected">ATIVO</option>
                                        <option value="INATIVO">INATIVO</option>
                                        <option value="SOLICITADO">SOLICITADO</option>
                                        <option value="CANCELADO">CANCELADO</option>
                                    </select>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Pagto. Licença:</div>
                                    <select id="lstStatusSitPag" style="color: #e53c19;">
                                        <option value="AGUARDANDO" selected="selected">AGUARDANDO</option>
                                        <option value="PAGO">PAGO</option>
                                    </select>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pago Em:</div>
                                    <input type="text" id="txtStatusPagtoData" style="color: #e53c19;" placeholder="Entre a data de Pagto."/>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">&nbsp;</div>
                                </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação Pagto. Comissão:</div>
                                    <select id="lstStatusSitPagComissao" style="color: #e53c19;">
                                        <option value="AGUARDANDO" selected="selected">AGUARDANDO</option>
                                        <option value="PAGO">PAGO</option>
                                    </select>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pago Em:</div>
                                    <input type="text" id="txtStatusPagtoDataComissao" style="color: #e53c19;" placeholder="Entre a data de Pagto."/>
							    </div>
                                <div class="12u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Observação:</div>
                                    <input type="text" id="txtLicObservacaoPagto" maxlength="400" style="color: #e53c19;" placeholder="Entre com alguma observação se houver."/>
                                </div>
                                <div class="12u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Histórico Pagamento:</div>
                                    <div id="divObservacaoPagto" style="color: red; text-align: left;"></div>
                                </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheStatus('divGridStatusList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;&nbsp;&nbsp;
                                    <input type="submit" value="&nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp;" />
							    </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <div id="divMsgStatus" style="color: red;"></div>
							    </div>
                            </div>

                        </form>

                    </div>


                </div>
            </section>

			<!-- Configurar Licença -->
			<section id="scConfigLic" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Configurar Licença</h2>
					</header>

                    <form method="post" action="javascript:AlterarValorLicenca();">
						<div class="row">
                            <div class="12u 12u$(mobile)"><hr /></div>
                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor. Licença Trimestral:</div>
                                <input type="text" id="txtLicVlrLicenca3" style="color: #e53c19;" placeholder="Valor da Licença Obrigatório."/>
                            </div>
                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor. Licença Semestral:</div>
                                <input type="text" id="txtLicVlrLicenca6" style="color: #e53c19;" placeholder="Valor da Licença Obrigatório."/>
                            </div>
						    <div class="4u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor. Licença Anual:</div>
                                <input type="text" id="txtLicVlrLicenca12" style="color: #e53c19;" placeholder="Valor da Licença Obrigatório."/>
						    </div>

                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Mensal Aluguel do Tablet 7":</div>
                                <input type="text" id="txtLicVlrTablet7" style="color: #e53c19;" placeholder="Valor do Tablet 7' Obrigatório."/>
                            </div>
                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Mensal Aluguel do Tablet 10":</div>
                                <input type="text" id="txtLicVlrTablet10" style="color: #e53c19;" placeholder="Valor do Tablet 10' Obrigatório."/>
                            </div>
                            <div class="4u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Alterando Em:</div>
                                <input type="text" id="txtLicVlrAlteradoEm" style="background-color: #e0e0e0;" disabled="disabled" />
                            </div>

                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Suporte de Mesa 7":</div>
                                <input type="text" id="txtLicVlrSupMesa7" style="color: #e53c19;" placeholder="Valor do Suporte de Mesa Obrigatório."/>
                            </div>
                            <div class="4u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Valor Suporte de Mesa 10":</div>
                                <input type="text" id="txtLicVlrSupMesa10" style="color: #e53c19;" placeholder="Valor do Suporte de Mesa Obrigatório."/>
                            </div>
                            <div class="4u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Alterando Por:</div>
                                <input type="text" id="txtLicVlrAlteradoPor" style="background-color: #e0e0e0;" disabled="disabled" />
                            </div>

							<div class="12u$">
                                <input type="submit" value="Alterar Valores" />
                                <br /><br /><div id="divMsgVlrLicenca" style="color: red;"></div>
							</div>
                        </div>

                    </form>

				</div>
			</section>

			<!-- Configurar Usuários -->
			<section id="scConfigUser" class="two" style="display: none;">
				<div class="container">

					<header>
						<h2>Configurar Usuários</h2>
                        <br />
					</header>

                    <div id="divGridUsersList">

                        <div class="row">
                            <div class="col-12M menu">
                                <ul><ol>USUÁRIOS</ol></ul>
                            </div>

                            <div class="col-6B menu">
                                <ul><ol>USUÁRIOS</ol></ul>
                            </div>
                            <div class="col-3B menu">
                                <ul><ol>PERFIL</ol></ul>
                            </div>
                            <div class="col-3B menu">
                                <ul><ol>RESET SENHA</ol></ul>
                            </div>
                        </div>

                        <div id="divListaUsers" style="color: red;"></div>
                        <br />
                        <a href="javascript:void();" class="button" onclick="MostrarDetalheUsers('divGridUsersEdit');">&nbsp;&nbsp;Novo Representante&nbsp;&nbsp;</a>
                        <br />
                        <div id="divMsgUsersList" style="color: red;"></div>
                    </div>

                    <div id="divGridUsersEdit" style="display: none;">

                        <form method="post" action="javascript:SalvarUsers();">

                            <input type="text" id="txtCodUsers" disabled="disabled" style="display: none;" />
						    <div class="row">

							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Nome:</div>
                                    <input type="text" id="txtUsersNome" style="color: #e53c19;" placeholder="Entre com o Nome do Usuário."/>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">E-mail:</div>
                                    <input type="text" id="txtUsersEmail" style="color: #e53c19;" placeholder="Entre com o E-mail."/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pessoa:</div>
                                    <select id="lstUsersPessoa" style="color: #e53c19;">
                                        <option value="F" selected="selected">Física</option>
                                        <option value="J">Jurídica</option>
                                    </select>
                                </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CPF/CNPJ:</div>
                                    <input type="text" id="txtUsersDoc" style="color: #e53c19;" placeholder="Entre com o CPF/CNPJ."/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Perfil:</div>
                                    <select id="lstUsersPerfil" style="color: #e53c19;">
                                        <option value="Representante" selected="selected">Representante</option>
                                        <option value="Administrador">Administrador</option>
                                    </select>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Telefone:</div>
                                    <input type="text" id="txtUsersTel" style="color: #e53c19;" placeholder="Entre com Telefone."/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Situação:</div>
                                    <select id="lstUsersSit" style="color: #e53c19;">
                                        <option value="S" selected="selected">Ativo</option>
                                        <option value="N">Inativo</option>
                                    </select>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Endereço:</div>
                                    <input type="text" id="txtUsersEnd" style="color: #e53c19;" placeholder="Entre com o Endereço."/>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Cidade:</div>
                                    <input type="text" id="txtUsersCid" style="color: #e53c19;" placeholder="Entre com a Cidade."/>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Estado:</div>
                                    <select id="lstUsersUF" style="color: #e53c19;">
                                        <option value="SP" selected="selected">São Paulo</option>
                                        <option value="AC">Acre</option>
                                        <option value="AL">Alagoas</option>
                                        <option value="AP">Amapá</option>
                                        <option value="AM">Amazonas</option>
                                        <option value="BA">Bahia</option>
                                        <option value="CE">Ceará</option>
                                        <option value="DF">Distrito Federal</option>
                                        <option value="ES">Espírito Santo</option>
                                        <option value="GO">Goiás</option>
                                        <option value="MA">Maranhão</option>
                                        <option value="MT">Mato Grosso</option>
                                        <option value="MS">Mato Grosso do Sul</option>
                                        <option value="MG">Minas Gerais</option>
                                        <option value="PA">Pará</option>
                                        <option value="PB">Paraíba</option>
                                        <option value="PR">Paraná</option>
                                        <option value="PE">Pernambuco</option>
                                        <option value="PI">Piauí</option>
                                        <option value="RJ">Rio de Janeiro</option>
                                        <option value="RN">Rio Grande do Norte</option>
                                        <option value="RS">Rio Grande do Sul</option>
                                        <option value="RO">Rondônia</option>
                                        <option value="RR">Roraima</option>
                                        <option value="SC">Santa Catarina</option>
                                        <option value="SE">Sergipe</option>
                                        <option value="TO">Tocantins</option>
                                    </select>
							    </div>
							    <div class="6u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Percentual Licenca:</div>
                                    <input type="text" id="txtUsersPer" maxlength="5" style="color: #e53c19;" placeholder="Entre com o Percentual."/>
							    </div>
							    <div class="6u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Percentual Dispositivo:</div>
                                    <input type="text" id="txtUsersPerDisp" maxlength="5" style="color: #e53c19;" placeholder="Entre com o Percentual."/>
							    </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <a href="javascript:void();" class="button" onclick="MostrarDetalheUsers('divGridUsersList');">&nbsp;&nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;&nbsp;&nbsp;
                                    <input type="submit" value="&nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp;" />
							    </div>
							    <div class="col-12 menu" style="text-align: center;">
                                    <br />
                                    <div id="divMsgUsers" style="color: red;">
							    </div>
                            </div>

                        </form>

                    </div>

                </div>
            </section>

		</div>

		<!-- Footer -->
		<div id="footer">
			<!-- Copyright -->
			<ul class="copyright">
                <li>©2018 Quest360 | All rights reserved | <a href="http://www.ftcon.com.br" target="_blank">FTCon Consultoria</a></li>
			</ul>
		</div>

		<!-- Scripts -->
		<script src="assets/js/jquery.min.js"></script>
		<script src="assets/js/jquery.scrolly.min.js"></script>
		<script src="assets/js/jquery.scrollzer.min.js"></script>
		<script src="assets/js/skel.min.js"></script>
		<script src="assets/js/util.js"></script>
		<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
		<script src="assets/js/main.js"></script>
        <script src="assets/js/jquery.maskedinput.js"></script>
        <script src="assets/js/jquery.maskMoney.min.js"></script>

        <script src="assets/js/controller.bll.js"></script>
        <script src="assets/js/controller.crud.js"></script>
        <script src="assets/js/controller.form.js"></script>    
        <script src="assets/js/controller.load.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {

                //Carrega Mascara
                CarregarMascara();

                //Carrega Dados do Usuário
                CarregarDadosRepresentante();

                //Carrega Valores Licença
                CarregaValorLicenca();

                //Carregar Lista de Usuários()
                CarregaListaUsers();
            });
        </script>

    </body>
</html>

