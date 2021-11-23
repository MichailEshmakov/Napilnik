using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class PaymentSystem : IPaymentSystem
    {
        private string _paylinkBase;
        private LinkHashBuilder _hashBuilder;
        private LinkParamsBuilder _paramsBuilder;

        public PaymentSystem(string paylinkBase, LinkHashBuilder hashBuilder, LinkParamsBuilder paramsBuilder)
        {
            _paylinkBase = paylinkBase;
            _hashBuilder = hashBuilder;
            _paramsBuilder = paramsBuilder;
        }

        public string GetPayingLink(Order order)
        {
            string hash = _hashBuilder.Build(order);
            Dictionary<string, string> parameters = _paramsBuilder.Build(order);

            return new PaymentLink(_paylinkBase, hash, parameters).ToString();
        }
    }
}
