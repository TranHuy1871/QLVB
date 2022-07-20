using Exam1.Handler;
using Exam1.Hubs;
using Exam1.Models.DataModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exam1.Consumer
{
    public class StockConsumer : IStockConsumer
    {
        private readonly IStockHandler _handler;
        private readonly IHubContext<StockHub> _hubContext;

        public StockConsumer(IServiceScopeFactory service)
        {
            var scope = service.CreateScope();
            _handler = (IStockHandler)scope.ServiceProvider.GetService(typeof(IStockHandler));
            _hubContext = (IHubContext<StockHub>)scope.ServiceProvider.GetService(typeof(IHubContext<StockHub>));
        }

        public Task InitRabitMQAsync(bool IsAutoAck = false)
        {
            throw new System.NotImplementedException();
        }

        private Task HandlerMessageAsync(string mess)
        {
            throw new System.NotImplementedException();
        }
    }
}
