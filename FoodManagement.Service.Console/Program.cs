using FoodManagement.Core;
using FoodManagement.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Service.Console
{
    class Program
    {
        static void Main()
        {
            ShoppinglistService shoplistService = new DependencyConfiguration().GetInstance<IShoppingListService>() as ShoppinglistService;

            var shoppinglist = shoplistService.GetFamilyShoppingList(Guid.Parse("65A5FFF3-CD22-4212-8BCF-C8112E3D2B7A"));
            foreach (var s in shoppinglist)
            {
                System.Console.WriteLine($"{s.Item.Name} - {s.Amount}");
            }
            System.Console.ReadKey();
        }
    }
}
