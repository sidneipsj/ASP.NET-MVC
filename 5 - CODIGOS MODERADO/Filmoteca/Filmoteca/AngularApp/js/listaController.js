(function (app) {

    var listaController = function ($scope, filmeService)
    {
        filmeService
            .getFilmes()
            .success(function (data) {
            $scope.filmes = data;
            });

        $scope.criar = function () {
            $scope.editar = {
                filme: {
                    Titulo: "",
                    Duracao: 0,
                    AnoLancamento: new Date().getFullYear()
                }
            };
        };

        $scope.deleta = function (filme) {
            filmeService.deletar(filme)
            .success(function () {
                removerFilmePorId(filme.Id);
            });
        };

        var removerFilmePorId = function (id) {
            for (var i = 0; i < $scope.filmes.length; i++) {
                if ($scope.filmes[i].Id == id) {
                    $scope.filmes.splice(i, 1);
                    break;
                }
            }
        };
    };

    app.controller("listaController", listaController)

}(angular.module("filmoteca")));