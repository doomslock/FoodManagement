/// <reference path="../../shared/ShoppingListItem.ts" />
'use strict';
foodManagementApp.directive('shoppingItemName', function () {
    return {
        restrict: 'E',
        scope: {
            item: '=item',
            blur: '&blur'
        },
        templateUrl: '/app/components/shoppingitemname/shoppingitemname.html',
        controller: ['$scope', 'ShoppingListService', function ($scope, ShoppingListService) {
                $scope.SelectedItemName = function (name) {
                    $scope.item.name = $scope.selected;
                };
                $scope.Search = function (searchTerm) {
                    if (searchTerm.length > 1) {
                        ShoppingListService.GetNames(searchTerm).success(function (data) {
                            if (data.indexOf(searchTerm) == -1)
                                data.push(searchTerm);
                            $scope.found = data;
                        });
                    }
                    else
                        $scope.found = [];
                };
                $scope.Blur = function () {
                    if (!$('#name' + $scope.item.id + ' select').is(':focus') && !$('#name' + $scope.item.id + ' input').is(':focus'))
                        $scope.blur($scope.item);
                };
            }]
    };
});
//# sourceMappingURL=shoppingitemnameDirective.js.map