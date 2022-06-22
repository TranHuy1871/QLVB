using System.Collections.Generic;
using System.Threading.Tasks;
using QLVB.Models.DataModels;

namespace QLVB.Handler
{
    public interface IAdminHandler
    {
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task<Admin> UpdateAsync(Admin admin);
        Task<bool> DeleteAsync(int id);
        Task<Admin> InsertAsync(Admin admin);
    }
}
