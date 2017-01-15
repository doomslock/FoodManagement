/// <reference path="../../shared/ShoppingListItem.ts" />

'use strict';
/* Make more generic so that it can also be used for stores*/
foodManagementApp.directive('filterList', function () {
    return {
        restrict: 'E',
        scope: {
            item: '=item',
            blur: '&blur'
        },
        templateUrl: '/app/components/filterlist/filterlist.html',
        controller: ['$scope', 'ShoppingListService', function ($scope, ShoppingListService) {
            $scope.SelectedItem = function (name: string) {
                $scope.item.name = $scope.selected;
                $scope.selected = "";
            }

            $scope.Search = function (searchTerm: string) {
                if (searchTerm.length > 1) {
                    ShoppingListService.GetNames(searchTerm).then(function (data: string[]) {
                        if (data.indexOf(searchTerm) == -1)
                            data.push(searchTerm);
                        $scope.found = data;
                    });
                } else
                    $scope.found = [];
            }

            $scope.Blur = function(){
                if(!$('#name'+$scope.item.id+' select').is(':focus') && !$('#name'+$scope.item.id+' input').is(':focus'))
                    $scope.blur($scope.item);
            }
        }]

    }
});