using Blick.Queueing.Core.Abstractions;
using Blick.Queueing.Core.Extensions;
using Blick.Queueing.Core.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Blick.Queueing.Core;

public class ChannelProvider : IChannelProvider
{
    private readonly MessageBrokerOptions options;
    
    private ConnectionFactory? connectionFactory;
    private IConnection? connection;
    private IModel? channel;

    public ChannelProvider(IOptions<MessageBrokerOptions> options)
    {
        this.options = options.Value;
    }

    private ConnectionFactory ConnectionFactory
        => connectionFactory ??= options.BuildConnectionFactory();
    
    private IConnection Connection
        => connection ??= ConnectionFactory.CreateConnection();

    public IModel Channel
        => channel ??= Connection.CreateModel();
    
    public void Dispose()
    {
        Channel.Dispose();
    }
}