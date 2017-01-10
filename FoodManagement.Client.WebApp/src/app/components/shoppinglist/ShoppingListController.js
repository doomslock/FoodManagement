/// <reference path="../../shared/ShoppingListItem.ts" />
'use strict';
foodManagementApp.controller('ShoppingListController', function ShoppingListController($scope, $window, $rootScope, ShoppingListService) {
    $scope.searchTerm = "";
    $scope.glued = false;
    var originalShoppingList;
    ShoppingListService.GetAllItems().then(function (data) {
        $scope.shoppingList = data;
        originalShoppingList = angular.copy(data, originalShoppingList);
        for (var _i = 0, _a = $scope.shoppingList; _i < _a.length; _i++) {
            var item = _a[_i];
            item.show = true;
        }
        $scope.SearchTermChanged();
    });
    $scope.NameChanged = function (item) {
        ShoppingListService.GetDescriptionForItemName(item.name).then(function (data) {
            if (data != null && data.concat.length > 0)
                item.description = data;
            $scope.CheckForChange(item);
        }, function () {
            $scope.CheckForChange(item);
        });
    };
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
        $scope.glued = true;
        var item = new ShoppingListItem('Item', 1);
        var objectFound = $scope.shoppingList.map(function (x) {
            return x.id;
        }).indexOf('0');
        if (objectFound == -1)
            $scope.shoppingList.push(item);
    };
    $scope.Update = function (item) {
        var result;
        if (item.id == '0')
            result = ShoppingListService.Post(item);
        else
            result = ShoppingListService.Update(item);
        result.then(function (data) {
            item.amount = data.amount;
            item.id = data.id;
            item.description = data.description;
            item.store = data.store;
            item.name = data.name;
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
    $scope.SearchTermChanged = function () {
        var term = $scope.searchTerm;
        if (term.concat.length > 0) {
            for (var _i = 0, _a = $scope.shoppingList; _i < _a.length; _i++) {
                var item = _a[_i];
                if (item.name.indexOf(term) >= 0)
                    item.show = true;
                else
                    item.show = false;
            }
        }
        else {
            for (var _b = 0, _c = $scope.shoppingList; _b < _c.length; _b++) {
                var item = _c[_b];
                item.show = true;
            }
        }
    };
    $scope.MarkBought = function (item) {
        ShoppingListService.MarkBought(item.id).then(function () {
            var index = $scope.shoppingList.indexOf(item);
            if (index > -1) {
                $scope.shoppingList.splice(index, 1);
            }
            index = -1;
            originalShoppingList.some(function (el, i) {
                if (el.id === item.id) {
                    index = i;
                    return true;
                }
            });
            if (index > -1) {
                originalShoppingList.splice(index, 1);
            }
        });
    };
    $scope.MarkAllAsBought = function () {
        ShoppingListService.MarkAllBought().then(function () {
            $scope.shoppingList.splice(0, $scope.shoppingList.length);
            originalShoppingList.splice(0, originalShoppingList.length);
        });
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
        $scope.SaveChanges;
    });
    // $scope.$on("$locationChangeStart", $scope.onExit);
    // $(window).unload(function() {
    //   alert('Handler for .unload() called.');
    // });
});
//# sourceMappingURL=ShoppingListController.js.map