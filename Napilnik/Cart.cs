using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Cart
    {
        private readonly Shop _shop;
        private readonly StoredGoods _storedGoods;

        public Cart(Shop shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _shop = shop;
            _storedGoods = new StoredGoods();
        }

        public void Add(Good good, int count)
        {
            _storedGoods.Add(good, count);
        }

        public void Return(Good good, int count)
        {
            KeyValuePair<Good, int> retugningGoods = _storedGoods.Give(good, count);
            _shop.Return(retugningGoods.Key, retugningGoods.Value);
        }

        public Order Order()
        {
            return new Order(_storedGoods);
        }

        public IReadOnlyDictionary<Good, int> GetGoods()
        {
             return _storedGoods.GetAll();
        }
    }
}
