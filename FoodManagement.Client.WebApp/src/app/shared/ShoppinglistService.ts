foodManagementApp.factory('ShoppingListService', function ShoppingListService(ApiCall) {
    return {
        GetAllItems: function () {
            return ApiCall.GetApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a');
        },
        Update: function(item: ShoppingListItem) {
            return ApiCall.PutApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a/items/'+item.id, item);
        },
        Post: function(item: ShoppingListItem) {
            return ApiCall.PostApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a/items/', item);
        },
        GetNames: function(searchTerm: string){
            return ApiCall.GetApiCall('itemnames?q="' + searchTerm + '"');
        },
        GetDescriptionForItemName : function(searchTerm: string){
            return ApiCall.GetApiCall('description?q="' + searchTerm + '"');
        },
        MarkBought : function(itemId: string)
        {
            let patchdoc = new PatchDoc("replace","/IsBought","true");
            let item = new Array(patchdoc);
            return ApiCall.PatchApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a/items/'+itemId, item);
        },
        MarkAllBought : function()
        {
            let patchdoc = new PatchDoc("replace","/AreBought","true");
            let item = new Array(patchdoc);
            return ApiCall.PatchApiCall('shoppinglists/65a5fff3-cd22-4212-8bcf-c8112e3d2b7a/items/', item);
        }
    };
})