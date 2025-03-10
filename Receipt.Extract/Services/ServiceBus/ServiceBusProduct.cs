using Receipt.Extract.Models;
using System.Text.Json;

namespace Receipt.Extract.Services.ServiceBus
{
    public class ServiceBusProduct : ServiceBus, IServiceBus
    {
        public async Task SendMessage(Product product)
        {
            await SendMessage(JsonSerializer.Serialize(product));
        }
    }
}
