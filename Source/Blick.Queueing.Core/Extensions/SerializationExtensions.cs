using System.Text.Json;

namespace Blick.Queueing.Core.Extensions;

public static class SerializationExtensions
{
    public static string Serialize<TInstance>(this TInstance instance)
        where TInstance : class, new()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        
        return JsonSerializer.Serialize(instance, options);
    }

    public static TInstance Deserialize<TInstance>(this string serializedInstance)
        where TInstance : class, new()
    {
        return JsonSerializer.Deserialize<TInstance>(serializedInstance)!;
    }
}