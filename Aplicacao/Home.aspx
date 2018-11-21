<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuestRep.WebApplication.Aplicacao.Home" %>

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
        <form id="form1" runat="server">
            <!-- Header -->
		    <div id="header">

			    <div class="top">

				    <!-- Dados Usuário Logado -->
					<div id="logo">
						<span class="image avatar48"><img src="images/avatar.jpg" alt="" /></span>
						<h1 id="title"><asp:Label ID="lblName" runat="server" Text=""></asp:Label></h1>
						<p><asp:Label ID="lblPerfil" runat="server" Text=""></asp:Label></p>
					</div>

				    <!-- Menu -->
				    <nav id="nav">
					    <ul>
                            <li><asp:LinkButton ID="hpCliente" runat="server" Text="<span class='icon fa-th'>Clientes</span>" class="skel-layers-ignoreHref" onclick="hpCliente_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="hpUser" runat="server" Text="<span class='icon fa-user'>Meus Dados</span>" class="skel-layers-ignoreHref" onclick="hpUser_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="hpConfig" runat="server" Text="<span class='icon fa-cogs'>Configuração</span>" class="skel-layers-ignoreHref" onclick="hpConfig_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="hpSair" runat="server" Text="<span class='icon fa-power-off'>Sair</span>" class="skel-layers-ignoreHref" onclick="hpSair_Click"></asp:LinkButton></li>
					    </ul>
				    </nav>

			    </div>

		    </div>

		    <!-- Main -->
		    <div id="main">

			    <!-- Clientes -->
				<section id="scClient" class="two" runat="server">
					<div class="container">

						<header>
							<h2>Clientes</h2>
						</header>

                        <div id="divGridCliente" runat="server">

                            <div class="row">
                                <div class="col-9 menu">
                                    <ul><ol>Cliente</ol></ul>
                                </div>
                                <div class="col-3A menu">
                                    <ul><ol>Vigência</ol></ul>
                                </div>
                                <div class="col-3B menu">
                                    <ul><ol>Vigência</ol></ul>
                                </div>
                            </div>

                            <asp:Label ID="lblGridCliente" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Button ID="btnNovoCliente" runat="server" Text=" &nbsp;&nbsp;Novo Cliente&nbsp;&nbsp; " OnClick="btnNovoCliente_Click" />

                        </div>

                        <div id="divCadCliente" runat="server" visible="false">

						    <div class="row">
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Nome:</div>
                                    <asp:TextBox ID="txtCliNome" runat="server"></asp:TextBox>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Responsável:</div>
                                    <asp:TextBox ID="txtCliResponsavel" runat="server"></asp:TextBox>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">E-mail:</div>
                                    <asp:TextBox ID="txtCliEmail" runat="server"></asp:TextBox>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Pessoa:</div>
                                        <asp:DropDownList ID="ddlCliPessoa" runat="server">
                                            <asp:ListItem Text="Jurídica" Value="J" Selected="True" />
                                            <asp:ListItem Text="Física" Value="F" />
                                        </asp:DropDownList>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CPF/CNPJ:</div>
                                    <asp:TextBox ID="txtCliDoc" runat="server"></asp:TextBox>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Representante:</div>
                                    <asp:TextBox ID="txtCliRepresentante" runat="server" BackColor="#e0e0e0" Enabled="false"></asp:TextBox>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência:</div>
                                        <asp:DropDownList ID="ddlCliVigencia" runat="server" ontextchanged="_ValueVigenciaChanged" autopostback="true">
                                            <asp:ListItem Text="Trimestral" Value="T" Selected="True" />
                                            <asp:ListItem Text="Semestral" Value="S" />
                                            <asp:ListItem Text="Anual" Value="A" />
                                        </asp:DropDownList>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Início:</div>
                                    <asp:TextBox ID="txtCliVigenciaInicio" runat="server" BackColor="#e0e0e0" Enabled="false" Font-Bold="true" ForeColor="#336600"></asp:TextBox>
							    </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Vigência Fim:</div>
                                    <asp:TextBox ID="txtCliVigenciaTermino" runat="server" BackColor="#e0e0e0" Enabled="false" Font-Bold="true" ForeColor="#336600"></asp:TextBox>
							    </div>
                                <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Qtde. Licença:</div>
                                    <asp:TextBox ID="txtCliQtdeLicenca" runat="server" ontextchanged="_ValueChanged" autopostback="true" Text="0"></asp:TextBox>
                                </div>
                                <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Qtde. Tablets:</div>
                                    <asp:TextBox ID="txtCliQtdeTablet" runat="server" ontextchanged="_ValueChanged" autopostback="true" Text="0"></asp:TextBox>
                                </div>
							    <div class="4u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Qtde. Suporte Mesa:</div>
                                    <asp:TextBox ID="txtCliQtdeSupMesa" runat="server" ontextchanged="_ValueChanged" autopostback="true" Text="0"></asp:TextBox>
							    </div>
							    <div class="4u 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Qtde. Suporte Chão:</div>
                                    <asp:TextBox ID="txtCliQtdeSupChao" runat="server" ontextchanged="_ValueChanged" autopostback="true" Text="0"></asp:TextBox>
							    </div>
							    <div class="8u$ 12u$(mobile)">
                                    <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Total do Investimento:</div>
                                    <asp:TextBox ID="txtCliTotal" runat="server" BackColor="#e0e0e0" Enabled="false" Font-Bold="true" ForeColor="#336600" Text="R$ 0,00"></asp:TextBox>
							    </div>
                                <div class="12u$" style="color: red; font-size: 0.70em; font-weight: bold; font-style: italic;">
                                    *Importante: Os preços estão sujeitos a alterações caso o envio do(s) tablet(s) e suporte(s) for para fora da grande São Paulo.
                                </div>
							    <div class="12u$">
                                    <asp:Button ID="btnCadVoltar" runat="server" Text=" &nbsp;&nbsp;&nbsp;Voltar&nbsp;&nbsp;&nbsp; " OnClick="btnCadVoltar_Click" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCadCliente" runat="server" Text=" &nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp; " OnClick="btnCadCliente_Click" />
                                    <br /><br /><asp:Label ID="lblMsgCli" ForeColor="Red" runat="server" Text=""></asp:Label>
							    </div>
						    </div>

                        </div>

					</div>
				</section>

			    <!-- Meus Dados -->
				<section id="scUser" class="two" runat="server">
					<div class="container">

						<header>
							<h2>Meus Dados</h2>
						</header>

						<div class="row">
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Nome:</div>
                                <asp:TextBox ID="txtUserNome" runat="server" BackColor="#e0e0e0" Enabled="false"></asp:TextBox>
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">E-mail:</div>
                                <asp:TextBox ID="txtUserEmail" runat="server" BackColor="#e0e0e0" Enabled="false"></asp:TextBox>
							</div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Perfil:</div>
                                <asp:TextBox ID="txtUserPerfil" runat="server" BackColor="#e0e0e0" Enabled="false"></asp:TextBox>
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">CPF/CNPJ:</div>
                                <asp:TextBox ID="txtUserDoc" runat="server" BackColor="#e0e0e0" Enabled="false"></asp:TextBox>
							</div>
							<div class="6u 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Senha:</div>
                                <asp:TextBox ID="txtUserSenha" runat="server" TextMode="Password" ForeColor="#e53c19" placeholder="Entre com a nova senha"></asp:TextBox>
							</div>
							<div class="6u$ 12u$(mobile)">
                                <div style="text-align:left; font-size: 0.80em; font-weight:bolder; color: #2f2f2f;">Confirme a Nova Senha:</div>
                                <asp:TextBox ID="txtUserConfirma" runat="server" TextMode="Password" ForeColor="#e53c19" placeholder="Confirme a nova senha"></asp:TextBox>
							</div>
							<div class="12u$">
                                <asp:Button ID="btnSenha" runat="server" Text="Alterar Senha" OnClick="btnSenha_Click" />
                                <br /><br /><asp:Label ID="lblMsgUser" ForeColor="Red" runat="server" Text=""></asp:Label>
							</div>
						</div>

					</div>
				</section>

			    <!-- Administrador -->
				<section id="scAdmin" class="two" runat="server">
					<div class="container">

						<header>
							<h2>Administrador</h2>
						</header>

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

        </form>
    </body>
</html>
