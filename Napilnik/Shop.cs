using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(this);
        }

        public KeyValuePair<Good, int> ReserveGoods(Good good, int count)
        {
            return _warehouse.Reserve(good, count);
        }

        internal void Return(Good good, int count)
        {
            _warehouse.Return(good, count);
        }
    }
}
