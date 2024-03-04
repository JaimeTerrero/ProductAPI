using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using VictorVentral.Products.Application.Products.DTOs;

namespace ServiceBus.Consumer
{
    public class ProductConsumerService : BackgroundService
    {
        private readonly ILogger<ProductConsumerService> _logger;
        private readonly ISubscriptionClient _subscriptionClient;

        public ProductConsumerService(ILogger<ProductConsumerService> logger, ISubscriptionClient subscriptionClient)
        {
            _logger = logger;
            _subscriptionClient = subscriptionClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriptionClient.RegisterMessageHandler((message, token) =>
            {
                var productCreated = 
                    JsonConvert.DeserializeObject<ProductDto>(Encoding.UTF8.GetString(message.Body));

                Console.WriteLine($"New Product with name {productCreated.Name} and category {productCreated.Category}");

                return _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }, new MessageHandlerOptions(args => Task.CompletedTask)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });
        }
    }
}
