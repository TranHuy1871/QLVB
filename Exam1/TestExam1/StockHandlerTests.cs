using Exam1.Handler;
using Exam1.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestExam1
{
    public class StockHandlerTests
    {
        [Fact]
        public async Task GetAllAsync_should_return_3_items_when_db_have_3Async()
        {
            // Arrange
            var expected = 3;
            var optionsBuilder = new DbContextOptionsBuilder<StockDBContext>().UseInMemoryDatabase("Fake");
            var context = new StockDBContext(optionsBuilder.Options);
            context.Stocks.Add(new("maFake1", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 00, 0, 0, 0, 0));
            context.Stocks.Add(new("maFake2", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 00, 0, 0, 0, 0));
            context.Stocks.Add(new("maFake3", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 00, 0, 0, 0, 0));
            context.SaveChanges();

            // Action
            var handler = new StockHandler(context);
            var actual = await handler.GetAllAsync();


            // Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public async Task GetById_should_return_x_if_db_have_xAsync()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<StockDBContext>().UseInMemoryDatabase("Fake");
            var context = new StockDBContext(optionsBuilder.Options);

            //Action

            //Asert
        }
    }
}
