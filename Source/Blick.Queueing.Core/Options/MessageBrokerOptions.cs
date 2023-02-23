namespace Blick.Queueing.Core.Options;

public class MessageBrokerOptions
{
    public const string Key = nameof(MessageBrokerOptions);
    
    public string HostName { get; set; } = "localhost";

    public string? VirtualHost { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}