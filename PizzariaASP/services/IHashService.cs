namespace PizzariaASP.services
{
    public interface IHashService
    {
        string Hash(string passaword, string salt = null);
    }
}