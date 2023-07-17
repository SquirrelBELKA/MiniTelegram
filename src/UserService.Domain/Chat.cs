using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    /// <summary>
    ///     Сущность для работы с пользователем
    /// </summary>
    public class Chat
    {
        /// <summary>
        ///     Идентификатор чата
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Кол-во пользователей
        /// </summary>
        public string Sum { get; set; } = "";

        

       //Id пользователей чата +
    }
}
