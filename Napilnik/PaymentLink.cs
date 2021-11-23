using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class PaymentLink
    {
        private readonly string _adress;
        private readonly string _hash;
        private readonly Dictionary<string, string> _parameters;

        public PaymentLink(string adress, string hash, Dictionary<string, string> parameters = null)
        {
            if (adress == null)
                throw new ArgumentNullException(nameof(adress));

            if (hash == null)
                throw new ArgumentNullException(nameof(hash));

            _adress = adress;
            _hash = hash;
            _parameters = parameters;
        }

        public override string ToString()
        {
            string parameters = "";
            if (_parameters != null)
                foreach (string parameterKey in _parameters.Keys)
                {
                    parameters += $"{parameterKey}={_parameters[parameterKey]}&";
                }

            return $"{_adress}?{parameters}hash={_hash}";
        }
    }
}
