using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class Warehouse
    {
        private readonly StoredGoods _storedGoods;

        public Warehouse()
        {
            _storedGoods = new StoredGoods();
        }

        public void Delive(Good good, int count)
        {
            _storedGoods.Add(good, count);
        }

        public KeyValuePair<Good, int> Reserve(Good good, int count)
        {
            return _storedGoods.Give(good, count);
        }

        public bool AreAvailable(Good good, int count)
        {
            return _storedGoods.Has(good, count);
        }

        public void Return(Good good, int count)
        {
            _storedGoods.Add(good, count);
        }

        public IReadOnlyDictionary<Good, int> GetGoods()
        {
            return _storedGoods.GetAll();
        }
    }
}
