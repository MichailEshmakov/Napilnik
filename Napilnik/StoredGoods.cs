using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class StoredGoods
    {
        private readonly Dictionary<Good, int> _countByGood;

        public StoredGoods()
        {
            _countByGood = new Dictionary<Good, int>();
        }

        public void Add(Good good, int count)
        {
            Validate(good, count);

            if (_countByGood.ContainsKey(good))
                _countByGood[good] = _countByGood[good] + count;
            else
                _countByGood.Add(good, count);
        }

        public KeyValuePair<Good, int> Give(Good good, int count)
        {
            if (Has(good, count) == false)
                throw new InvalidOperationException();

            _countByGood[good] -= count;

            return new KeyValuePair<Good, int>(good, count);
        }

        public bool Has(Good good, int count)
        {
            Validate(good, count);
            return _countByGood.ContainsKey(good) && _countByGood[good] <= count;
        }

        public IReadOnlyDictionary<Good, int> GetAll()
        {
            return _countByGood;
        }

        private void Validate(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
