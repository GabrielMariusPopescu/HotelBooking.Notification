namespace Notification.Persistence;

public class NotificationDbContext(DbContextOptions<NotificationDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Models.Notification> Notifications => Set<Domain.Models.Notification>();
}