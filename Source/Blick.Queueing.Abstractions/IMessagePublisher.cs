namespace Blick.Queueing.Abstractions;

public interface IMessagePublisher<TSender>
{
    public void Publish<TMessage>(
        TMessage message,
        IQueue queue,
        IExchange? exchange = null,
        string? routingKey = null,
        bool? mandatory = true);
}