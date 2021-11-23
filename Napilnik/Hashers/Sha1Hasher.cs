using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Sha1Hasher : IHasher
    {
        public string ComputeHash(string value)
        {
            return $"Sha-1-of({value})";
        }
    }
}
