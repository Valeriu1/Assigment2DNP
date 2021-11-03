using System.Threading.Tasks;

namespace Assigment2WebApi.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}