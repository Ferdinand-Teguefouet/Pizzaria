namespace PizzariaASP.services
{
    public interface IMailService
    {
        bool SendEmail(string sub, string message, params string[] toList);
    }
}