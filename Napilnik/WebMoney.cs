using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class WebMoney : IPaymentSystem
    {
        public event Action<bool, IPaymentSystem> PaymentChecked;

        public string Name => "WebMoney";

        public void CallApi()
        {
            Console.WriteLine("Вызов API WebMoney...");
        }

        public void CkeckPayment()
        {
            Console.WriteLine("Проверка платежа через WebMoney...");
            PaymentChecked?.Invoke(true, this);
        }
    }
}
