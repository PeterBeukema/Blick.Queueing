namespace Blick.Queueing.Abstractions;

public interface IMessagePublisher
{
    public void Publish<TMessage>(TMessage message);
}