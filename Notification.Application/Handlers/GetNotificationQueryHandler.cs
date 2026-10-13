namespace Notification.Application.Handlers;

public record GetNotificationQueryHandler(INotificationRepository Repository)
    : IRequestHandler<GetNotificationQuery, Response<Domain.Models.Notification>>
{
    public async Task<Response<Domain.Models.Notification>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
    {
        var data = await Repository.GetAsync(request.Id, cancellationToken);
        return data != null
            ? Response<Domain.Models.Notification>.Success(data)
            : Response<Domain.Models.Notification>.Failure($"Notification with this '{request.Id}' identifier was not found.");
    }
}