using System;
using RabbitMQ.Client;

namespace Blick.Queueing.Core.Abstractions;

public interface IChannelProvider : IDisposable
{
    public IModel Channel { get; }
}