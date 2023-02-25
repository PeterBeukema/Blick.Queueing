using System.Collections.Generic;
using Blick.Queueing.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blick.Queueing.TestApi.Controllers;

[ApiController, Route("messages")]
public class MessagesController : ControllerBase
{
    private readonly IMessagePublisher<MessagesController> messagePublisher;
    private readonly IQueue queue = new Queue();

    public MessagesController(IMessagePublisher<MessagesController> messagePublisher)
    {
        this.messagePublisher = messagePublisher;
    }
    
    [HttpPost(Name = nameof(PostMessage))]
    public ActionResult PostMessage([FromQuery] string message)
    {
        messagePublisher.Publish(message, queue);

        return Ok();
    }
}

public class Queue : IQueue
{
    public string Name { get; set; } = "TestQueue";
    public bool? Durable { get; set; } = false;
    public bool? Exclusive { get; set; } = false;
    public bool? AutoDelete { get; set; } = false;
    public IDictionary<string, object>? Arguments { get; set; } = null;
}