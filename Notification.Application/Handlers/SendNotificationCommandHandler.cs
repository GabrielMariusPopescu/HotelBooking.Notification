namespace Notification.Application.Handlers;

public record SendNotificationCommandHandler(INotificationRepository Repository)
    : IRequestHandler<SendNotificationCommand, Response<Domain.Models.Notification>>
{
    public async Task<Response<Domain.Models.Notification>> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Notification notification = new()
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type,
            SentAt = DateTime.UtcNow
        };

        var data = await Repository.AddAsync(notification, cancellationToken);
        return data != null 
            ? Response<Domain.Models.Notification>.Success(data) 
            : Response<Domain.Models.Notification>.Failure("Notification was not created.");
    }
}