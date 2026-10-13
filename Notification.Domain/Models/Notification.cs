namespace Notification.Domain.Models;

public class Notification
{
    public Notification() { }

    public Guid Id { get; set; }

    [StringLength(100)]
    public string Recipient { get; set; }

    [StringLength(int.MaxValue)]
    public string Message { get; set; }

    [StringLength(50)]
    public string Type { get; set; }
    
    public DateTime SentAt { get; set; }
}