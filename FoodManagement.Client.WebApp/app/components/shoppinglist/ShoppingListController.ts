'use strict';

foodManagementApp.controller('ShoppingListController', function ShoppingListController($scope, ShoppingListService) {
    
    ShoppingListService.GetAllItems().success(function (data) {
        $scope.shoppingList = data;
    });

});