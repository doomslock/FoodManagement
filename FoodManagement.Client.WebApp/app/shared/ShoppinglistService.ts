foodManagementApp.factory('ShoppingListService', function ShoppingListService(ApiCall) {
    return {
        GetAllItems: function () {
            return ApiCall.GetApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a');
        }
    };
})