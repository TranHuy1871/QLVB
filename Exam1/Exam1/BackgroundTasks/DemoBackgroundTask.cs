using Exam1.Models.DatabaseContext;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exam1.BackgroundTasks
{
    public class DemoBackgroundTask : BackgroundService
    {
        private readonly StockDBContext _db;

        public DemoBackgroundTask(StockDBContext db)
        {
            _db = db;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(true)
            {
                Console.WriteLine("Time now: " + DateTime.Now.ToShortDateString());
                await Task.Delay(1000);
            }
        }
    }
}
