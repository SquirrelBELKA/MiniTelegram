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
    ///     Контекст для работы с чатами
    /// </summary>
    public sealed class ChatContext : DbContext
    {
        /// <summary>
        ///     Сообщения
        /// </summary>
        public DbSet<Chat> Chats => Set<Chat>();

        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}


