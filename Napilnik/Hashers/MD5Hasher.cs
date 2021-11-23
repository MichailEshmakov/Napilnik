using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class MD5Hasher : IHasher
    {
        public string ComputeHash(string value)
        {
            return $"MD5-of({value})";
        }
    }
}
