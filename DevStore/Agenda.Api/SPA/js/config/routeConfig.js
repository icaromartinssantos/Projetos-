angular.module("listaTelefonica").config(function ($routeProvider) {



    $routeProvider.when("/", {
        templateUrl: "index.html",
        controller: "listaTelefonicaController",
        resolve: {
            contatos: function (contatosAPI) {
                return contatosAPI.getContatos();
            },
            operadoras: function (operadoraAPI) {
                return operadoraAPI.getOperadora();
            }
        }

    }).when("/novoContato", {
        templateUrl: "novoContato.html",
        controller: "novoContatoController",
        resolve: {
            operadoras: function (operadoraAPI) {
                return operadoraAPI.getOperadora();
            }
        }
    }).when("/detalhesContato/:id", {
        templateUrl: "detalhesContato.html",
        controller: "detalhesContatoController",
        resolve: {
            contato: function (contatosAPI, $route) {
                return contatosAPI.getContato($route.current.params.id);
            }
        }
        });

    $routeProvider.when("/error", {

        templateUrl: "error.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });

});

