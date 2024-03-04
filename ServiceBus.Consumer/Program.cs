using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Consumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ProductConsumerService>();
builder.Services.AddSingleton<ISubscriptionClient>(x
        => new SubscriptionClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString"),
        builder.Configuration.GetValue<string>("ServiceBus:TopicName"),
        builder.Configuration.GetValue<string>("ServiceBus:SubscriptionName")));

var host = builder.Build();
host.Run();
