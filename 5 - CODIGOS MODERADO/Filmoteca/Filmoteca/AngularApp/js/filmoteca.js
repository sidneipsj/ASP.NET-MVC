(function () {

    var app = angular.module("filmoteca", ["ngRoute"]);

    var config = function ($routeProvider) {

        $routeProvider
        .when("/",
               { templateUrl: "/cliente/html/lista.html"})
        .when("/detalhes/:id",
               { templateUrl: "/cliente/html/detalhes.html"})
        .otherwise(
               { redirecTo: "/"});
    };
    app.config(config);
    //inclusão
    app.constant("filmeApiUrl", "/api/filme/");
}());
