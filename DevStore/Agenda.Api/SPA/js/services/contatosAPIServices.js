angular.module("listaTelefonica").factory("contatosAPI", function ($http, config) {
    var _getContatos = function () {
        return $http.get(config.baseUrl + "/api/v1/public/contato");
    };

    var _getContato = function (id) {
        return $http.get(config.baseUrl + "/api/v1/public/contato/" + id);
    };

    var _saveContatos = function (contato) {
        return $http.post(config.baseUrl + "/api/v1/public/contato", contato);
    };

    var _deleteContatos = function (iDcontato) {
        return $http.delete(config.baseUrl + "/api/v1/public/contato?iDcontato=" + iDcontato);
    };

    return {
        getContatos: _getContatos,
        getContato: _getContato,
        saveContatos: _saveContatos,
        deleteContatos: _deleteContatos
    };

});