<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acesso.aspx.cs" Inherits="WebApplication.Acesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quest360 | Acesso Representante</title>

    <meta charset="UTF-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="icon" href="library/images/icons/favicon.ico">

	<link rel="stylesheet" type="text/css" href="library/vendor/bootstrap/css/bootstrap.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/fonts/iconic/css/material-design-iconic-font.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/animate/animate.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/css-hamburgers/hamburgers.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/animsition/css/animsition.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/select2/select2.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/daterangepicker/daterangepicker.css"/>
	<link rel="stylesheet" type="text/css" href="library/vendor/noui/nouislider.min.css"/>
	<link rel="stylesheet" type="text/css" href="library/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="library/css/main.css"/>

</head>
<body>

    <div class="container-contact100">
		<div class="wrap-contact100">
			<form id="form1" runat="server" class="contact100-form validate-form">
                <span class="contact100-form-title">
                    <a href="index.aspx"><img src="library/images/logo.png" /></a>
                </span>
				<span class="contact100-form-title">
					BEM-VINDO AO ACESSO RESTRITO
				</span>

				<div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate = "E-mail é obrigatório.">
					<span class="label-input100">Email</span>
                    <asp:TextBox ID="email" runat="server" CssClass="input100" placeholder="Entre com seu e-mail (e@a.x)"></asp:TextBox>
				</div>

				<div class="wrap-input100 validate-input bg1 rs1-wrap-input100" data-validate="Senha é obrigatório.">
					<span class="label-input100">Senha</span>
                    <asp:TextBox ID="password" TextMode="Password" runat="server" CssClass="input100" placeholder="Entre com sua senha."></asp:TextBox>
				</div>

				<div class="container-contact100-form-btn">
                    <asp:Button ID="btnAcesso" runat="server" CssClass="contact100-form-btn" Text="Entrar" OnClick="btnAcesso_Click" />
				</div>

				<span class="contact100-form-msg">
					&nbsp;<br /><asp:Label ID="lblMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
				</span>
			</form>
		</div>
	</div>

	<script src="library/vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="library/vendor/animsition/js/animsition.min.js"></script>
	<script src="library/vendor/bootstrap/js/popper.js"></script>
	<script src="library/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="library/vendor/select2/select2.min.js"></script>
	<script src="library/vendor/daterangepicker/moment.min.js"></script>
	<script src="library/vendor/daterangepicker/daterangepicker.js"></script>
	<script src="library/vendor/countdowntime/countdowntime.js"></script>
	<script src="library/vendor/noui/nouislider.min.js"></script>
	<script src="library/js/main.js"></script>

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
    <script>
      window.dataLayer = window.dataLayer || [];
      function gtag(){dataLayer.push(arguments);}
      gtag('js', new Date());

      gtag('config', 'UA-23581568-13');
    </script>

    </body>
</html>


