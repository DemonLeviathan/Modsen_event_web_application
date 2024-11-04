using Event.Application.Interfaces;
using Event.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    public class UserService : IUserService
    {
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User RegisterUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
