/// <reference path="../../shared/ShoppingListItem.ts" />
'use strict';
foodManagementApp.controller('ShoppingListController', function ShoppingListController($scope, $window, $rootScope, ShoppingListService, GoogleImageSearch) {
    var originalShoppingList;
    ShoppingListService.GetAllItems().success(function (data) {
        $scope.shoppingList = data;
        originalShoppingList = angular.copy(data, originalShoppingList);
    });
    $scope.CheckForChange = function (item) {
        var elementPos = originalShoppingList.map(function (x) {
            return x.id;
        }).indexOf(item.id);
        var origItem = originalShoppingList[elementPos];
        if (origItem == undefined || item.name != origItem.name || item.description != origItem.description || item.amount != origItem.amount || item.store != origItem.store)
            item.changed = true;
        else
            item.changed = false;
    };
    $scope.NewItem = function () {
        var item = new ShoppingListItem('Item', 1);
        var objectFound = $scope.shoppingList.map(function (x) {
            return x.id;
        }).indexOf('0');
        if (objectFound == -1)
            $scope.shoppingList.push(item);
    };
    $scope.Update = function (item) {
        var result;
        //var image = GoogleImageSearch.Search(item.name);
        if (item.id == '0')
            result = ShoppingListService.Post(item);
        else
            result = ShoppingListService.Update(item);
        result.success(function () {
            item.changed = false;
        });
    };
    $scope.SaveChanges = function () {
        for (var _i = 0, _a = $scope.shoppingList; _i < _a.length; _i++) {
            var item = _a[_i];
            if (item.changed) {
                $scope.Update(item);
            }
        }
    };
    //$window.onbeforeunload =  $scope.onExit;
    $scope.$on('$destroy', $scope.SaveChanges);
    $('body').bind('beforeunload', function () {
        $scope.SaveChanges;
    });
    $window.onbeforeunload = function () {
        // handle the exit event
        $scope.SaveChanges;
    };
    $(window).bind('beforeunload', function () {
        //save info somewhere
        $scope.SaveChanges;
    });
    // $scope.$on("$locationChangeStart", $scope.onExit);
    // $(window).unload(function() {
    //   alert('Handler for .unload() called.');
    // });
});
//# sourceMappingURL=ShoppingListController.js.map