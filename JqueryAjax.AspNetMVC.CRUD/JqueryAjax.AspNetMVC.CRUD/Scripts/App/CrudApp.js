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
    //com a função serialize(), pegamos todo o objeto do formulario e transformamos em uma string em serie
    var dadosSerializados = $('#formDados').serialize();

    //inicializamos o AJAX
    //por padrao ele recebe JSON portanto nao é preciso informar
    $.ajax({
        //informamos o tipo de solicitacao (GET, POST, PUT, DELETE)
        type: "POST",
        //url para onde enviaremos os dados
        url: "/App/Cadastrar",
        //os parametros que serao enviados por parametro, no nosso caso é o objeto PessoaModel que temos no formulario
        //a partir dos names, ele reconhece que é daquele objeto.
        data: dadosSerializados,
        success: function () {
            //caso tudo de certo, exibe a mensagem
            alert("Cadastrado com Sucesso!");
            //chamamos o metodo de listagem dos objetos
            //Listar();
        },
        error: function () {
            alert("Error!");
        }

    });

}