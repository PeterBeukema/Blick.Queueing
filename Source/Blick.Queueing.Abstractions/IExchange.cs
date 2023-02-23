using System.Collections.Generic;

namespace Blick.Queueing.Abstractions;

public interface IExchange
{
    public string Name { get; set; }
    public string Type { get; set; }
    public bool? Durable { get; set; }
    public bool? AutoDelete { get; set; }
    public IDictionary<string,object>? Arguments { get; set; }
}