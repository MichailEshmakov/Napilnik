using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Cell: IReadonlyCell
    {
        private readonly Good _good;

        public Cell(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _good = good;
            Count = count;
        }

        public Good Good => _good;
        public int Count { get; private set; }

        public void Merge(Cell other)
        {
            if (other.Good != Good)
                throw new InvalidOperationException();

            Count += other.Count;
        }

        public Cell Detach(int count)
        {
            if (count < 0 || count > Count)
                throw new ArgumentOutOfRangeException(nameof(count));

            Count -= count;
            return new Cell(_good, count);
        }
    }

    interface IReadonlyCell
    {
        int Count { get; }
        Good Good { get; }
    }
}
