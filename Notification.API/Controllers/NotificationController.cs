namespace Notification.API.Controllers;

[ApiController]
[Route("api/notifications")]
public class NotificationController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        var response = await mediator.Send(command);
        return response.IsSuccessful ? Ok(response.Data) : BadRequest(response.Message);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNotification(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetNotificationQuery(id);
        var response = await mediator.Send(query, cancellationToken);
        return response.IsSuccessful ? Ok(response.Data) : NotFound(response.Message);
    }
}
