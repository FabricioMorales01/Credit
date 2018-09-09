var app = angular.module('app', [
    'ngRoute'
]);

//Añade aquí las constantes 

app.config(['$routeProvider', function ($routeProvider) {
    //En este bloque config solo se configuran las rutas

    $routeProvider.when('/', {
        templateUrl: 'main.html',
        controller: 'MainController'
    });

    $routeProvider.otherwise({
        redirectTo: '/'
    });
}])