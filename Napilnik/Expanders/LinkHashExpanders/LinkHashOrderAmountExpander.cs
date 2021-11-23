using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class LinkHashOrderAmountExpander : LinkHashExpander
    {
        public LinkHashOrderAmountExpander(Expander<string, Order> successor = null) : base(successor)
        {
        }

        protected override string GetInheritedExpanding(Order order)
        {
            return order.Amount.ToString();
        }
    }
}
