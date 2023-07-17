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
    ///     Реализация интерфейса <see cref="IMessageManager"/>
    /// </summary>
    public class MessageManager : IMessageManager
    {
        private readonly MessageContext _context;

        /// <inheritdoc cref="IMessageManager" />
        public MessageManager(MessageContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        /// <inheritdoc />
        public Message? GetMessageById(long id)
        {
            return _context.Messages.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public Message Create(Message message)
        {
            var entry = _context.Add(message);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Message? Update(Message message)
        {
            var existingMessage = _context.Messages.FirstOrDefault(x => x.Id == message.Id);
            if (existingMessage is null)
            {
                return null;
            }

            existingMessage.Text = message.Text;
            existingMessage.FromId = message.FromId;
            existingMessage.ToId = message.ToId;


            var entry = _context.Update(message);
            _context.SaveChanges();
            return entry.Entity;
        }

        /// <inheritdoc />
        public Message? Delete(long id)
        {
            var existingMessage = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (existingMessage is null)
            {
                return null;
            }

            var entry = _context.Remove(existingMessage);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
