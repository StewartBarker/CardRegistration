namespace CardRegistration.Services
{
    public interface ICardValidationService
    {
        bool PassesLuhnTest();
        bool ValidCardNumber();
    }
}