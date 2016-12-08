/// <reference path="../typings/angularjs/angular.d.ts" />

'use strict';

//export default angular.module('app', []);

var foodManagementApp = angular.module('FoodManagement', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/shoplist',
            {
                templateUrl: '/app/components/shoppinglist/shoppinglist.html',
                controller: 'ShoppingListController'
            })
            .when('/',
            {
                templateUrl: '/app/components/home/home.html',
                controller: 'HomeController'
            })
            .when('/shoppinglistitemname',
            {
                templateUrl: '/app/components/shoppinglistitemname/shoppinglistitemname.html'
            })
        // $routeProvider.otherwise({ redirectTo: '/' });
        $locationProvider.html5Mode(true);
    })
    ;
