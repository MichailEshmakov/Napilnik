using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public abstract class LinkParamsExpander : Expander<Dictionary<string, string>, Order>
    {
        public LinkParamsExpander(Expander<Dictionary<string, string>, Order> successor = null) : base(successor)
        {
        }

        protected sealed override Dictionary<string, string> Concat(Dictionary<string, string> current, Dictionary<string, string> adding)
        {
            Dictionary<string, string> newDictionary = new Dictionary<string, string>(current.Count + adding.Count);
            return current.Union(adding).ToDictionary(x => x.Key, x => x.Value);
        }

        protected sealed override Dictionary<string, string> GetInheritedExpanding(Order order)
        {
            string key = GetKey(order);
            string value = GetValue(order);
            Dictionary<string, string> result = new Dictionary<string, string>(1);
            result.Add(key, value);
            return result;
        }

        abstract protected string GetValue(Order order);

        abstract protected string GetKey(Order order);
    }
}
