<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.Index" %>

<!DOCTYPE html>

<html lang="pt-br" xmlns="http://www.w3.org/1999/xhtml">
    
    <head runat="server">
        <meta charset=utf-8>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="Conheça o Quest360 e como ele permite que os gestores recebam em tempo real os indicadores que auxiliarão nas melhores tomadas de decisões para o seu negócio." />
        
        <title>Quest360 | O ouvidor de seus Negócios</title>

        <!-- Load css styles -->
        <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="css/bootstrap-responsive.css" />
        <link rel="stylesheet" type="text/css" href="css/style.css" />
        <link rel="stylesheet" type="text/css" href="css/pluton.css" />
        <!--[if IE 7]>
            <link rel="stylesheet" type="text/css" href="css/pluton-ie7.css" />
        <![endif]-->
        <link rel="stylesheet" type="text/css" href="css/jquery.cslider.css" />
        <link rel="stylesheet" type="text/css" href="css/jquery.bxslider.css" />
        <link rel="stylesheet" type="text/css" href="css/animate.css" />
        <!-- Fav and touch icons -->
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144.png">
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/apple-touch-icon-72.png">
        <link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57.png">
        <link rel="shortcut icon" href="images/ico/favicon.ico">
    </head>
    
    <body>
        <div class="navbar">
            <div class="navbar-inner">
                <div class="container">
                    <a href="#" class="brand">
                        <img src="images/logo.png" alt="Logo" />
                        <!-- This is website logo -->
                    </a>
                    <!-- Navigation button, visible on small resolution -->
                    <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                        <i class="icon-menu"></i>
                    </button>
                    <!-- Main navigation -->
                    <div class="nav-collapse collapse pull-right">
                        <ul class="nav" id="top-navigation">
                            <li class="active"><a href="#home">Home</a></li>
                            <li><a href="#solucao">Solução</a></li>
                            <li><a href="#about">Sobre Quest360</a></li>
                            <li><a href="#clients">Como Contratar</a></li>
                            <li><a href="#contact">Contato</a></li>
                            <li><a href="acesso.aspx">Acesso Restrito</a></li>
                        </ul>
                    </div>
                    <!-- End main navigation -->
                </div>
            </div>
        </div>
        
        <!-- Início Home -->
        <div id="home">
            <!-- Start cSlider -->
            <div id="da-slider" class="da-slider">
                <div class="triangle"></div>
                <!-- mask elemet use for masking background image -->
                <div class="mask"></div>
                <!-- All slides centred in container element -->
                <div class="container">
                    <!-- Start first slide -->
                    <div class="da-slide">
                        <h2 class="fittext2">Bem-vindo ao Quest360</h2>
                        <h4>O ouvidor de seus negócios</h4>
                        <p>Conheça o nosso produto e como ele permite que os gestores recebam em tempo real os indicadores que auxiliarão nas melhores decisões para o seu negócio. O Quest360 será o melhor ouvinte do seu cliente e o melhor conselheiro para o seu negócio.</p>
                        <!--<a href="#" class="da-link button">Read more</a>-->
                        <div class="da-img">
                            <img src="images/Slider01.png" alt="image01" width="320">
                        </div>
                    </div>
                    <!-- End first slide -->
                    <!-- Start second slide -->
                    <div class="da-slide">
                        <h2>Feedback</h2>
                        <h4>Como anda o seu negócio?</h4>
                        <p>Receba um <i>feedback</i> real do andamento do seu negócio. Muitas vezes seu negócio esta sendo analisado e gerando ações sem que você saiba. Quando se trata do seu negócio, a informação sempre lhe será útil, a surpresa raramente.</p>
                        <!--<a href="#" class="da-link button">Read more</a>-->
                        <div class="da-img">
                            <img src="images/Slider02.png" width="320" alt="image02">
                        </div>
                    </div>
                    <!-- End second slide -->
                    <!-- Start third slide -->
                    <div class="da-slide">
                        <h2>Tomada de decisões</h2>
                        <h4>O <b>Quest360</b> auxilia nas decisões</h4>
                        <p>As informações quando chegam bem estruturadas, facilitam a tomada de decisões e impedem que situações desagradáveis aconteçam no seu negócio. Nós, da <strong>Quest360</strong>, acreditamos que não se pode gerenciar aquilo que não se conhece.</p>
                        <!--<a href="#" class="da-link button">Read more</a>-->
                        <div class="da-img">
                            <img src="images/Slider03.png" width="320" alt="image03">
                        </div>
                    </div>
                    <!-- Start third slide -->
                    <!-- Start cSlide navigation arrows -->
                    <div class="da-arrows">
                        <span class="da-arrows-prev"></span>
                        <span class="da-arrows-next"></span>
                    </div>
                    <!-- End cSlide navigation arrows -->
                </div>
            </div>
        </div>
        <!-- Término Home -->

        <!-- Início Solução -->
        <div class="section primary-section" id="solucao">
            <div class="container">
                <!-- Start title section -->
                <div class="title">
                    <h1>Como funciona?</h1>
                    <!-- Section's title goes here -->
                    <p>Quem contrata uma avaliação e/ou pesquisa espera receber resultados consistentes no menor prazo possível. O produto <strong>Quest<font color="#fff">360</font></strong> cumpre com esse objetivo, ao medir o melhor resultado com a maior rapidez possível. Nossa solução contempla os seguintes módulos:</p>
                    <!--Simple description for section goes here. -->
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="images/Service1.png" alt="service 1">
                            </div>
                            <h3>Q-Admin</h3>
                            <p>Portal web para cadastro, alteração e publicação de pesquisa(s).</p>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="images/Service2.png" alt="service 2" />
                            </div>
                            <h3>Q-Collect</h3>
                            <p>App mobile que coleta as respostas da(s) pesquisa(s).</p>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="images/Service3.png" alt="service 3">
                            </div>
                            <h3>Q-Analytics</h3>
                            <p>App mobile para acompanhamento do(s) resultado(s) em tempo real.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Término Solução -->

        <!-- Início Sobre Quest -->
        <div class="section secondary-section" id="about">
            <div class="triangle"></div>
            <div class="container centered">
                <h1>Sobre o <strong>Quest360</strong></h1>
                <p class="small-text" style="font-weight: 400;">
                    O <strong>Quest360</strong> nasceu com a necessidade que o departamento de marketing de uma empresa, multinacional do setor siderúrgico, enfrentava de entender o próprio cliente.<br /><br />
                    Com a grande concorrência neste mercado, a equipe precisava do retorno dos clientes, sobre os produtos lançados nas grandes feiras, com a maior rapidez possível.<br /><br />
                    Antes do <strong>Quest360</strong>, o trabalho era realizado com a coleta de dados no papel, que demandava tempo para obter o resultado e efetuar a tomada de decisões. Com o nosso produto, o resultado aparece na hora e a decisão pode ser rápida. <br /><br />
                    Na ocasião, fomos questionados sobre a possibilidade do aplicativo mobile também trabalhar off-line, já que algumas feiras ocorriam em fazendas, onde o sinal era fraco ou inexistente. Assim, nosso sistema incorporou essa praticidade, não dependendo de uma conexão de internet ativa por aparelho. <br /><br />
                    Hoje, a solução <strong>Quest360</strong> possui mais funcionalidades e se molda conforme sua necessidade da sua pesquisa e do seu negócio. <br /><br />
                    Nosso produto está disponível para a comercialização em empresas privadas (área de comércio, serviços e etc.), além do setor público.

                </p>
            </div>
        </div>
        <!-- Término Sobre Quest -->

        <!-- Início Representante -->
        <div id="clients">
            <div class="section primary-section">
                <div class="triangle"></div>
                <div class="container">
                    <div class="title">
                        <h1>Aquisição de uso do produto</h1>
                    </div>
                    <p style="text-align:center;">
                        Se você tem interesse em adquirir o <strong><font color="#7bd013">Quest</font>360</strong> para a sua empresa/negócio, entre em contato conosco para conhecer mais sobre esta solução, nossos planos e serviços disponíveis.
                    </p>
                    <br /><br />
                    <div class="title">
                        <h1>Seja um representante de venda</h1>
                    </div>
                    <p style="text-align:center;">
                        O <strong><font color="#7bd013">Quest</font>360</strong> é uma solução inovadora e que está em processo de expansão e sabemos que as parcerias são fundamentais para o crescimento dos negócios.<br /><br />
                        Se desejar ser nosso representante em sua região, saiba que trabalhamos com parcerias de forma simples, relacionamento duradouro e comissionamento acima do mercado. Entre em contato e veja como funciona.
                    </p>
                </div>
            </div>
            <div class="section third-section">
                <div class="container centered">
                    <div class="sub-section">
                        <div class="title clearfix">
                            <div class="pull-left">
                                <h3>Veja os potenciais setores em que o <b>Quest<font color="#fff">360</font></b> se enquadra perfeitamente.</h3>
                            </div>
                            <ul class="client-nav pull-right">
                                <li id="client-prev"></li>
                                <li id="client-next"></li>
                            </ul>
                        </div>
                        <ul class="row client-slider" id="clint-slider">
                            <li><img src="images/clients/ClientLogo01.png"></li>
                            <li><img src="images/clients/ClientLogo02.png"></li>
                            <li><img src="images/clients/ClientLogo03.png"></li>
                            <li><img src="images/clients/ClientLogo04.png"></li>
                            <li><img src="images/clients/ClientLogo05.png"></li>
                            <li><img src="images/clients/ClientLogo06.png"></li>
                            <li><img src="images/clients/ClientLogo07.png"></li>
                            <li><img src="images/clients/ClientLogo08.png"></li>
                            <li><img src="images/clients/ClientLogo09.png"></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <!-- Início Contato -->
        <div id="contact" class="contact">
            <div class="section secondary-section">
                <div class="triangle"></div>
                <div class="container">
                    <div class="title">
                        <h1>Contato</h1>
                        <p style="font-weight: 400;">Para maiores informações sobre o produto <strong>Quest360</strong> ou detalhes de como ser um representante desta solução, preencha o formulário abaixo e entraremos em contato o mais breve possível.</p>
                    </div>
                </div>
                <div class="section primary-section ">
                    <div class="container " >
                        <div class="span5 contact-form centered" >
                            <h3>Olá, será um prazer te responder!</h3>
                            <div class="row-fluid center">
                                <form id="contact-form" action="javascript:SendMail();">
                                    <div class="control-group">
                                        <div class="controls">
                                            <input class="span12" type="text" id="name" name="name" placeholder="* Seu nome..." />
                                            <div class="error left-align" id="err-name">Entre com seu nome</div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <input class="span12" type="email" name="email" id="email" placeholder="* Seu e-mail..." />
                                            <div class="error left-align" id="err-email">Entre com e-mail válido</div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <textarea class="span12" name="comment" id="comment" placeholder="* Mensagem..."></textarea>
                                            <div class="error left-align" id="err-comment">Entre com seu mensagem</div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <button type="submit" class="message-btn">Enviar</button>
                                        </div><br />
                                        <div id="divMsgEmail" style="display: block; width: 100%; height:100%;"></div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row-fluid centered">
                        <p>Av. Vida Nova, 28 - Taboão da Serra / SP - Tel.: 11 3136-0822</p>
                        <ul class="social">
                            <li>
                                <a href="">
                                    <span class="icon-facebook-circled"></span>
                                </a>
                            </li>
                            <li>
                                <a href="">
                                    <span class="icon-linkedin-circled"></span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- Término Contato -->

        <!-- Footer section start -->
        <div class="footer">
            <p>&copy;2017 Quest360 | All rights reserved | Desenvolvido por: <a href="http://www.ftcon.com.br" target="_blank">FTCon Consultoria</a></p>
        </div>
        <!-- Footer section end -->

        <!-- ScrollUp button start -->
        <div class="scrollup">
            <a href="#">
                <i class="icon-up-open"></i>
            </a>
        </div>
        <!-- ScrollUp button end -->

        <!-- Include javascript -->
        <script src="js/jquery.js"></script>
        <script type="text/javascript" src="js/jquery.mixitup.js"></script>
        <script type="text/javascript" src="js/bootstrap.js"></script>
        <script type="text/javascript" src="js/modernizr.custom.js"></script>
        <script type="text/javascript" src="js/jquery.bxslider.js"></script>
        <script type="text/javascript" src="js/jquery.cslider.js"></script>
        <script type="text/javascript" src="js/jquery.placeholder.js"></script>
        <script type="text/javascript" src="js/jquery.inview.js"></script>
        <script type="text/javascript" src="js/sendmail.js"></script>

        <!-- css3-mediaqueries.js for IE8 or older -->
        <!--[if lt IE 9]>
            <script src="js/respond.min.js"></script>
        <![endif]-->
        <script type="text/javascript" src="js/app.js"></script>
    </body>
</html>
