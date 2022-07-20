using Exam1.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Exam1.Models.DatabaseContext
{
    public class StockDBContext : DbContext
    {
        public StockDBContext(DbContextOptions<StockDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Stock>().HasData(GetStockSeedAsync());
        //}

        //public List<Stock> GetStockSeedAsync()
        //{
        //    List<Stock> stocks = new List<Stock>();
        //    using (var reader = new StreamReader(@"Seed/Stock_Seed.json"))
        //    {
        //        var data = reader.ReadToEnd();
        //        stocks = JsonSerializer.Deserialize<List<Stock>>(data);
        //    }
        //    return stocks;
        //}
    }
}
