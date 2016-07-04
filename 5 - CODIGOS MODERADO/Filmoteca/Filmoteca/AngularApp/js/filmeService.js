(function (app) {
     
    var filmeService = function ($http, filmeApiUrl) {
        
        var getFilmes = function() {
            return $http.get(filmeApiUrl);
        };

        var getFilmePorId = function (id) {
            return $http.get(filmeApiUrl + id);
        };

        var atualizar = function (filme) {
            return $http.put(filmeApiUrl + filme.Id, filme);
        };

        var criar = function (filme) {
            return $http.post(filmeApiUrl, filme);
        };

        var deletar = function (filme) {
            return $http.delete(filmeApiUrl + filme.Id);
        };

        return {
            getFilmes: getFilmes,
            getFilmePorId: getFilmePorId,
            atualizar: atualizar,
            criar: criar,
            deletar: deletar
        };
    };

    app.factory("filmeService", filmeService);

}(angular.module("filmoteca")))