function CarregarMenu(pPerfil) {

    if (pPerfil == "Administrador") {
        ShowObjeto('hpStatus', 'block');
        ShowObjeto('hpConfigLic', 'block');
        ShowObjeto('hpConfigUser', 'block');
    }
}

function CarregarMascara() {

    //Configurar Licença
    $('#txtLicVlrLicenca3').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrLicenca6').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrLicenca12').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrTablet7').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrSupMesa7').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrTablet10').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrSupMesa10').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });
    $('#txtLicVlrSupChao').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: ".", precision: 2 });

    //Gerenciar Licença
    //$('#txtLicTotal').maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });
    $('#txtLicQtde').maskMoney({ decimal: ',', thousands: '.', precision: 0 });
    $('#txtLicQtdeTablet').maskMoney({ decimal: ',', thousands: '.', precision: 0 });
    $('#txtLicQtdeSupMesa').maskMoney({ decimal: ',', thousands: '.', precision: 0 });
    $('#txtLicQtdeSupChao').maskMoney({ decimal: ',', thousands: '.', precision: 0 });

    //Configurar Usuários
    $('#txtUsersPer').maskMoney({ decimal: ',', thousands: '.', precision: 2 });
    $('#txtUsersPerDisp').maskMoney({ decimal: ',', thousands: '.', precision: 2 });

    //Gerenciar Status
    $('#txtStatusPagtoData').mask("99/99/9999");
    $('#txtStatusPagtoDataComissao').mask("99/99/9999");
}

function CarregarDadosRepresentante() {

    //Chama a requisição do servidor que irá carregar os dados do usuário
    $.ajax({
        type: 'post',
        data: "{ pID: '" + $("#hdTxtCodUser").val() + "'}",
        url: 'Start.aspx/WSCarregarDadosUser',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $("#txtUserNome").val(data.d[0]);
            $('#txtUserEmail').val(data.d[1]);
            $('#txtUserPerfil').val(data.d[2]);
            $('#txtUserDoc').val(data.d[3]);
            $('#txtUserPerc').val(data.d[4]);
            $('#txtUserPercDispositivo').val(data.d[5]);

            //Carrega Combo Clientes
            CarregarComboClientes($("#hdTxtCodUser").val(), data.d[2]);
            CarregarComboClientesPorUser($("#hdTxtCodUser").val(), data.d[2]);

            //Carrega Combo Usuários
            CarregarComboUsers();

            //Carrega Menu
            CarregarMenu(data.d[2]);
        },
        error: function (erro) {
            $('#divMsgUser').html(data.d[0]);
        }
    })
}

function CarregaValorLicenca() {

    //Chama a requisição do servidor que irá carregar os valores da licença
    $.ajax({
        type: 'post',
        url: 'Start.aspx/WSCarregarVlrLicenca',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $("#txtLicVlrLicenca3").val(data.d[0]);
            $('#txtLicVlrLicenca6').val(data.d[1]);
            $('#txtLicVlrLicenca12').val(data.d[2]);
            $('#txtLicVlrTablet7').val(data.d[3]);
            $('#txtLicVlrSupMesa7').val(data.d[4]);
            $('#txtLicVlrTablet10').val(data.d[5]);
            $('#txtLicVlrSupMesa10').val(data.d[6]);
            $('#txtLicVlrAlteradoEm').val(data.d[7]);
            $('#txtLicVlrAlteradoPor').val(data.d[8]);

            $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ ' + data.d[0] + '</b>)');
            $('#divLstPrecoTablet7').html('Qtde. Aluguel Tablet 7": (<b>R$ ' + data.d[3] + '</b>)');
            $('#divLstPrecoSupMesa7').html('Qtde. Suporte de Mesa 7": (<b>R$ ' + data.d[4] + '</b>)');
            $('#divLstPrecoTablet10').html('Qtde. Aluguel Tablet 10": (<b>R$ ' + data.d[5] + '</b>)');
            $('#divLstPrecoSupMesa10').html('Qtde. Suporte de Mesa 10": (<b>R$ ' + data.d[6] + '</b>)');

        },
        error: function (erro) {
            $('#divMsgVlrLicenca').html(data.d[0]);
        }
    })
}

//function CarregaListaCliente(pPerfil) {
    
//    //Chama a requisição do servidor que irá carregar os clientes
//    $.ajax({
//        type: 'post',
//        data: "{ pPerfil: '" + pPerfil + "', pUser: '" + $("#hdTxtCodUser").val() + "'}",
//        url: 'Start.aspx/WSCarregarListaCliente',
//        contentType: 'application/json; charset=utf-8',
//        datType: 'json',
//        success: function (data) {

//            //Preenche dados do formulário
//            $('#divListaCliente').html(data.d[0]);
            
//        },
//        error: function (erro) {
//            $('#divListaCliente').html(data.d[0]);
//        }
//    })
//}

function CarregaListaUsers() {

    //Chama a requisição do servidor que irá carregar os clientes
    $.ajax({
        type: 'post',
        url: 'Start.aspx/WSCarregarListaUsers',
        contentType: 'application/json; charset=utf-8',
        datType: 'json',
        success: function (data) {

            //Preenche dados do formulário
            $('#divListaUsers').html(data.d[0]);

        },
        error: function (erro) {
            $('#divListaUsers').html(data.d[0]);
        }
    })
}