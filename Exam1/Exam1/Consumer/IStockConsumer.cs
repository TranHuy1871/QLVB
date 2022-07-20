using System.Threading.Tasks;

namespace Exam1.Consumer
{
    public interface IStockConsumer
    {
        Task InitRabitMQAsync(bool IsAutoAck = false);
    }
}
