using Microsoft.EntityFrameworkCore;
using Souq.Database;
using Souq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _dbset;
        public UserRepository(SouqContext context)
        {
            _dbset = context.Set<User>();
        }

        
        public User GetUserByCredentails(string email, string password)
        {
            return
                 _dbset.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public User GetUserById(int Id)
        {
            return
                 _dbset.Where(x => x.ID == Id).FirstOrDefault();
        }
        public bool IsEmailExist(string email)
        {
            return
                 _dbset.Any(x => x.Email == email);
        }

        public void AddUser(User user)
        {
            _dbset.Add(user);
        }

        public void RemoveUser(User user)
        {
            _dbset.Remove(user);
        }

    }
}
