using Event.Domain;

namespace Event.Application.Interfaces
{
    public interface IUserService
    {
        User RegisterUser(string username, string password, string email);
        User Authenticate(string username, string password);
        User GetUserById(int id);
    }
}