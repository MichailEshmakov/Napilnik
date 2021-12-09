using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            // Вывод всех товаров на складе с их остатком.
            IReadOnlyDictionary<Good, int> warehouseGoods = warehouse.GetGoods();
            Console.WriteLine("Товары на складе:");
            Output.ShowGoods(warehouseGoods);

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            //cart.Add(iPhone11, 3); // При такой ситуации возникает ошибка так, как нет нужного количества товара на складе.

            Console.WriteLine();
            // Вывод всех товаров в корзине.
            IReadOnlyDictionary<Good, int> cardGoods = cart.GetGoods();
            Console.WriteLine("Товары в корзине:");
            Output.ShowGoods(cardGoods);

            Console.WriteLine(cart.Order().Paylink);

            Console.ReadLine();
        }
    }

    public static class Output
    {
        public static void ShowGoods(IReadOnlyDictionary<Good, int> countByGood)
        {
            foreach (Good good in countByGood.Keys)
            {
                Console.WriteLine($"{good.Name}: {countByGood[good]}");
            }
        }
    }
}
