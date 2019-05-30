using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardRegistration.Services
{
    public class CardValidationService : ICardValidationService
    {
        string _cardNumber;
        public CardValidationService(string CardNumber)
        {
            _cardNumber = CardNumber;
        }

        public bool ValidCardNumber()
        {
            return _cardNumber.Length == 16 && _cardNumber.All(c => char.IsDigit(c));
        }

        public bool PassesLuhnTest()
        {
            return PerformLuhnTest() == 0;
        }

        private int PerformLuhnTest()
        {
            var reversedCardNumber = new string(_cardNumber.Reverse().ToArray()).ToCharArray();
            int s1 = 0;
            int s2 = 0;

            for(int i = 0; i < reversedCardNumber.Count(); i++)
            {
                var digit = (int)char.GetNumericValue(reversedCardNumber[i]);

                if (i % 2 == 0) // if index is odd
                {
                    s1 += digit;
                }
                else // index is even
                {                    
                    var multipliedEvenPositionCharBy2 = digit * 2;
                    var sumOfDigits = (multipliedEvenPositionCharBy2.ToString().ToList()).Select(c => (int)char.GetNumericValue(c)).Sum();
                    s2 += sumOfDigits;
                }
            }
            return (s1 + s2) % 10;           
        }
    }
}
