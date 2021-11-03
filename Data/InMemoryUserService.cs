using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment2WebApi.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    
                    Password = "1111",
                    // Role = "Student",
                    // SecurityLevel = 4,
                    UserName = "Coi"
                },
                new User
                {
                   
                    Password = "4444",
                    // Role = "Student",
                    // SecurityLevel = 2,
                    UserName = "Scaca"
                }
            }.ToList();
        }
        
        
        public async Task<User> ValidateUser(string userName, string password)
        {
            User user = users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }
    }
}