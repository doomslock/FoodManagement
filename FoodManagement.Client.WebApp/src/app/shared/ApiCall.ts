﻿foodManagementApp.factory('ApiCall', function ApiCall($http) {
    return {
        GetApiCall: function (url: string) {
            return $http.get('http://localhost:55079/api/' + url).then(function (response, status) {
                return (response.data);
            }, function () {
                alert("something went wrong");
            });
        },
        PutApiCall: function (url: string, item: ShoppingListItem) {
            return $http.put('http://localhost:55079/api/' + url, item).then(function (response, status) {
                return (response.data);
            }, function () {
                alert("something went wrong");
            });
        },
        PostApiCall: function (url: string, item: ShoppingListItem) {
            return $http.post('http://localhost:55079/api/' + url, item).then(function (response, status) {
                return (response.data);
            }, function () {
                alert("something went wrong");
            });
        },
        PatchApiCall: function (url: string, patchDoc) {
            return $http.patch('http://localhost:55079/api/' + url, patchDoc).then(function (response, status) {
                return (response.data);
            }, function () {
                alert("something went wrong");
            });
        }
    };
})