using Souq.Models;
using System.Collections.Generic;

namespace Souq.Repository
{
    public interface IUserRepository
    {
        User GetUserByCredentails(string email, string password);
        void RemoveUser(User user);
        void AddUser(User user);
        bool IsEmailExist(string email);
        User GetUserById(int Id);

    }
}