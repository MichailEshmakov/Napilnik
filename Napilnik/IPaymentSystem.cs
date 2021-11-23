using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public interface IPaymentSystem
    {
        string GetPayingLink(Order order);
    }
}
