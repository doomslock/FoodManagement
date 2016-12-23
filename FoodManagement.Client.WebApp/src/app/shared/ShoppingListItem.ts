class ShoppingListItem
{
    public id: string;
    public name: string;
    public amount: number;
    public store: string;
    public description: string;
    public changed: boolean;
    public show: boolean;

    public constructor(name: string, amount: number)
    {
        this.id = '0';
        this.name = name;
        this.amount = amount;
        this.show = true;
    }
}

class PatchDoc{
    public op: string;
    public path: string;
    public value: string;
    public constructor(op: string, path: string, value:string)
    {
        this.op = op;
        this.path = path;
        this.value = value;
    }
}