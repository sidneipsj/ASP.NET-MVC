function LimparFormulario() {
    $("formDados").each(function () {
        this.reset();
    });
}

//Recebe a classe css para o tipo, seja sucesso ou erro.
// passamos como parâmetro SUCCESS(para sucesso) ou DANGER(para erro),
//conforme o bootstrap
function Mensagem(stringCss, mensagem) {
    //caso exista uma mensagem, ele remove
    $("#mensagem").remove();

    //serve para limitar um tempo para aparecer a nova mensagem
    setTimeout(function () {
        //serve este passo pode não ser a melhor abortagem,
        //fazemos assim, para que tenha uma familharidade maior com o JQuery.
        $('#formDados').append("<div class='alert alert-" + stringCss + "' id=mensagem role=alert>" + mensagem + "</div>");
    }, 10);
}

function Cadastrar() {
    var dadosSerializados = $("formDados").serialize();
}