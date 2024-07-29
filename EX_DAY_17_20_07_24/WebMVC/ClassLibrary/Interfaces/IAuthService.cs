namespace ClassLibrary.Interfaces
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password);
    }
}
