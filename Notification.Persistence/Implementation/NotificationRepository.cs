namespace Notification.Persistence.Implementation;

public class NotificationRepository(NotificationDbContext context) : INotificationRepository
{
    public async Task<Domain.Models.Notification?> GetAsync(Guid id, CancellationToken cancellationToken) 
        => await context.Notifications.FindAsync(id, cancellationToken) ?? null;

    public async Task<Domain.Models.Notification?> AddAsync(Domain.Models.Notification notification, CancellationToken cancellationToken)
    {
        var entry = await context.Notifications.AddAsync(notification, cancellationToken);
        var row = await context.SaveChangesAsync(cancellationToken);
        return row > 0 ? entry.Entity : null;
    }
}