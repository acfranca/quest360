//Valida Preenchimento dos Formulários
function ValidaPreenchimentoSenha() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se o campo Nome estiver vazio... preenche msg de obrigatório
    if ($.trim($("#txtUserSenha").val()) == "") {
        vMsg = "- Senha é obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUserConfirma").val()) == "") {
        vMsg += "- Confirma Senha é obrigatório.";
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgUser').html(vMsg);

        return false;
    }
    else {

        if ($.trim($("#txtUserSenha").val()) != $.trim($("#txtUserConfirma").val())) {
            $('#divMsgUser').html("- Senha está diferente de Confirmar Senha.<br />");
            return false;
        }

        return true;
    }
}
function ValidaPreenchimentoValorLicenca() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se o campo Nome estiver vazio... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrLicenca3").val()) == "") {
        vMsg = "- Valor Licença Trimestral é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrLicenca6").val()) == "") {
        vMsg += "- Valor Licença Semestral é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrLicenca12").val()) == "") {
        vMsg += "- Valor Licença Anual é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrTablet7").val()) == "") {
        vMsg += "- Valor do Tablet 7 polegadas é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrSupMesa7").val()) == "") {
        vMsg += "- Valor Suporte de Mesa 7 polegadas é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrTablet10").val()) == "") {
        vMsg += "- Valor do Tablet 10 polegadas é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtLicVlrSupMesa10").val()) == "") {
        vMsg += "- Valor Suporte de Mesa 10 polegadas é Obrigatório.<br />";
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgVlrLicenca').html(vMsg);

        return false;
    }

    return true;
}
function ValidaPreenchimentoCliente() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se o campo Nome estiver vazio... preenche msg de obrigatório
    if ($.trim($("#txtCliNome").val()) == "") {
        vMsg = "- Nome é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliResp").val()) == "") {
        vMsg += "- Responsável é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliEmail").val()) == "") {
        vMsg += "- Email é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliTel").val()) == "") {
        vMsg += "- Telefone é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliEnd").val()) == "") {
        vMsg += "- Endereço é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliCid").val()) == "") {
        vMsg += "- Cidade é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliCEP").val()) == "") {
        vMsg += "- CEP é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtCliDoc").val()) == "") {
        vMsg += "- CPF/CNPJ é Obrigatório.<br />";
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgCliente').html(vMsg);

        return false;
    }

    return true;
}
function ValidaPreenchimentoUsers() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se o campo Nome estiver vazio... preenche msg de obrigatório
    if ($.trim($("#txtUsersNome").val()) == "") {
        vMsg = "- Nome é Obrigatório.<br />";
    }

    //Se o campo email estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersEmail").val()) == "") {
        vMsg += "- Email é Obrigatório.<br />";
    }

    //Se o campo telefone estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersTel").val()) == "") {
        vMsg += "- Telefone é Obrigatório.<br />";
    }

    //Se o campo Endereco estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersEnd").val()) == "") {
        vMsg += "- Endereço é Obrigatório.<br />";
    }

    //Se o campo Cidade estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersCid").val()) == "") {
        vMsg += "- Cidade é Obrigatório.<br />";
    }

    //Se o campo Documento estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersDoc").val()) == "") {
        vMsg += "- CPF/CNPJ é Obrigatório.<br />";
    }

    //Se o campo Percentual Licenca estiver vazio ... preenche msg de obrigatório
    if ($.trim($("#txtUsersPer").val()) == "") {
        vMsg += "- Percentual Licença é Obrigatório.<br />";
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgUsers').html(vMsg);

        return false;
    }

    return true;
}
function ValidaPreenchimentoClienteLicenca() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se o campo Cliente estiver vazio... preenche msg de obrigatório
    if ($("#lstLicCliente option:selected").val() == "") {
        vMsg = "- Cliente é Obrigatório.<br />";
    }

    //Se o campo Qtde Licenca estiver vazio... preenche msg de obrigatório
    if ($.trim($("#txtLicQtde").val()) == "") {
        vMsg += "- Qtde. de Licença é Obrigatório.<br />";
    }
    else {
        //Se o campo Valor Total estiver vazio... preenche msg de obrigatório
        if ($.trim($("#txtLicTotal").val()) == "") {
            vMsg += "- Ocorreu um erro no cálculo. Contate o Administrador.<br />";
        }
        else {
            if ($("#lstLicVigencia option:selected").val() == "C") {
                if (parseInt($("#txtLicQtde").val()) > 1) {
                    vMsg += "- A cortesia é cedido apenas para 1 licença.<br />";
                }
            }
            else {
                if ($("#lstLicVigencia option:selected").val() == "D") {
                    if (parseInt($("#txtLicQtde").val()) > 1) {
                        vMsg += "- A cortesia é cedido apenas para 1 licença.<br />";
                    }
                }
            }
        }
    }

    //Se o campo Qtde Tablet estiver vazio ... preenche com 0
    if ($.trim($("#txtLicQtdeTablet7").val()) == "") {
        $("#txtLicQtdeTablet7").val("0");
    }

    //Se o campo Qtde Suporte Mesa estiver vazio ... preenche com 0
    if ($.trim($("#txtLicQtdeSupMesa7").val()) == "") {
        $("#txtLicQtdeSupMesa7").val("0");
    }

    //Se o campo Qtde Tablet estiver vazio ... preenche com 0
    if ($.trim($("#txtLicQtdeTablet10").val()) == "") {
        $("#txtLicQtdeTablet10").val("0");
    }

    //Se o campo Qtde Suporte Mesa estiver vazio ... preenche com 0
    if ($.trim($("#txtLicQtdeSupMesa10").val()) == "") {
        $("#txtLicQtdeSupMesa10").val("0");
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgClienteLicenca').html(vMsg);

        return false;
    }

    return true;
}
function ValidaPreenchimentoStatus() {

    //Será usado para armazenar as msgs obrigatórias
    var vMsg = '';

    //Se selecionado Pago... preenche data de pagamento
    if ($("#lstStatusSitPag option:selected").val() == "PAGO") {
        if ($.trim($("#txtStatusPagtoData").val()) == "") {
            vMsg = "- Data é Obrigatório quando a situação for PAGO.<br />";
        }
    }
    else {
        //Limpa o Campo quando não for selecionado Pago
        $("#txtStatusPagtoData").val('');
    }

    //Se selecionado Pago... preenche data de pagamento
    if ($("#lstStatusSitPagComissao option:selected").val() == "PAGO") {
        if ($.trim($("#txtStatusPagtoDataComissao").val()) == "") {
            vMsg = "- Data é Obrigatório quando a situação for PAGO.<br />";
        }
    }
    else {
        //Limpa o Campo quando não for selecionado Pago
        $("#txtStatusPagtoDataComissao").val('');
    }

    //Se a div de alerta estiver visível...
    if (vMsg != "") {

        //Mostra a msg campo obrigatório
        $('#divMsgStatus').html(vMsg);

        return false;
    }

    return true;
}

//Limpa Campos dos Formulários
function LimparForm()
{
    $('#txtUserSenha').val('');
    $('#txtUserConfirma').val('');
    $('#divMsgUser').html('');

    $('#divMsgVlrLicenca').html('');
}
function LimpaFormCliente()
{
    $('#txtCodCliente').val('');
    $('#txtCliNome').val('');
    $('#txtCliResp').val('');
    $('#txtCliEmail').val('');
    $('#txtCliTel').val('');
    $('#txtCliEnd').val('');
    $('#txtCliCid').val('');
    $("#lstCliUF").val('SP');
    $('#txtCliCEP').val('');
    $("#lstCliPessoa").val('J');
    $('#txtCliDoc').val('');

    //Habilita campo de Nome e Email
    $("#txtCliNome").prop("disabled", false);
    $("#txtCliEmail").prop("disabled", false);

    //Reseta cor dos campos desabilitados
    document.getElementById('txtCliNome').style.color = '#e53c19;';
    document.getElementById('txtCliEmail').style.color = '#e53c19;';
}
function LimpaFormUsers()
{
    $('#txtCodUsers').val('');
    $('#txtUsersNome').val('');
    $('#txtUsersEmail').val('');
    $('#txtUsersDoc').val('');
    $('#txtUsersTel').val('');
    $('#txtUsersEnd').val('');
    $('#txtUsersCid').val('');
    $("#lstUsersPessoa").val('F');
    $("#lstUsersPerfil").val('Representante');
    $("#lstUsersSit").val('S');
    $("#lstUsersUF").val('SP');
    $('#txtUsersPer').val('');
    $('#txtUsersPerDisp').val('');

    //Habilita campo Email
    $("#txtUsersEmail").prop("disabled", false);

    //Reseta cor do campo Email
    document.getElementById('txtUsersEmail').style.color = '#e53c19;';
}
function LimpaFormClienteLicenca() {
    $('#txtLicChave').val('');
    $('#lstLicVigencia').val('T');
    $('#txtLicQtde').val('');
    $('#txtLicQtdeTablet7').val('');
    $('#txtLicQtdeSupMesa7').val('');
    $('#txtLicQtdeTablet10').val('');
    $('#txtLicQtdeSupMesa10').val('');
    $("#txtLicTotal").val('');
    $("#hdTxtVlrLicenca").val('0');
    $("#hdTxtVlrDispositivo").val('0');
    $('#txtLicClienteOculto').val('');
    $('#txtLicObservacaoLicenca').val('');
    
    // Obtém a data/hora atual
    var data = new Date();

    //Soma quantidade de dias da vigência trimestral
    data.setDate(data.getDate() + 10);
    $("#txtLicVigInicio").val(data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear());

    //Soma quantidade de dias da vigência trimestral
    data.setDate(data.getDate() + 90);
    $("#txtLicVigTermino").val(data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear());
}
function LimpaFormExtrato()
{
    $('#txtExtChave').val('');
    $('#txtExtNome').val('');
    $('#txtExtResp').val('');
    $('#lstExtVigencia').val('T');
    $('#txtExtVigInicio').val('');
    $('#txtExtVigTermino').val('');
    $('#txtExtPagtoSitLicenca').val('');
    $('#txtExtPagtoSitPagto').val('');
    $('#txtExtPagtoData').val('');
    $('#txtExtVlrLicenca').val('');
    $('#txtExtPerComLicenca').val('');
    $('#txtExtVlrComLicenca').val('');
    $('#txtExtVlrDisp').val('');
    $('#txtExtPerComDisp').val('');
    $('#txtExtVlrComDisp').val('');
    $('#txtExtComSituacao').val('');
    $('#txtExtComPagoEm').val('');
    $('#txtExtComVlrTotal').val('');
}

//Desabilitar Formulário
function DisabledFormLicenca(pDisabled)
{
    if (pDisabled == true)
    {
        $("#lstLicVigencia").prop("disabled", true);
        $("#txtLicQtde").prop("disabled", true);
        $("#txtLicQtdeTablet7").prop("disabled", true);
        $("#txtLicQtdeSupMesa7").prop("disabled", true);
        $("#txtLicQtdeTablet10").prop("disabled", true);
        $("#txtLicQtdeSupMesa10").prop("disabled", true);
        $("#txtLicObservacaoLicenca").prop("disabled", true);

        document.getElementById('lstDivLicCliente').style.display = 'none';
        document.getElementById('txtLicClienteOculto').style.display = 'block';
    }
    else
    {
        $("#lstLicVigencia").prop("disabled", false);
        $("#txtLicQtde").prop("disabled", false);
        $("#txtLicQtdeTablet7").prop("disabled", false);
        $("#txtLicQtdeSupMesa7").prop("disabled", false);
        $("#txtLicQtdeTablet10").prop("disabled", false);
        $("#txtLicQtdeSupMesa10").prop("disabled", false);
        $("#txtLicObservacaoLicenca").prop("disabled", false);

        document.getElementById('lstDivLicCliente').style.display = 'block';
        document.getElementById('txtLicClienteOculto').style.display = 'none';
    }
}

//Mostra Campos para Inclusão de Novos Registros
function MostrarDetalheCliente(pObjeto) {

    //Esconde a lista e detalhe do cliente
    document.getElementById('divGridClienteList').style.display = 'none';
    document.getElementById('divGridClienteEdit').style.display = 'none';

    //Limpa Mensagem
    $('#divMsgCliente').html('');

    //Limpa Formulário
    LimpaFormCliente();

    //Mostra somente o que foi escolhido pelo usuário    
    ShowObjeto(pObjeto, 'block');
}
function MostrarDetalheUsers(pObjeto) {

    //Esconde a lista e detalhe do cliente
    document.getElementById('divGridUsersList').style.display = 'none';
    document.getElementById('divGridUsersEdit').style.display = 'none';

    //Limpa Mensagem
    $('#divMsgUsers').html('');
    $('#divMsgUsersList').html('');

    //Limpa Formulário
    LimpaFormUsers();

    //Mostra somente o que foi escolhido pelo usuário    
    ShowObjeto(pObjeto, 'block');
}
function MostrarDetalheClienteLicenca(pObjeto, pNovoRegistro) {

    //Esconde a lista e detalhe da Licenca
    document.getElementById('divGridLicencaList').style.display = 'none';
    document.getElementById('divGridLicencaEdit').style.display = 'none';

    //Limpa Mensagem
    $('#divMsgClienteLicenca').html('');

    //Limpa Formulário
    LimpaFormClienteLicenca();

    //Habilita Formulario
    DisabledFormLicenca(false);

    //Mostra somente o que foi escolhido pelo usuário    
    ShowObjeto(pObjeto, 'block');

    if (pNovoRegistro == 'N') {
        //Mostra os campos de pagamento para visualização do registro de ClienteLicença
        document.getElementById('divStatusClienteLicenca').style.display = 'block';

        //Esconde o botão Salvar
        document.getElementById('divBotaoClienteLicenca').style.display = 'none';
    }
    else {
        //Esconde os campos de pagamento para novo registro de ClienteLicença
        document.getElementById('divStatusClienteLicenca').style.display = 'none';

        //Mostra o botão Salvar
        document.getElementById('divBotaoClienteLicenca').style.display = 'block';
    }
}
function MostrarDetalheStatus(pObjeto) {

    //Esconde a lista e detalhe do Status
    document.getElementById('divGridStatusList').style.display = 'none';
    document.getElementById('divGridStatusEdit').style.display = 'none';

    //Limpa Mensagem
    $('#divMsgStatus').html('');

    //Limpa Formulário
    LimpaFormClienteLicenca();

    //Mostra somente o que foi escolhido pelo usuário    
    ShowObjeto(pObjeto, 'block');
}
function MostrarDetalheExtrato(pObjeto) {

    //Esconde a lista e detalhe do Status
    document.getElementById('divGridExtratoList').style.display = 'none';
    document.getElementById('divGridExtratoEdit').style.display = 'none';

    //Limpa Mensagem
    $('#divMsgExtrato').html('');

    //Limpa Formulário
    LimpaFormExtrato();

    //Mostra somente o que foi escolhido pelo usuário    
    ShowObjeto(pObjeto, 'block');
}

//Mostra Dados dos Registros para Alteração
function EditarDadosCliente(pObjeto, pCliente)
{
    //Esconde a lista e mostra o formulário do cliente
    MostrarDetalheCliente(pObjeto);

    //Desabilita campo de Nome e Email
    $("#txtCliNome").prop("disabled", true);
    $("#txtCliEmail").prop("disabled", true);

    //Altera a cor dos campos desabilitados
    document.getElementById('txtCliNome').style.color = '#CCCCCC';
    document.getElementById('txtCliEmail').style.color = '#CCCCCC';

    //Carrega o formulário com os dados do cliente
    CarregaDadosCliente(pCliente);
}
function EditarDadosUsers(pObjeto, pUsers) {

    //Esconde a lista e mostra o formulário do usuário
    MostrarDetalheUsers(pObjeto);

    //Desabilita campo de Nome e Email
    $("#txtUsersEmail").prop("disabled", true);

    //Altera a cor dos campos desabilitados
    document.getElementById('txtUsersEmail').style.color = '#CCCCCC';

    //Carrega o formulário com os dados do usuários
    CarregaDadosUsers(pUsers);
}
function EditarDadosClienteLicenca(pObjeto, pUsers) {

    //Esconde a lista e mostra o formulário do Cliente Licenca
    MostrarDetalheClienteLicenca(pObjeto, 'N');

    //Desabilita Formulario
    DisabledFormLicenca(true);

    //Carrega o formulário com os dados do ClienteLicenca
    CarregaDadosClienteLicenca(pUsers);
}
function EditarDadosStatus(pObjeto, pUsers) {

    //Esconde a lista e mostra o formulário do status
    MostrarDetalheStatus(pObjeto);

    //Carrega o formulário com os dados do Status
    CarregaDadosStatus(pUsers);
}
function EditarDadosExtrato(pObjeto, pClienteLicenca)
{
    //Esconde a lista e mostra o formulário do status
    MostrarDetalheExtrato(pObjeto);

    //Carrega o formulário com os dados do Status
    CarregaDadosExtrato(pClienteLicenca);
}

//Calculo da Licenca
function CalculaVigencia()
{
    // Obtém a data/hora atual
    var data = new Date();

    //Soma quantidade de dias da vigência
    if ($("#lstLicVigencia option:selected").val() == "T") {
        data.setDate(data.getDate() + 100);

        $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ ' + $("#txtLicVlrLicenca3").val() + '</b>)');
    }

    if ($("#lstLicVigencia option:selected").val() == "S") {
        data.setDate(data.getDate() + 190);

        $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ ' + $("#txtLicVlrLicenca6").val() + '</b>)');   
    }

    if ($("#lstLicVigencia option:selected").val() == "A") {
        data.setDate(data.getDate() + 375);

        $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ ' + $("#txtLicVlrLicenca12").val() + '</b>)');
    }

    if ($("#lstLicVigencia option:selected").val() == "C") {
        data.setDate(data.getDate() + 40);

        $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ 0,00</b>)');
    }

    if ($("#lstLicVigencia option:selected").val() == "D") {
        data.setDate(data.getDate() + 70);

        $('#divLstPrecoLicenca').html('Qtde. Licença: (<b>R$ 0,00</b>)');
    }

    //Preenche o campo com término da vigência
    $("#txtLicVigTermino").val(data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear());

    //Calcula Valor Total Licenca
    CalculaValorTotalLicenca();
}
function CalculaValorTotalLicenca()
{
    //Valida o Preenchimento Qtde Licenca
    var QtdeLicenca = 0
    if ($("#txtLicQtde").val() != ""){
        QtdeLicenca = $("#txtLicQtde").val();
        QtdeLicenca = QtdeLicenca.replace('.', '');
    }

    //Valida o Preenchimento Qtde Tablet 7
    var QtdeTablet_7 = 0
    if ($("#txtLicQtdeTablet7").val() != "") {
        QtdeTablet_7 = $("#txtLicQtdeTablet7").val();
        QtdeTablet_7 = QtdeTablet_7.replace('.', '');
    }

    //Valida o Preenchimento Qtde Sup Mesa 7
    var QtdeSupMesa_7 = 0
    if ($("#txtLicQtdeSupMesa7").val() != ""){
        QtdeSupMesa_7 = $("#txtLicQtdeSupMesa7").val();
        QtdeSupMesa_7 = QtdeSupMesa_7.replace('.', '');
    }

    //Valida o Preenchimento Qtde Tablet 10
    var QtdeTablet_10 = 0
    if ($("#txtLicQtdeTablet10").val() != "") {
        QtdeTablet_10 = $("#txtLicQtdeTablet10").val();
        QtdeTablet_10 = QtdeTablet_10.replace('.', '');
    }

    //Valida o Preenchimento Qtde Sup Mesa 10
    var QtdeSupMesa_10 = 0
    if ($("#txtLicQtdeSupMesa10").val() != "") {
        QtdeSupMesa_10 = $("#txtLicQtdeSupMesa10").val();
        QtdeSupMesa_10 = QtdeSupMesa_10.replace('.', '');
    }

    //Valida o Preenchimento Valor Tablet 7
    var VlrTablet_7 = 0
    if ($("#txtLicVlrTablet7").val() != "")
        VlrTablet_7 = $("#txtLicVlrTablet7").val();

    //Valida o Preenchimento Valor Sup Mesa 7
    var VlrSupMesa_7 = 0
    if ($("#txtLicVlrSupMesa7").val() != "")
        VlrSupMesa_7 = $("#txtLicVlrSupMesa7").val();

    //Valida o Preenchimento Valor Tablet 10
    var VlrTablet_10 = 0
    if ($("#txtLicVlrTablet10").val() != "")
        VlrTablet_10 = $("#txtLicVlrTablet10").val();

    //Valida o Preenchimento Valor Sup Mesa 10
    var VlrSupMesa_10 = 0
    if ($("#txtLicVlrSupMesa10").val() != "")
        VlrSupMesa_10 = $("#txtLicVlrSupMesa10").val();

    //Pega o Valor da Vigência
    var VlrVigencia = 0;

    //Pega o Valor de 3 Meses
    if($("#lstLicVigencia option:selected").val() == 'T')
        VlrVigencia = $("#txtLicVlrLicenca3").val();

    //Pega o Valor de 6 Meses
    if ($("#lstLicVigencia option:selected").val() == 'S')
        VlrVigencia = $("#txtLicVlrLicenca6").val();

    //Pega o Valor de 12 Meses
    if ($("#lstLicVigencia option:selected").val() == 'A'){
        VlrVigencia = $("#txtLicVlrLicenca12").val();
    }

    //Pega o Valor da Cortesia 30 Dias
    if ($("#lstLicVigencia option:selected").val() == 'C') {
        VlrVigencia = "0";
    }

    //Pega o Valor da Cortesia 60 Dias
    if ($("#lstLicVigencia option:selected").val() == 'D') {
        VlrVigencia = "0";
    }

    //Calcula o valor da Licença
    VlrVigencia = VlrVigencia.replace(',', '.');
    var VlrTotalLicenca = parseFloat(QtdeLicenca) * parseFloat(VlrVigencia);

    //Calcula o valor do Tablet 7
    VlrTablet_7 = VlrTablet_7.replace(',', '.');
    var VlrTotalTablet_7 = parseFloat(QtdeTablet_7) * parseFloat(VlrTablet_7);

    //Calcula o valor do Suporte de Mesa 7
    VlrSupMesa_7 = VlrSupMesa_7.replace(',', '.');
    var VlrTotalSupMesa_7 = parseFloat(QtdeSupMesa_7) * parseFloat(VlrSupMesa_7);

    //Calcula o valor do Tablet 10
    VlrTablet_10 = VlrTablet_10.replace(',', '.');
    var VlrTotalTablet_10 = parseFloat(QtdeTablet_10) * parseFloat(VlrTablet_10);

    //Calcula o valor do Suporte de Mesa 10
    VlrSupMesa_10 = VlrSupMesa_10.replace(',', '.');
    var VlrTotalSupMesa_10 = parseFloat(QtdeSupMesa_10) * parseFloat(VlrSupMesa_10);

    //Guarda Valor da Licenca
    $("#hdTxtVlrLicenca").val(VlrTotalLicenca);

    //Guarda Valor do Dispostivo
    $("#hdTxtVlrDispositivo").val((parseFloat(VlrTotalTablet_7) + parseFloat(VlrTotalSupMesa_7) + parseFloat(VlrTotalTablet_10) + parseFloat(VlrTotalSupMesa_10)));

    //Calcula Valor Total
    var VlrTotal = parseFloat(VlrTotalLicenca) + parseFloat(VlrTotalTablet_7) + parseFloat(VlrTotalSupMesa_7) + parseFloat(VlrTotalTablet_10) + parseFloat(VlrTotalSupMesa_10);

    //Alimenta Campo com Valor Total
    $("#txtLicTotal").val((VlrTotal).toFixed(2));

}