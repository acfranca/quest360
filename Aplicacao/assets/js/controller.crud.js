function AlterarSenha() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoSenha())
        return;

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pID: '" + $("#hdTxtCodUser").val() + "', pSenha: '" + $("#txtUserConfirma").val() + "'}",
        url: 'Start.aspx/WSAlterarSenha',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgUser').html(data.d[0]);
        },
        error: function (erro) {
            $('#divMsgUser').html(data.d[0]);
        }
    })

    //Limpa formulário
    LimparForm();
}

function ResetSenha(pUser, pNome) {

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pID: '" + pUser + "'}",
        url: 'Start.aspx/WSResetarSenha',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgUsersList').html("Senha do usuário <b>" + pNome + data.d[0]);
        },
        error: function (erro) {
            $('#divMsgUsersList').html(data.d[0]);
        }
    })
}

function AlterarValorLicenca() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoValorLicenca())
        return;

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pVlrTrimestral: '" + $("#txtLicVlrLicenca3").val() + "', pVlrSemestral: '" + $("#txtLicVlrLicenca6").val() + "', pVlrAnual: '" + $("#txtLicVlrLicenca12").val() + "', pVlrTablet7: '" + $("#txtLicVlrTablet7").val() + "', pVlrSupMesa7: '" + $("#txtLicVlrSupMesa7").val() + "', pVlrTablet10: '" + $("#txtLicVlrTablet10").val() + "', pVlrSupMesa10: '" + $("#txtLicVlrSupMesa10").val() + "', pVlrChao:  '0', pRepresentante: '" + $("#hdTxtCodUser").val() + "'}",
        url: 'Start.aspx/WSAlterarValorLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgVlrLicenca').html(data.d[0]);
        },
        error: function (erro) {
            $('#divMsgVlrLicenca').html(data.d[0]);
        }
    })
}

function SalvarCliente() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoCliente())
        return;

    //alert("{ pID: '" + $("#txtCodCliente").val() + "', pNome: '" + $("#txtCliNome").val() + "', pResponsavel: '" + $("#txtCliResp").val() + "', pEmail: '" + $("#txtCliEmail").val() + "', pTelefone: '" + $("#txtCliTel").val() + "', pEndereco: '" + $("#txtCliEnd").val() + "', pCidade: '" + $("#txtCliCid").val() + "', pUF: '" + $("#lstCliUF option:selected").val() + "', pCEP: '" + $("#txtCliCEP").val() + "', pPessoa: '" + $("#lstCliPessoa option:selected").val() + "', pDoc: '" + $("#txtCliDoc").val() + "', pCodUser: '" + $("#hdTxtCodUser").val() + "'}");

    //Chama a requisição do servidor que irá salvar os dados do cliente
    $.ajax({
        type: 'post',
        data: "{ pID: '" + $("#txtCodCliente").val() + "', pNome: '" + $("#txtCliNome").val() + "', pResponsavel: '" + $("#txtCliResp").val() + "', pEmail: '" + $("#txtCliEmail").val() + "', pTelefone: '" + $("#txtCliTel").val() + "', pEndereco: '" + $("#txtCliEnd").val() + "', pCidade: '" + $("#txtCliCid").val() + "', pUF: '" + $("#lstCliUF option:selected").val() + "', pCEP: '" + $("#txtCliCEP").val() + "', pPessoa: '" + $("#lstCliPessoa option:selected").val() + "', pDoc: '" + $("#txtCliDoc").val() + "', pCodUser: '" + $("#hdTxtCodUser").val() + "'}",
        url: 'Start.aspx/WSSalvarCliente',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgCliente').html(data.d[0]);

            //Limpa formulário
            LimpaFormCliente();

            //Carrega Combo Clientes
            CarregarComboClientes($("#hdTxtCodUser").val());
            CarregarComboClientesPorUser($("#hdTxtCodUser").val());
        },
        error: function (erro) {
            $('#divMsgCliente').html(data.d[0]);
        }
    })
}

function CarregaDadosCliente(pCliente) {

    //Chama a requisição do servidor que irá carregar os dados do cliente
    $.ajax({
        type: 'post',
        data: "{ pCliente: '" + pCliente + "'}",
        url: 'Start.aspx/WSCarregarDadosCliente',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#txtCodCliente').val(data.d[0]);
            $('#txtCliNome').val(data.d[1]);
            $('#txtCliResp').val(data.d[2]);
            $('#txtCliEmail').val(data.d[3]);
            $('#txtCliTel').val(data.d[4]);
            $('#txtCliEnd').val(data.d[5]);
            $('#txtCliCid').val(data.d[6]);
            $("#lstCliUF").val(data.d[7]);
            $('#txtCliCEP').val(data.d[8]);
            $("#lstCliPessoa").val(data.d[9]);
            $('#txtCliDoc').val(data.d[10]);

        },
        error: function (erro) {
            $('#divMsgCliente').html(data.d[0]);
        }
    })
}

function CarregaDadosUsers(pUsers) {

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pUsers: '" + pUsers + "'}",
        url: 'Start.aspx/WSCarregarDadosUsers',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#txtCodUsers').val(data.d[0]);
            $('#txtUsersNome').val(data.d[1]);
            $('#txtUsersEmail').val(data.d[2]);
            $('#txtUsersTel').val(data.d[3]);
            $('#lstUsersPessoa').val(data.d[4]);
            $('#txtUsersDoc').val(data.d[5]);
            $('#lstUsersPerfil').val(data.d[6]);
            $("#lstUsersSit").val(data.d[7]);
            $('#txtUsersEnd').val(data.d[8]);
            $('#txtUsersCid').val(data.d[9]);
            $("#lstUsersUF").val(data.d[10]);
            $("#txtUsersPer").val(data.d[11]);
            $("#txtUsersPerDisp").val(data.d[12]);

        },
        error: function (erro) {
            $('#divMsgUsers').html(data.d[0]);
        }
    })
}

function CarregaDadosClienteLicenca(pClienteLicenca) {

    //Chama a requisição do servidor que irá carregar os dados do ClienteLicenca
    $.ajax({
        type: 'post',
        data: "{ pClienteLicenca: '" + pClienteLicenca + "'}",
        url: 'Start.aspx/WSCarregarDadosClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $("#lstLicCliente").val(data.d[0]);
            $("#lstLicVigencia").val(data.d[1]);
            $('#txtLicQtde').val(data.d[2]);
            $('#txtLicChave').val(data.d[3]);
            $('#txtLicVigInicio').val(data.d[4]);
            $('#txtLicVigTermino').val(data.d[5]);
            $('#txtLicQtdeSupMesa7').val(data.d[6]);
            $('#txtLicQtdeSupMesa10').val(data.d[7]);
            $("#txtLicTotal").val(data.d[8]);
            $('#txtLicObservacaoLicenca').val(data.d[9]);
            $('#txtLicPagtoSitLicenca').val(data.d[10]);
            $('#txtLicPagtoSitPagto').val(data.d[11]);
            $('#txtLicPagtoData').val(data.d[12]);
            $('#hdTxtVlrLicenca').val(data.d[13]);
            $('#hdTxtVlrDispositivo').val(data.d[14]);
            $('#txtLicClienteOculto').val(data.d[15]);
        },
        error: function (erro) {
            $('#divMsgClienteLicenca').html(data.d[0]);
        }
    })
}

function CarregaDadosStatus(pClienteLicenca) {

    //Chama a requisição do servidor que irá carregar os dados do Status
    $.ajax({
        type: 'post',
        data: "{ pClienteLicenca: '" + pClienteLicenca + "'}",
        url: 'Start.aspx/WSCarregarDadosClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#txtStatusChave').val(data.d[3]);
            $("#txtStatusCliente").val(data.d[15]);
            $("#txtStatusRepresentante").val(data.d[16]);
            $("#lstStatusSitLic").val(data.d[10]);
            $('#lstStatusSitPag').val(data.d[11]);
            $('#txtStatusPagtoData').val(data.d[12]);
            $('#lstStatusSitPagComissao').val(data.d[21]);
            $('#txtStatusPagtoDataComissao').val(data.d[22]);
            $("#txtStatusCodClienteLicenca").val(data.d[24]);
            $('#divObservacaoPagto').html(data.d[9]);

            //Limpa Campos Obervação
            $('#txtLicObservacaoPagto').val('');
        },
        error: function (erro) {
            $('#divMsgStatus').html(data.d[0]);
        }
    })
}

function CarregaDadosExtrato(pClienteLicenca)
{
    //Chama a requisição do servidor que irá carregar os dados do Extrato
    $.ajax({
        type: 'post',
        data: "{ pClienteLicenca: '" + pClienteLicenca + "'}",
        url: 'Start.aspx/WSCarregarDadosClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#txtExtChave').val(data.d[3]);
            $("#txtExtNome").val(data.d[15]);
            $("#txtExtResp").val(data.d[16]);
            $('#lstExtVigencia').val(data.d[1]);
            $('#txtExtVigInicio').val(data.d[4]);
            $('#txtExtVigTermino').val(data.d[5]);
            $('#txtExtPagtoSitLicenca').val(data.d[10]);
            $('#txtExtPagtoSitPagto').val(data.d[11]);
            $('#txtExtPagtoData').val(data.d[12]);
            $('#txtExtVlrLicenca').val('R$ ' + data.d[13]);
            $('#txtExtVlrDisp').val('R$ ' + data.d[14]);
            $('#txtExtPerComLicenca').val(data.d[17]);
            $('#txtExtPerComDisp').val(data.d[18]);
            $('#txtExtVlrComLicenca').val('R$ ' + data.d[19]);
            $('#txtExtVlrComDisp').val('R$ ' + data.d[20]);
            $('#txtExtComSituacao').val(data.d[21]);
            $('#txtExtComPagoEm').val(data.d[22]);
            $('#txtExtComVlrTotal').val('R$ ' + data.d[23]);
        },
        error: function (erro) {
            $('#divMsgClienteLicenca').html(data.d[0]);
        }
    })
}

function SalvarUsers() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoUsers())
        return;

    //alert("{ pID: '" + $("#txtCodUsers").val() + "', pNome: '" + $("#txtUsersNome").val() + "', pEmail: '" + $("#txtUsersEmail").val() + "', pTelefone: '" + $("#txtUsersTel").val() + "', pEndereco: '" + $("#txtUsersEnd").val() + "', pCidade: '" + $("#txtUsersCid").val() + "', pUF: '" + $("#lstUsersUF option:selected").val() + "', pPessoa: '" + $("#lstUsersPessoa option:selected").val() + "', pDoc: '" + $("#txtUsersDoc").val() + "', pAtivo: '" + $("#lstUsersSit option:selected").val() + "', pPerfil: '" + $("#lstUsersPerfil option:selected").val() + "', pPercentual: '" + $("#txtUsersPer").val() + "', pPerDispositivo: '" + $("#txtUsersPerDisp").val() + "'}");

    //Chama a requisição do servidor que irá salvar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pID: '" + $("#txtCodUsers").val() + "', pNome: '" + $("#txtUsersNome").val() + "', pEmail: '" + $("#txtUsersEmail").val() + "', pTelefone: '" + $("#txtUsersTel").val() + "', pEndereco: '" + $("#txtUsersEnd").val() + "', pCidade: '" + $("#txtUsersCid").val() + "', pUF: '" + $("#lstUsersUF option:selected").val() + "', pPessoa: '" + $("#lstUsersPessoa option:selected").val() + "', pDoc: '" + $("#txtUsersDoc").val() + "', pAtivo: '" + $("#lstUsersSit option:selected").val() + "', pPerfil: '" + $("#lstUsersPerfil option:selected").val() + "', pPerLicenca: '" + $("#txtUsersPer").val() + "', pPerDispositivo: '" + $("#txtUsersPerDisp").val() + "'}",
        url: 'Start.aspx/WSSalvarRepresentante',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgUsers').html(data.d[0]);

            //Limpa formulário
            LimpaFormUsers();

            //Carrega Lista de Usuários
            CarregaListaUsers();
        },
        error: function (erro) {
            $('#divMsgUsers').html(data.d[0]);
        }
    })
}

function SalvarClienteLicenca() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoClienteLicenca())
        return;

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pCliente: '" + $("#lstLicCliente option:selected").val() + "', pVigInicio: '" + $("#txtLicVigInicio").val() + "', pVigTermino: '" + $("#txtLicVigTermino").val() + "', pVigencia: '" + $("#lstLicVigencia option:selected").val() + "', pQtdeLicenca: '" + $("#txtLicQtde").val() + "', pQtdeTablet7: '" + $("#txtLicQtdeTablet7").val() + "', pQtdeSupMesa7: '" + $("#txtLicQtdeSupMesa7").val() + "', pQtdeTablet10: '" + $("#txtLicQtdeTablet10").val() + "', pQtdeSupMesa10: '" + $("#txtLicQtdeSupMesa10").val() + "', pQtdeSupChao: '0', pVlrTrimestral: '" + $("#txtLicVlrLicenca3").val() + "', pVlrSemestral: '" + $("#txtLicVlrLicenca6").val() + "', pVlrAnual: '" + $("#txtLicVlrLicenca12").val() + "', pVlrTablet7: '" + $("#txtLicVlrTablet7").val() + "', pVlrSupMesa7: '" + $("#txtLicVlrSupMesa7").val() + "', pVlrTablet10: '" + $("#txtLicVlrTablet10").val() + "', pVlrSupMesa10: '" + $("#txtLicVlrSupMesa10").val() + "', pVlrSupChao: '0', pVlrTotal: '" + $("#txtLicTotal").val() + "', pPerLicenca: '" + $("#txtUserPerc").val() + "', pPerDispositivo: '" + $("#txtUserPercDispositivo").val() + "', pUser: '" + $("#hdTxtCodUser").val() + "', pVlrLicenca: '" + $("#hdTxtVlrLicenca").val() + "', pVlrDispostivo: '" + $("#hdTxtVlrDispositivo").val() + "', pObsLicenca: ' " + $('#txtLicObservacaoLicenca').val() + "'}",
        url: 'Start.aspx/WSSalvarClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgClienteLicenca').html(data.d[0]);

            //Limpa Formulário
            LimpaFormClienteLicenca();
        },
        error: function (erro) {
            $('#divMsgClienteLicenca').html(data.d[0]);
        }
    })
}

function SalvarStatus() {

    //Valida o preenchimento do formulário
    if (!ValidaPreenchimentoStatus())
        return;

    //alert("pID: '" + $("#txtStatusCodClienteLicenca").val() + "', pSitLicenca: '" + $("#lstStatusSitLic option:selected").val() + "', pSitPagto: '" + $("#lstStatusSitPag option:selected").val() + "', pDtaPagto: '" + $("#txtStatusPagtoData").val() + "', pSitPagtoComissao: '" + $("#lstStatusSitPagComissao option:selected").val() + "', pDtaPagtoComissao: '" + $("#txtStatusPagtoDataComissao").val() + "', pObsPagto: '" + $("#txtLicObservacaoPagto").val() + "', pCodUser: '" + $("#hdTxtCodUser").val() + "'");

    //Chama a requisição do servidor que irá salvar os dados
    $.ajax({
        type: 'post',
        data: "{ pID: '" + $("#txtStatusCodClienteLicenca").val() + "', pSitLicenca: '" + $("#lstStatusSitLic option:selected").val() + "', pSitPagto: '" + $("#lstStatusSitPag option:selected").val() + "', pDtaPagto: '" + $("#txtStatusPagtoData").val() + "', pSitPagtoComissao: '" + $("#lstStatusSitPagComissao option:selected").val() + "', pDtaPagtoComissao: '" + $("#txtStatusPagtoDataComissao").val() + "', pObsPagto: '" + $("#txtLicObservacaoPagto").val() + "', pCodUser: '" + $("#hdTxtCodUser").val() + "'}",
        url: 'Start.aspx/WSSalvarStatus',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário da consulta
            $('#divMsgStatus').html(data.d[0]);
        },
        error: function (erro) {
            $('#divMsgStatus').html(data.d[0]);
        }
    })
}

function CarregarComboClientes(pUser, pPerfil) {

    //Se for Administrador, traz todos os clientes
    if (pPerfil == 'Administrador') {
        pUser = '';
    }

    //Chama a requisição do servidor que irá carregar o Combo do Cliente
    $.ajax({
        type: 'post',
        data: "{ pID: '" + pUser + "'}",
        url: 'Start.aspx/WSCarregarComboCliente',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#lstDivLicClientePorUser').html(data.d[0]);
            $('#lstDivStatusClienteLicencaPorUser').html(data.d[1]);
            $('#lstDivExtratoPorUser').html(data.d[2]);
            
        },
        error: function (erro) {
            $('#lstDivLicClientePorUser').html(data.d[0]);
            $('#lstDivStatusClienteLicencaPorUser').html(data.d[1]);
            $('#lstDivExtratoPorUser').html(data.d[2]);
        }
    })
}

function CarregarComboClientesPorUser(pUser) {

    //Chama a requisição do servidor que irá carregar o Combo do Cliente
    $.ajax({
        type: 'post',
        data: "{ pID: '" + pUser + "'}",
        url: 'Start.aspx/WSCarregarComboClientePorUser',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#lstDivLicCliente').html(data.d[0]);

        },
        error: function (erro) {
            $('#lstDivLicCliente').html(data.d[0]);
        }
    })
}

function CarregarComboUsers() {

    //alert("{ pUserLogado: '" + $("#hdTxtCodUser").val() + "', pNomeUserLogado: '" + $("#hdTxtNmUser").val() + "', pPerfil: '" + $("#hdTxtPfUser").val() + "'}");

    //Chama a requisição do servidor que irá carregar o Combo do Usuário
    $.ajax({
        type: 'post',
        data: "{ pUserLogado: '" + $("#hdTxtCodUser").val() + "', pNomeUserLogado: '" + $("#hdTxtNmUser").val() + "', pPerfil: '" + $("#hdTxtPfUser").val() + "'}",
        url: 'Start.aspx/WSCarregarComboUsers',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#lstDivStatusUsers').html(data.d[0]);
            $('#lstDivPesqCliRepresentante').html(data.d[1]);
            $('#lstDivPesqExtRepresentante').html(data.d[2]);

        },
        error: function (erro) {
            $('#lstDivStatusUsers').html(data.d[0]);
            $('#lstDivPesqCliRepresentante').html(data.d[1]);
            $('#lstDivPesqExtRepresentante').html(data.d[2]);
        }
    })
}

function PesquisarCliente(pPerfil) {

    //alert("{ pRepresentante: '" + $("#lstPesqCliRepresentante option:selected").val() + "', pNome: '" + $("#txtPesqCliNome").val() + "', pResponsavel: '" + $("#txtPesqCliResponsavel").val() + "'}");

    //Chama a requisição do servidor que irá carregar os clientes
    $.ajax({
        type: 'post',
        data: "{ pRepresentante: '" + $("#lstPesqCliRepresentante option:selected").val() + "', pNome: '" + $("#txtPesqCliNome").val() + "', pResponsavel: '" + $("#txtPesqCliResponsavel").val() + "'}",
        url: 'Start.aspx/WSPesquisarCliente',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#divListaCliente').html(data.d[0]);

        },
        error: function (erro) {
            $('#divListaCliente').html(data.d[0]);
        }
    })
}

function PesquisarListaClienteLicenca() {

    //Se for Administrador, traz todos os clientes
    if ($('#txtUserPerfil').val() == 'Administrador') {
        pUser = '';
    }
    else {
        pUser = $("#hdTxtCodUser").val();
    }

    //alert("{ pID: '', pCliente: '" + $("#lstLicClientePorUser option:selected").val() + "', pUser: '" + pUser + "', pSitLicenca: '" + $("#lstLicClienteSitLic option:selected").val() + "', pSitPagto: '" + $("#lstLicClienteSitPag option:selected").val() + "', pForm: 'ClienteLicenca'}");

    //Chama a requisição do servidor que irá carregar o grid de Cliente
    $.ajax({
        type: 'post',
        data: "{ pID: '', pCliente: '" + $("#lstLicClientePorUser option:selected").val() + "', pUser: '" + pUser + "', pSitLicenca: '" + $("#lstLicClienteSitLic option:selected").val() + "', pSitPagto: '" + $("#lstLicClienteSitPag option:selected").val() + "', pForm: 'ClienteLicenca'}",
        url: 'Start.aspx/WSPesquisarListaClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#divListaClienteLicenca').html(data.d[0]);
        },
        error: function (erro) {
            $('#divListaClienteLicenca').html(data.d[0]);
        }
    })
}

function PesquisarListaExtrato() {

    //Chama a requisição do servidor que irá carregar o grid do Extrato
    $.ajax({
        type: 'post',
        data: "{ pCliente: '" + $("#lstExtratoPorUser option:selected").val() + "', pSitPagtoLicenca: '" + $("#lstLicExtratoSitPag option:selected").val() + "', pSitPagtoComissao: '" + $("#lstLicExtratoSitPagComissao option:selected").val() + "', pVigencia: '" + $("#lstExtratoVigencia option:selected").val() + "', pSitLicenca: '" + $("#lstLicExtratoSitLic option:selected").val() + "', pUser: '" + $("#lstPesqExtRepresentante option:selected").val() + "'}",
        url: 'Start.aspx/WSPesquisarListaExtrato',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#divListaExtrato').html(data.d[0]);
        },
        error: function (erro) {
            $('#divListaExtrato').html(data.d[0]);
        }
    })
}

function PesquisarListaStatus() {

    //Chama a requisição do servidor que irá carregar o grid de Cliente
    $.ajax({
        type: 'post',
        data: "{ pID: '', pCliente: '" + $("#lstPesquisaStatusPorUser option:selected").val() + "', pUser: '" + $("#lstStatusRepresentante option:selected").val() + "', pSitLicenca: '" + $("#lstPesquisaStatusSitLic option:selected").val() + "', pSitPagto: '', pForm: 'Status'}",
        url: 'Start.aspx/WSPesquisarListaClienteLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche Combo Cliente
            $('#divStatusListaClienteLicenca').html(data.d[0]);
        },
        error: function (erro) {
            $('#divStatusListaClienteLicenca').html(data.d[0]);
        }
    })
}






