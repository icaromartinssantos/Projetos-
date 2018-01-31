angular.module("listaTelefonica").service("operadoraAPI", function ($http, config) {

   this.getOperadora = function () {
        return $http.get(config.baseUrl + "/api/v1/public/operadora");
    };

 

});