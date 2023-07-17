using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    /// <summary>
    ///     Сущность для работы с сообщениями
    /// </summary>
    public class Message
    {
        // <summary>
        ///     Идентификатор сообщений 
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Дата отправки сообщения
        /// </summary>
        public string Data { get; set; } = "";

        /// <summary>
        ///     Текст сообщения
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        ///     От кого сообщение
        /// </summary>
        public string FromId { get; set; } = "";

        /// <summary>
        ///     Кому сообщение
        /// </summary>
        public string ToId { get; set; } = "";

    }
}
//добавить id(имя) пользователя, отправившего сообщение позже