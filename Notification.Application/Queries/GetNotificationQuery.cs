namespace Notification.Application.Queries;

public record GetNotificationQuery(Guid Id) : IRequest<Response<Domain.Models.Notification>>;