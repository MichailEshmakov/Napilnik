using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Cart
    {
        private readonly Shop _shop;
        private readonly CellList _cells;

        public Cart(Shop shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _shop = shop;
            _cells = new CellList();
        }

        public void Add(Good good, int count)
        {
            Cell newCell = _shop.ReserveGoods(good, count);
            _cells.Add(newCell);
        }

        public void Return(Good good, int count)
        {
            Cell retugningGoods = _cells.Give(good, count);
            _shop.ReturnGoods(retugningGoods);
        }

        public Order Order()
        {
            return new Order(_cells);
        }



        public void Output()
        {
            IReadOnlyList<IReadonlyCell> outputableCells = _cells.GetAll();
            // Выводит по-корзиночи
        }
    }
}
