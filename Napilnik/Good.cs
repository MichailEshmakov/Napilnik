using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Good
    {
        private readonly string _name;

        public Good(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
