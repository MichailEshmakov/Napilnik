using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Order
    {
        public readonly int Id;
        public readonly int Amount;
        public readonly string Currency;
        public readonly string SecretKey;

        public Order(int id, int amount, string currency = null, string secretKey = null) => (Id, Amount, Currency, SecretKey) = (id, amount, currency, secretKey);
    }
}
