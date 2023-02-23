using System.Text;
using Blick.Queueing.Abstractions;
using Blick.Queueing.Core.Abstractions;
using Blick.Queueing.Core.Extensions;
using Blick.Queueing.Core.Models;

namespace Blick.Queueing.Core;

public class MessagePublisher<TSender> : IMessagePublisher<TSender>
{
    private readonly IChannelProvider channelProvider;

    public MessagePublisher(IChannelProvider channelProvider)
    {
        this.channelProvider = channelProvider;
    }
    
    public void Publish<TMessage>(
        TMessage message,
        IQueue queue,
        IExchange? exchange = null,
        string? routingKey = null,
        bool? mandatory = true)
        where TMessage : class, new()
    {
        channelProvider.Channel.QueueDeclare(
            queue: queue.Name,
            durable: queue.Durable ?? false,
            exclusive: queue.Exclusive ?? false,
            autoDelete: queue.AutoDelete ?? false,
            arguments: queue.Arguments ?? null);

        var messageEnvelope = QueueMessageEnvelope.Create<TMessage, TSender>(message);
        var serializedMessageEnvelope = messageEnvelope.Serialize();
        var messageBody = Encoding.UTF8.GetBytes(serializedMessageEnvelope);

        if (exchange != null)
        {
            channelProvider.Channel.ExchangeDeclare(
                exchange: exchange.Name,
                type: exchange.Type,
                durable: exchange.Durable ?? false,
                autoDelete: exchange.AutoDelete ?? false,
                arguments: exchange.Arguments ?? null);
        }

        channelProvider.Channel.BasicPublish(
            exchange: exchange?.Name,
            routingKey: routingKey,
            mandatory: mandatory ?? true,
            basicProperties: null,
            body: messageBody);
    }
}