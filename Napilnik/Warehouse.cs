using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Warehouse
    {
        private readonly CellList _cells;

        public Warehouse()
        {
            _cells = new CellList();
        }

        public void Delive(Good good, int count)
        {
            Cell newCell = new Cell(good, count);
            _cells.Add(newCell);
        }

        public Cell Reserve(Good good, int count)
        {
            return _cells.Give(good, count);
        }

        public bool AreAvailable(Good good, int count)
        {
            return _cells.Has(good, count);
        }

        public void Return(Cell retugningGoods)
        {
            _cells.Add(retugningGoods);
        }

        public void Output()
        {
            IReadOnlyList<IReadonlyCell> outputableCells = _cells.GetAll();
            // Выводит по-складски
        }


    }
}
