using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Domain;

namespace UserService.Infrastructure.Contexts
{
    /// <summary>
    ///     Контекст для работы с сообщениями
    /// </summary>
    public sealed class MessageContext : DbContext
    {
        /// <summary>
        ///     Сообщения
        /// </summary>
        public DbSet<Message> Messages => Set<Message>();

        public MessageContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}


