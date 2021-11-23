using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class LinkParamsOrderCurrencyExpander : LinkParamsExpander
    {
        public LinkParamsOrderCurrencyExpander(Expander<Dictionary<string, string>, Order> successor = null) : base(successor)
        {
        }

        protected override string GetKey(Order order)
        {
            return nameof(order.Currency).ToLower();
        }

        protected override string GetValue(Order order)
        {
            return order.Currency;
        }
    }
}
