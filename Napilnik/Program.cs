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
            //Выведите платёжные ссылки для трёх разных систем платежа: 
            //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}

            Order order = new Order(1, 12000, "RUS", "01010100");
            IHasher md5Hasher = new MD5Hasher();
            IHasher sha1Hasher = new Sha1Hasher();

            //1
            LinkHashExpander linkHashExpander1 = new LinkHashOrderIdExpander();
            LinkParamsExpander linkParamsExpander1 = new LinkParamsOrderAmountAndCurrencyExpander();
            LinkHashBuilder linkHashBuilder1 = new LinkHashBuilder(md5Hasher, linkHashExpander1);
            LinkParamsBuilder linkParamsBuilder1 = new LinkParamsBuilder(linkParamsExpander1);
            PaymentSystem paymentSystem1 = new PaymentSystem("pay.system1.ru/order", linkHashBuilder1, linkParamsBuilder1);
            string payingLink1 = paymentSystem1.GetPayingLink(order);
            Console.WriteLine(payingLink1);

            //2
            LinkHashExpander linkHashExpander2 = new LinkHashOrderIdExpander(new LinkHashOrderAmountExpander());
            LinkHashBuilder linkHashBuilder2 = new LinkHashBuilder(md5Hasher, linkHashExpander2);
            LinkParamsBuilder linkParamsBuilder2 = new LinkParamsBuilder();
            PaymentSystem paymentSystem2 = new PaymentSystem("order.system2.ru/pay", linkHashBuilder2, linkParamsBuilder2);
            string payingLink2 = paymentSystem2.GetPayingLink(order);
            Console.WriteLine(payingLink2);

            //3
            LinkHashExpander linkHashExpander3 = new LinkHashOrderAmountExpander(new LinkHashOrderIdExpander(new LinkHashSecretKeyExpander()));
            LinkParamsExpander linkParamsExpander3 = new LinkParamsOrderAmountExpander(new LinkParamsOrderCurrencyExpander());
            LinkHashBuilder linkHashBuilder3 = new LinkHashBuilder(sha1Hasher, linkHashExpander3);
            LinkParamsBuilder linkParamsBuilder3 = new LinkParamsBuilder(linkParamsExpander3);
            PaymentSystem paymentSystem3 = new PaymentSystem("system3.com/pay", linkHashBuilder3, linkParamsBuilder3);
            string payingLink3 = paymentSystem3.GetPayingLink(order);
            Console.WriteLine(payingLink3);

            Console.ReadLine();
        }
    }
}
