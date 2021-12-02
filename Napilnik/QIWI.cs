using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class QIWI : IPaymentSystem
    {
        public event Action<bool, IPaymentSystem> PaymentChecked;

        public string Name => "QIWI";

        public void CallApi()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
        }

        public void CkeckPayment()
        {
            Console.WriteLine("Проверка платежа через QIWI...");
            PaymentChecked?.Invoke(true, this);
        }
    }
}
