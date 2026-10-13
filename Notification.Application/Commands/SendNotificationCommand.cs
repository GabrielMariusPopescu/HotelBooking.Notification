namespace Notification.Application.Commands;

public record SendNotificationCommand(string Recipient, string Message, string Type) 
    : IRequest<Response<Domain.Models.Notification>>;