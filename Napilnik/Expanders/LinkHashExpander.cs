using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public abstract class LinkHashExpander : Expander<string, Order>
    {
        public LinkHashExpander(Expander<string, Order> successor = null) : base(successor)
        {
        }

        protected override string GetInheritedExpanding(Order order)
        {
            return "";
        }

        protected sealed override string Concat(string current, string adding)
        {
            return current + adding;
        }
    }
}
