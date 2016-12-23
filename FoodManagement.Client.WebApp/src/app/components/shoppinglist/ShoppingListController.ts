/// <reference path="../../shared/ShoppingListItem.ts" />

'use strict';

foodManagementApp.controller('ShoppingListController', function ShoppingListController($scope, $window, $rootScope, ShoppingListService) {
    $scope.searchTerm = "";
    $scope.glued = false;

    let originalShoppingList;
    ShoppingListService.GetAllItems().then(function (data: ShoppingListItem[]) {
        $scope.shoppingList = data;
        originalShoppingList = angular.copy(data, originalShoppingList);

        for (let item of $scope.shoppingList) {
            item.show = true;
        }

        $scope.SearchTermChanged();
    });

    $scope.NameChanged = function (item: ShoppingListItem) {
        ShoppingListService.GetDescriptionForItemName(item.name).then(function(data: string){
            if(data != null && data.concat.length > 0)
                item.description = data;
            $scope.CheckForChange(item);
        }, function(){
            $scope.CheckForChange(item);
        });
        
    }

    $scope.CheckForChange = function (item: ShoppingListItem) {
        let elementPos = originalShoppingList.map(function (x) {
            return x.id;
        }).indexOf(item.id);
        let origItem = originalShoppingList[elementPos];
        if (origItem == undefined || item.name != origItem.name || item.description != origItem.description || item.amount != origItem.amount || item.store != origItem.store)
            item.changed = true;
        else
            item.changed = false;
    };

    $scope.NewItem = function () {
        $scope.glued = true;
        let item = new ShoppingListItem('Item', 1);
        let objectFound = $scope.shoppingList.map(function (x) {
            return x.id;
        }).indexOf('0');
        if (objectFound == -1)
            $scope.shoppingList.push(item);
    }

    $scope.Update = function (item: ShoppingListItem) {
        let result;
        if (item.id == '0')
            result = ShoppingListService.Post(item);
        else
            result = ShoppingListService.Update(item);
        result.then(function (data: ShoppingListItem) {
            item.amount = data.amount;
            item.id = data.id;
            item.description = data.description;
            item.store = data.store;
            item.name = data.name;
            item.changed = false;
        });
    }

    $scope.SaveChanges = function () {
        for (let item of $scope.shoppingList) {
            if (item.changed) {
                $scope.Update(item)
            }
        }
    }

    $scope.SearchTermChanged = function () {
        let term: string = $scope.searchTerm;
        if (term.concat.length > 0) {
            for (let item of $scope.shoppingList) {
                if (item.name.indexOf(term) >= 0)
                    item.show = true;
                else
                    item.show = false;
            }
        } else {
            for (let item of $scope.shoppingList) {
                item.show = true;
            }
        }
    }
    $scope.MarkBought = function(item: ShoppingListItem){
        ShoppingListService.MarkBought(item.id);
    }

    $scope.MarkAllAsBought = function(){
        ShoppingListService.MarkAllBought();
    }

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