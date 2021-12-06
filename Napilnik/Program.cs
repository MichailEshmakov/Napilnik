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
            IReadOnlyList<IReadonlyCell> warehouseGoods = warehouse.GetGoods();
            Console.WriteLine("Товары на складе:");
            Output.ShowGoods(warehouseGoods);

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            //cart.Add(iPhone11, 3); // При такой ситуации возникает ошибка так, как нет нужного количества товара на складе.

            // Вывод всех товаров в корзине.
            IReadOnlyList<IReadonlyCell> cardGoods = cart.GetGoods();
            Console.WriteLine("Товары в корзине:");
            Output.ShowGoods(cardGoods);

            Console.WriteLine(cart.Order().Paylink);

            Console.ReadLine();
        }
    }

    public static class Output
    {
        public static void ShowGoods(IReadOnlyList<IReadonlyCell> cells)
        {
            foreach (IReadonlyCell cell in cells)
            {
                Console.WriteLine($"{cell.Good.Name}: {cell.Count}");
            }
        }
    }
}
