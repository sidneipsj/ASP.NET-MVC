(function (app) {

var editaController = function ($scope, filmeService) {
    
    $scope.isEditavel = function () {
        return $scope.editar && $scope.editar.filme;
    };

    $scope.cancelar = function () {
        $scope.editar.filme = null;
    };

    $scope.salvar = function () {
        if ($scope.editar.filme.Id) {
            atualizaFilme();
        } else {
            criaFilme();
        }
    };

    var atualizaFilme = function () {
        filmeService.atualizar($scope.editar.filme)
        .success(function() {
            angular.extend($scope.filme , $scope.editar.filme);
            $scope.editar.filme = null;
        });
    };

    var criaFilme = function () {
        filmeService.criar($scope.editar.filme)
        .success(function(filme) {
            $scope.filmes.push(filme);
            $scope.editar.filme = null;
        });
    };
  };

app.controller("editaController", editaController);

}(angular.module("filmoteca")));