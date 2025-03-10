using Receipt.Extract.Models;

namespace Receipt.Extract.Services.ServiceBus
{
    public interface IServiceBus
    {
        Task SendMessage(Product product);
    }
}
