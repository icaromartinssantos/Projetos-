angular.module("listaTelefonica").directive("uiAlert", function (config) {

    return {

        templateUrl: config.baseUrl + "/SPA/view/alert.html",
        replace: true,
        restrict: "AE",
        scope: {
            title: "@"
        },
        transclude: true 
    };
});