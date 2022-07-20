using Exam1.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Handler
{
    public interface IUserHandler
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Users user);
        Task<bool> DeleteAsync(int id);
        Task<bool> InsertAsync(Users user);
    }
}
