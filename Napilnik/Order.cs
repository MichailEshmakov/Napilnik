using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Order
    {
        private readonly StoredGoods _goods;

        public Order(StoredGoods storedGoods)
        {
            if (storedGoods == null)
                throw new ArgumentNullException(nameof(storedGoods));

            _goods = storedGoods;
            Paylink = "";
        }

        public string Paylink { get; private set; }
    }
}
