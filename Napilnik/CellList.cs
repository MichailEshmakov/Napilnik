using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class CellList
    {
        private readonly List<Cell> _cells;

        public CellList()
        {
            _cells = new List<Cell>();
        }

        public void Add(Cell newCell)
        {
            Cell existingCell = _cells.FirstOrDefault(cell => cell.Good == newCell.Good);
            if (existingCell != null)
                existingCell.Merge(newCell);
            else
                _cells.Add(newCell);
        }

        public Cell Give(Good good, int count)
        {
            Cell existingCell = _cells.FirstOrDefault(cell => cell.Good == good);
            if (existingCell == null)
                throw new ArgumentException(nameof(good));

            return existingCell.Detach(count);
        }

        public bool Has(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Cell existingCell = _cells.FirstOrDefault(cell => cell.Good == good);
            if (existingCell == null)
                return false;

            return existingCell.Count > count;
        }

        public IReadOnlyList<IReadonlyCell> GetAll()
        {
            return _cells;
        }
    }
}
