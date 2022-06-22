using Microsoft.EntityFrameworkCore;
using QLVB.Models.DatabaseContext;
using QLVB.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLVB.Handler
{
    public class AdminHandler : IAdminHandler
    {
        private readonly AdminDbContext _context;

        public AdminHandler (AdminDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            List<Admin> list = new List<Admin>();
            try
            {
                list = await _context.Admins.ToListAsync();
                return list;
            }
            catch (System.Exception)
            {
                return list;
            }
        }

        public Task<Admin> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Admin> InsertAsync(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public Task<Admin> UpdateAsync(Admin admin)
        {
            throw new System.NotImplementedException();
        }
    }
}
