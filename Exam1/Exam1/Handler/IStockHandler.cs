using Exam1.Models.DataModels;
using Exam1.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Handler
{
    public interface IStockHandler
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(string id);
        Task<bool> InsertAsync(Stock stock);
        Task<Stock> UpdateAsync(Stock stock);
        Task<bool> DeleteAsync(string id);
    }
}
