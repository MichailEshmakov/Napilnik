using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public abstract class Builder<T, T1>
    {
        public Builder(Expander<T, T1> expander = null) => Expander = expander;

        protected Expander<T, T1> Expander { get; private set; }

        abstract public T Build(T1 args);
    }
}
