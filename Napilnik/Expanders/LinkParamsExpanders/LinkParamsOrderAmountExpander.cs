using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class LinkParamsOrderAmountExpander : LinkParamsExpander
    {
        public LinkParamsOrderAmountExpander(Expander<Dictionary<string, string>, Order> successor = null) : base(successor)
        {
        }

        protected override string GetKey(Order order)
        {
            return nameof(order.Amount).ToLower();
        }

        protected override string GetValue(Order order)
        {
            return order.Amount.ToString();
        }
    }
}
