using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment3WebApiDatabase.Models;

namespace Assigment3WebApiDatabase.Data
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
