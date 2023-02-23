using Blick.Queueing.Abstractions;

namespace Blick.Queueing.Core;

public class MessagePublisher : IMessagePublisher
{
    public void Publish<TMessage>(TMessage message)
    {
        throw new System.NotImplementedException();
    }
}