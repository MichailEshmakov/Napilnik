using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Order
    {
        private readonly CellList _cells;

        public Order(CellList cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            _cells = cells;
            Paylink = "";
        }

        public string Paylink { get; private set; }
    }
}
