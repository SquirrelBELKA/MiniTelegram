using Microsoft.EntityFrameworkCore;
using UserService.Domain;

namespace UserService.Infrastructure.Contexts;

/// <summary>
///     Контекст для работы с оповещениями
/// </summary>
public sealed class NotificationContext : DbContext
{
    /// <summary>
    ///     Оповещения
    /// </summary>
    public DbSet<Notification> Notifications => Set<Notification>();

    public NotificationContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}




