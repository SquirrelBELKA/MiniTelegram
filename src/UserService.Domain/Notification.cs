using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    /// <summary>
    ///     Сущность для работы с оповещениеями
    /// </summary>
    public class Notification
    {
        /// <summary>
        ///     Идентификатор оповещения
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Текст оповещения
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        ///     От кого оповещение
        /// </summary>
        public string FromId { get; set; } = "";

        /// <summary>
        ///     Кому оповещение
        /// </summary>
        public string ToId { get; set; } = "";

        

    }
}
