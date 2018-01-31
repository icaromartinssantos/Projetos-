angular.module("listaTelefonica").controller("novoContatoController", function ($scope, $filter, contatosAPI, $location, operadoras) {
    
    $scope.operadoras = operadoras.data;

    $scope.adicionarContato = function (contato) {

        contatosAPI.saveContatos(contato).then(function (response) {
            delete $scope.contato;
            $scope.contatoForm.$setPristine();
            $location.path("/");
        });

    };

});