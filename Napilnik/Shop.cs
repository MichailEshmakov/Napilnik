using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Shop
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

        public Cell ReserveGoods(Good good, int count)
        {
            return _warehouse.Reserve(good, count);
        }

        internal void ReturnGoods(Cell retugningGoods)
        {
            _warehouse.Return(retugningGoods);
        }
    }
}
