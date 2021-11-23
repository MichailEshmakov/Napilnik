using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public abstract class Expander<T, T1>
    {
        private readonly Expander<T, T1> _successor;

        public Expander(Expander<T, T1> successor = null) => _successor = successor;

        public T Expand(T current, T1 args)
        {
            if (_successor != null)
                return _successor.Expand(Concat(current, GetInheritedExpanding(args)), args);
            else
                return Concat(current, GetInheritedExpanding(args));
        }

        abstract protected T GetInheritedExpanding(T1 args);

        abstract protected T Concat(T current, T adding);
    }
}
