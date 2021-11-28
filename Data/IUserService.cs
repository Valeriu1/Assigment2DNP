using System.Threading.Tasks;
using Assigment3WebApiDatabase.Models;

namespace Assigment3WebApiDatabase.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}