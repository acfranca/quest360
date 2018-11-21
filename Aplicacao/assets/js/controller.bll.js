function ControlSecao(DivID) {

    //Limpa formulário
    LimparForm();

    //Seta formulário cliente
    MostrarDetalheCliente('divGridClienteList');

    //Seta formulário licenca
    MostrarDetalheClienteLicenca('divGridLicencaList');

    //Seta formulário Extrato
    MostrarDetalheExtrato('divGridExtratoList');

    //Seta formulário Status
    MostrarDetalheStatus('divGridStatusList');

    //Seta formulário usuário
    MostrarDetalheUsers('divGridUsersList');

    //Pega todos os divs da página Index
    var divs = document.getElementsByTagName('section');

    //Para cada div encontrado...
    for (var i = divs.length; i--;) {

        //Pega os atributos do div
        var div = divs[i];

        //Verifique se o div em questão tem a class _Conteudo
        if (div.className === 'two') {
            //Oculta o div que tem a class _Conteudo
            div.style.display = 'none';
        }
    }

    //Mostra a div e imagem do Menu selecionado
    document.getElementById(DivID).style.display = 'block';
}

function ShowObjeto(pObjeto, pAcao) {
    document.getElementById(pObjeto).style.display = pAcao;
}
