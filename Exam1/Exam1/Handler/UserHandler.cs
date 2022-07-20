using Exam1.Models.DatabaseContext;
using Exam1.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Handler
{
    public class UserHandler : IUserHandler
    {
        private readonly StockDBContext _context;

        public UserHandler (StockDBContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            List<Users> users = new List<Users>();
            try
            {
                users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception)
            {
                return users;
            }

            //return await _context.Set<Users>().FromSqlRaw("SP_GET_All_User").ToListAsync();
        }

        public Task<Users> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Users user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users user)
        {
            throw new System.NotImplementedException();
        }
    }
}
