using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class LinkHashSecretKeyExpander : LinkHashExpander
    {
        public LinkHashSecretKeyExpander(Expander<string, Order> successor = null) : base(successor)
        {
        }

        protected override string GetInheritedExpanding(Order order)
        {
            return order.SecretKey;
        }
    }
}
