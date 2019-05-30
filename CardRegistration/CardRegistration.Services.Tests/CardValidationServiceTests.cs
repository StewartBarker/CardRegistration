using NUnit.Framework;
using CardRegistration.Services;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LuhnCheckPassesForValidCardNumber()
        {
            var cardNumber = "7787222366651242";
            ICardValidationService cardValidationService = new CardValidationService(cardNumber);
            var result = cardValidationService.PassesLuhnTest();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void LuhnCheckFailsForInvalidCardNumber()
        {
            var cardNumber = "7787222266651242";
            ICardValidationService cardValidationService = new CardValidationService(cardNumber);
            var result = cardValidationService.PassesLuhnTest();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CardNumberIsInvalidIfContainsLetters()
        {
            var cardNumber = "77872223a6651242";
            ICardValidationService cardValidationService = new CardValidationService(cardNumber);
            var result = cardValidationService.ValidCardNumber();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CardNumberIsInvalidIfLessThan16Digits()
        {
            var cardNumber = "778722";
            ICardValidationService cardValidationService = new CardValidationService(cardNumber);
            var result = cardValidationService.ValidCardNumber();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CardNumberIsInvalidIfMoreThan16Digits()
        {
            var cardNumber = "7787222333366651242";
            ICardValidationService cardValidationService = new CardValidationService(cardNumber);
            var result = cardValidationService.ValidCardNumber();
            Assert.AreEqual(false, result);
        }
    }
}