using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var paymentHandler = new PaymentHandler();
            IReadOnlyCollection<IPaymentSystem> paymentSystems = new List<IPaymentSystem> { new QIWI(), new WebMoney(), new Card() };

            IPaymentSystem paymentSystem = orderForm.ShowForm(paymentSystems.ToList());
            paymentHandler.WaitPaymentResult(paymentSystem);
            paymentSystem.CallApi();
            paymentSystem.CkeckPayment();

            Console.ReadLine();
        }
    }
}
