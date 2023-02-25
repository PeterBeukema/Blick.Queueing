using System.Collections.Generic;

namespace Blick.Queueing.Abstractions;

public class Queue : IQueue
{
    public string Name { get; set; } = string.Empty;
    public bool? Durable { get; set; }
    public bool? Exclusive { get; set; }
    public bool? AutoDelete { get; set; }
    public IDictionary<string, object>? Arguments { get; set; }
}