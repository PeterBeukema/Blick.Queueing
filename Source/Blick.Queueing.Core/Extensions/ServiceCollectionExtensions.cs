using Blick.Queueing.Abstractions;
using Blick.Queueing.Core.Abstractions;
using Blick.Queueing.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blick.Queueing.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessageQueueing(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var optionsConfigurationSection = configuration.GetSection(MessageBrokerOptions.Key);
        
        serviceCollection.Configure<MessageBrokerOptions>(optionsConfigurationSection);
        
        serviceCollection.AddSingleton<IChannelProvider, ChannelProvider>();
        serviceCollection.AddTransient(typeof(IMessagePublisher<>), typeof(MessagePublisher<>));

        return serviceCollection;
    }
}