using Microsoft.EntityFrameworkCore;
using QLVB.Models.DatabaseContext;
using QLVB.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLVB.Handler
{
    public class VBHandler : IVBHandler
    {
        private readonly AdminDbContext _context;

        public VBHandler(AdminDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(string maVB)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<VanBan>> GetAllAsync()
        {
            List<VanBan> vanBans = new List<VanBan>();
            try
            {
                vanBans = await _context.VanBans.ToListAsync();
                return vanBans;
            }
            catch (System.Exception)
            {
                return vanBans;

            }

        }

        public Task<VanBan> GetByIdAsync(string maVB)
        {
            throw new System.NotImplementedException();
        }

        public async Task<VanBan> InsertAsync(VanBan vanBan)
        {
            try
            {
                if(vanBan != null)
                {
                    _context.VanBans.Add(vanBan);
                    await _context.SaveChangesAsync();
                }
                return vanBan;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Task<VanBan> UpdateAsync(VanBan vanBan)
        {
            throw new System.NotImplementedException();
        }
    }
}
