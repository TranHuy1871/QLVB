using Exam1.Models.DatabaseContext;
using Exam1.Models.DataModels;
using Exam1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam1.Handler
{
    public class StockHandler : IStockHandler
    {
        private readonly StockDBContext _context;

        public StockHandler(StockDBContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            List<Stock> stocks = new List<Stock>();
            try
            {
                stocks = await _context.Stocks.ToListAsync();
                return stocks;
            }
            catch (Exception)
            {
                return stocks;
            }

            //return await _context.Set<Stock>().FromSqlRaw("SP_GET_STOCK").ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(string id)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(id);
                _context.Entry<Stock>(stock).State = EntityState.Detached;
                return stock;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> InsertAsync(Stock stock)
        { 
            throw new System.NotImplementedException();
        }

        public async Task<Stock> UpdateAsync(Stock stock)
        {
            try
            {
                if (stock != null)
                {
                    _context.Stocks.Update(stock);
                    await _context.SaveChangesAsync();
                }
                return stock;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
