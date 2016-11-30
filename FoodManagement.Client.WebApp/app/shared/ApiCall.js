foodManagementApp.factory('ApiCall', function ApiCall($http) {
    return {
        GetApiCall: function (url) {
            var result;
            result = $http.get('http://localhost:55079/api/' + url).success(function (data, status) {
                result = (data);
            }).error(function () {
                alert("something went wrong");
            });
            return result;
        }
    };
});
//# sourceMappingURL=ApiCall.js.map