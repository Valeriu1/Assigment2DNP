using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assigment2WebApi.Data
{
    public interface IPersonsService
    {
        Task<IList<Adult>> GetPersonsAsync();
        Task<Adult> AddPersonAsync(Adult adult);
        Task RemovePersonAsync(int personId);
        Task<Adult> UpdateAsync(Adult adult);
        Task<Adult> GetAsync(int id);
    }
}
