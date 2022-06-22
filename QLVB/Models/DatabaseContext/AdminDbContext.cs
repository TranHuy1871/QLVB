using Microsoft.EntityFrameworkCore;
using QLVB.Models.DataModels;

namespace QLVB.Models.DatabaseContext
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options): base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<VanBan> VanBans { get; set; }
    }
}
