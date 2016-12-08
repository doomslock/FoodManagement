class ShoppingListItem
{
    public id: string;
    public name: string;
    public amount: number;
    public store: string;
    public description: string;
    public changed: boolean;

    public constructor(name: string, amount: number)
    {
        this.id = '0';
        this.name = name;
        this.amount = amount;
    }
}