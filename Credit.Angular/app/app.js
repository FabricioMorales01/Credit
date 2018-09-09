var config = {
    urlServer: "http://localhost:59548/CreditService.svc/"
}

var app = angular.module('app', [
    'ngRoute',
    'ngMaterial', 'ngMessages'
]);

//Añade aquí las constantes 

app.config(['$routeProvider', '$sceDelegateProvider', function($routeProvider, $sceDelegateProvider){
    //En este bloque config solo se configuran las rutas

    $routeProvider.when('/', {
        templateUrl: 'app/views/debtorList.html',
        controller: 'DebtorController'
    });

    $routeProvider.when('/create', {
        templateUrl: 'app/views/saveDebtor.html',
        controller: 'DebtorController'
    });

    $routeProvider.when('/update/:id', {
        templateUrl: 'app/views/saveDebtor.html',
        controller: 'DebtorController'
    });

    $routeProvider.otherwise({
        redirectTo: '/'
    });

  

    //lista
    $sceDelegateProvider.resourceUrlWhitelist([
        // Allow same origin resource loads.
        'self',
        // Allow loading from our assets domain.  Notice the difference between * and **.
        config.urlServer + '*'
    ]);
}])