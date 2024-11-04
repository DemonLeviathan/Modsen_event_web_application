using Event.Domain;

namespace Event.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByName(string username);
        void AddUser(User user);
    }
}