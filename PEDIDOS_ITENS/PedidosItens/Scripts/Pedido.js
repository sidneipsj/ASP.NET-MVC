function SalvarPedido() {

    debugger; //Fazer o debug da aplicação em tempo de execução

    var data = $("#Data").val();

    var cliente = $("#Cliente").val();

    var valor = $("Valor").val();

    //Esta opção foi necessário criar por causa do
    //ValidateAntiForeignToken na definição do método /Pedido/Create
    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    //Variavel da url que vai de pedido a create
    var url = "/Pedido/Create";
    $.ajax({
        url: url //Pra onde 
        , type: "POST" //Como vai
        , datatype: "json" //De que forma vai
        , headers: headersadr
        , data: { Id: 0, Data: data, Cliente: cliente, Valor: valor, __RequestVerificationToken: token }
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    });
}

function ListarItens(idPedido) {

    var url = "/Itens/ListarItens";

    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idPedido }
        , datatype: "html"
        , success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });

}


function SalvarItens() {

    debugger;
    var quantidade = $("#Quantidade").val();
    var produto = $("#Produto").val();
    var valorunitario = $("#ValorUnitario").val();
    var idPedido = $("#idPedido").val();

    var url = "/Itens/SalvarItens";

    $.ajax({
        url: url
        , data: { quantidade: quantidade, produto: produto, valorunitario: valorunitario, idPedido: idPedido }
        , type: "GET"
        , datatype: "html"
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(idPedido);
            }
        }
    });




}