using Azure.Identity;
using Azure.Messaging.ServiceBus;

namespace Receipt.Extract.Services.ServiceBus
{
    public abstract class ServiceBus
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public ServiceBus()
        {
            _client = new ServiceBusClient(Environment.GetEnvironmentVariable("ConnectionString") ?? string.Empty);

            _sender = _client.CreateSender(Environment.GetEnvironmentVariable("TopicName") ?? string.Empty);
        }

        protected async Task SendMessage(string message)
        {
            using ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync();

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(message)))
            {
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                await _sender.SendMessagesAsync(messageBatch);
            }
            finally
            {
                await _sender.DisposeAsync();
                await _client.DisposeAsync();
            }
        }
    }
}
