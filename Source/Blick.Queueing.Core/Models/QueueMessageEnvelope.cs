using System;
using Blick.Queueing.Core.Extensions;

namespace Blick.Queueing.Core.Models;

public class QueueMessageEnvelope
{
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    
    public string SenderTypeName { get; set; } = string.Empty;
    
    public string MessageTypeName { get; set; } = string.Empty;
    
    public string SerializedMessage { get; set; } = string.Empty;
    
    public static QueueMessageEnvelope Create<TMessage, TSender>(TMessage message)
        where TMessage : class, new()
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        
        return new QueueMessageEnvelope
        {
            SenderTypeName = typeof(TSender).FullName!,
            MessageTypeName = typeof(TMessage).FullName!,
            SerializedMessage = message.Serialize(),
        };
    }
}