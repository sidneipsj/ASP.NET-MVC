(function (app) {

    var detalhesController = function ($scope, $routeParams, filmeService) {
        var id = $routeParams.id;
        filmeService
            .getFilmePorId(id)
            .success(function (data) {
                $scope.filme = data;
            });

        $scope.editar = function () {
            $scope.editar.filme = angular.copy($scope.filme);
        };
    };

        app.controller("detalhesController", detalhesController);

}(angular.module("filmoteca")));