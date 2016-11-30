'use strict';
var foodManagementApp = angular.module('FoodManagement', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/shoplist', {
        templateUrl: '/app/components/shoppinglist/shoppinglist.html',
        controller: 'ShoppingListController'
    })
        .when('/', {
        templateUrl: '/app/components/home/home.html',
        controller: 'HomeController'
    });
    $routeProvider.otherwise({ redirectTo: '/' });
    $locationProvider.html5Mode(true);
});
//# sourceMappingURL=app.js.map