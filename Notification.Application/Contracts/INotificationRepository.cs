namespace Notification.Application.Contracts;

public interface INotificationRepository
{
    Task<Domain.Models.Notification?> GetAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Domain.Models.Notification?> AddAsync(Domain.Models.Notification notification, CancellationToken cancellationToken);
}