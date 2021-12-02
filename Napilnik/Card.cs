using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Card : IPaymentSystem
    {
        public event Action<bool, IPaymentSystem> PaymentChecked;

        public string Name => "Card";

        public void CallApi()
        {
            Console.WriteLine("Вызов API банка эмитера карты Card...");
        }

        public void CkeckPayment()
        {
            Console.WriteLine("Проверка платежа через Card...");
            PaymentChecked?.Invoke(true, this);
        }
    }
}
