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
        static void Main(string[] args)
        {
            ShoppinglistService shoplistService = new DependencyConfiguration().GetInstance<IShoppinglistService>() as ShoppinglistService;

            var shoppinglist = shoplistService.GetFamilyShoppinglist(Guid.Parse("D38A4709-4D0A-434B-905B-1ADACB7B015E"));
            foreach (var s in shoppinglist)
            {
                System.Console.WriteLine(s.Name + " - " + s.Amount);
            }
            System.Console.ReadKey();
        }
    }
}
