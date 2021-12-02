using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Napilnik
{
    public class OrderForm
    {
        private const string _availableSystemsScrollHeader = "Мы принимаем:";
        private const string _availableSystemsScrollDelimiter = ",";
        private const string _systemChoosingQuestion = "Какой системой вы хотите совершить оплату?";
        private const string _unavailableSystemMessageFirst = "Система ";
        private const string _unavailableSystemMessageSecond = " недоступна";

        public IPaymentSystem ShowForm(IReadOnlyList<IPaymentSystem> availableSystems)
        {
            string availableSystemsScroll = GenerateAvailableSystemsScroll(availableSystems);
            IPaymentSystem chosenSystem = null;

            while (chosenSystem == null)
            {
                Console.WriteLine(availableSystemsScroll);
                string chosenSystemName = AskPaymentSystem();
                chosenSystem = availableSystems.FirstOrDefault(system => system.Name == chosenSystemName);
                TryWriteSystemUnavailability(chosenSystem != null, chosenSystemName);
            }

            return chosenSystem;
        }

        private string GenerateAvailableSystemsScroll(IReadOnlyList<IPaymentSystem> availableSystems)
        {
            string scroll = _availableSystemsScrollHeader;
            for (int i = 0; i < availableSystems.Count; i++)
            {
                scroll += $" {availableSystems[i].Name}";
                if (i < availableSystems.Count - 1)
                    scroll += _availableSystemsScrollDelimiter;
            }

            return scroll;
        }

        private string AskPaymentSystem()
        {
            Console.WriteLine(_systemChoosingQuestion);
            return Console.ReadLine();
        }

        private void TryWriteSystemUnavailability(bool isAvailable, string system)
        {
            if (isAvailable == false)
                Console.WriteLine($"{_unavailableSystemMessageFirst}{system}{_unavailableSystemMessageSecond}");
        }
    }
}
