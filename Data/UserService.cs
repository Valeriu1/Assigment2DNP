using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assigment3WebApiDatabase.Models;
using Assigment3WebApiDatabase.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assigment3WebApiDatabase.Data
{
    public class UserService : IUserService
    {
        private PersonDBContext ctx;
        public UserService(PersonDBContext ctx)
        {
            this.ctx = ctx;

        }
        
        
        public async Task<User> ValidateUser(string userName, string password)
        {
           await using PersonDBContext personDbContext = new PersonDBContext();

            User user =  ctx.Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }
    }
}