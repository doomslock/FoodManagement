foodManagementApp.factory('ApiCall', function ApiCall($http) {
    return {
        GetApiCall: function (url:string) {
            var result;
            result = $http.get('http://localhost:55079/api/' + url).success(function (data, status) {
                result = (data);
            }).error(function () {
                alert("something went wrong");
                });
            return result;
        },
        PutApiCall: function (url:string, item:ShoppingListItem){
            var result;
            result = $http.put('http://localhost:55079/api/' + url, item).success(function (data, status) {
                result = (data);
            }).error(function () {
                alert("something went wrong");
                });
            return result;
        },
        PostApiCall: function (url:string, item:ShoppingListItem){
            var result;
            result = $http.post('http://localhost:55079/api/' + url, item).success(function (data, status) {
                result = (data);
            }).error(function () {
                alert("something went wrong");
                });
            return result;
        } 
    };
})