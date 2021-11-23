using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class LinkParamsBuilder : Builder<Dictionary<string, string>, Order>
    {
        public LinkParamsBuilder(LinkParamsExpander paramsExpander = null) : base(paramsExpander) { }

        public override Dictionary<string, string> Build(Order order)
        {
            if (Expander != null)
                return Expander.Expand(new Dictionary<string, string>(), order);
            else
                return new Dictionary<string, string>();
        }
    }
}
