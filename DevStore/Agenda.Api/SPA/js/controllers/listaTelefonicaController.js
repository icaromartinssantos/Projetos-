angular.module("listaTelefonica").controller("listaTelefonicaController", function ($scope, $filter, contatos){
                    $scope.app = "Lista Telefonica";
                    $scope.contatos = contatos.data;
    
                    $scope.apagarContatos = function (contatos) {

                       contatos.filter(function (contato) {
                          if (contato.selecionado)
                          {
                              contatosAPI.deleteContatos(contato.iDcontato).then(function (response) {
                                  delete $scope.contato;
                                  carregarContatos();
                              });
                          }
                      });  
                    };

                    $scope.isContatoSelecionado = function(contatos){
                        
                        return contatos.some(function (contato) {
                            return contato.selecionado;
                        });
                        
                    };

                    $scope.ordenarPor = function(campo){

                        $scope.criterioDeOrdenacao = campo;
                        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
                    }

           
                  
            });