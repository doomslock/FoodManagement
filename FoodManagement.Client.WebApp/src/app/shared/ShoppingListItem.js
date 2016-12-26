var ShoppingListItem = (function () {
    function ShoppingListItem(name, amount) {
        this.id = '0';
        this.name = name;
        this.amount = amount;
        this.show = true;
    }
    return ShoppingListItem;
}());
var PatchDoc = (function () {
    function PatchDoc(op, path, value) {
        this.op = op;
        this.path = path;
        this.value = value;
    }
    return PatchDoc;
}());
//# sourceMappingURL=ShoppingListItem.js.map