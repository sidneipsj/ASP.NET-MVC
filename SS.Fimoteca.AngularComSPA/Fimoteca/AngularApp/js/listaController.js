(function (app) {
    var listaController = function ($scope, $http) {

        $http.get("/api/filme")
              .success(function (data) {
                  $scope.filmes = data;
              });
    };

    app.controller("listaController", listaController)

}(angular.module("filmoteca", [])))