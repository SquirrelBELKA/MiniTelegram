using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Contexts;

namespace UserService.Infrastructure.Managers
{
    /// <summary>
    ///     Реализация интерфейса <see cref="INotificationManager"/>
    /// </summary>
    public class NotificationManager : INotificationManager
    {
        private readonly NotificationContext _context;

        /// <inheritdoc cref="INotificationManager" />
        public NotificationManager(NotificationContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<Notification> GetAll()
        {
            return _context.Notifications.ToList();
        }

        /// <inheritdoc />
        public Notification? GetNotificationById(long id)
        {
            return _context.Notifications.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public Notification Create(Notification notification)
        {
            var entry = _context.Add(notification);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Notification? Update(Notification notification)
        {
            var existingNotification = _context.Notifications.FirstOrDefault(x => x.Id == notification.Id);
            if (existingNotification is null)
            {
                return null;
            }

            existingNotification.Text = notification.Text;
            existingNotification.FromId = notification.FromId; 
            existingNotification.ToId = notification.ToId;


            var entry = _context.Update(notification);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Notification? Delete(long id)
        {
            var existingNotification = _context.Notifications.FirstOrDefault(x => x.Id == id);
            if (existingNotification is null)
            {
                return null;
            }

            var entry = _context.Remove(existingNotification);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
