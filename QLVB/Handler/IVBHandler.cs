using QLVB.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLVB.Handler
{
    public interface IVBHandler
    {
        Task<IEnumerable<VanBan>> GetAllAsync();
        Task<VanBan> GetByIdAsync(string maVB);
        Task<VanBan> InsertAsync(VanBan vanBan);
        Task<VanBan> UpdateAsync(VanBan vanBan);
        Task<bool> DeleteAsync(string maVB);
    }
}
