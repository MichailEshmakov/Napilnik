using System;

namespace Napilnik
{
    public class PaymentHandler
    {
        private const string _paymentMessage = "Вы оплатили с помощью ";
        private const string _successfulPaymentMessage = "Оплата прошла успешно!";
        private const string _failedPaymentMessage = "Ошибка оплаты!";

        private void ShowPaymentResult(bool isPaymentSuccessful, IPaymentSystem system)
        {
            Console.WriteLine($"{_paymentMessage}{system.Name}");
            if(isPaymentSuccessful)
                Console.WriteLine(_successfulPaymentMessage);
            else
                Console.WriteLine(_failedPaymentMessage);
        }

        public void WaitPaymentResult(IPaymentSystem system)
        {
            system.PaymentChecked += ShowPaymentResult;
        }
    }
}
