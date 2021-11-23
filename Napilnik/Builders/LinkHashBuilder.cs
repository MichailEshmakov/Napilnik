using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class LinkHashBuilder : Builder<string, Order>
    {
        private readonly IHasher _hasher;

        public LinkHashBuilder(IHasher hasher, LinkHashExpander hashExpander) : base(hashExpander)
        {
            if (hasher == null)
                throw new ArgumentNullException(nameof(hasher));

            if (hashExpander == null)
                throw new ArgumentNullException(nameof(hashExpander));

            _hasher = hasher;
        }

        public override string Build(Order order)
        {
            return _hasher.ComputeHash(Expander.Expand(string.Empty, order));
        }
    }
}
