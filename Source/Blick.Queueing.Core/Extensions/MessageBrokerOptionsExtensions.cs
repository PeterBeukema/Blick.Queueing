using Blick.Queueing.Core.Options;
using RabbitMQ.Client;

namespace Blick.Queueing.Core.Extensions;

public static class MessageBrokerOptionsExtensions
{
    public static ConnectionFactory BuildConnectionFactory(this MessageBrokerOptions options)
    {
        return new ConnectionFactory
        {
            HostName = options.HostName,
            VirtualHost = options.VirtualHost,
            UserName = options.UserName,
            Password = options.Password,
        };
    }
}