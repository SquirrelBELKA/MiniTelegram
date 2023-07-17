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
    ///     Реализация интерфейса <see cref="IChatManager"/>
    /// </summary>
    public class ChatManager : IChatManager
    {
        private readonly ChatContext _context;

        /// <inheritdoc cref="IChatManager" />
        public ChatManager(ChatContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<Chat> GetAll()
        {
            return _context.Chats.ToList();
        }

        /// <inheritdoc />
        public Chat? GetChatById(long id)
        {
            return _context.Chats.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public Chat Create(Chat chat)
        {
            var entry = _context.Add(chat);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Chat? Update(Chat chat)
        {
            var existingChat = _context.Chats.FirstOrDefault(x => x.Id == chat.Id);
            if (existingChat is null)
            {
                return null;
            }

            existingChat.Sum = chat.Sum; 


            var entry = _context.Update(chat);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Chat? Delete(long id)
        {
            var existingChat = _context.Chats.FirstOrDefault(x => x.Id == id);
            if (existingChat is null)
            {
                return null;
            }

            var entry = _context.Remove(existingChat);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
