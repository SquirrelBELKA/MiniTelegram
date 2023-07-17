using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain;

public interface IMessageManager
{
    /// <summary>
    ///     Вернуть список всех сообщений
    /// </summary>
    /// <returns>Список всех сообщений</returns>
    List<Message> GetAll();

    /// <summary>
    ///     Получить сообщение по идентификатору 
    ///  </summary>
    /// <param name="id"></param>
    /// <returns>Данные искомого сообщения</returns>
    Message? GetMessageById(long id);

    /// <summary>
    ///     Добавить сообщение в систему
    /// </summary>
    /// <param name="message">Данные добавляемого сообщения</param>
    /// <returns>Данные добавленного сообщения</returns>
    Message? Create(Message message);

    /// <summary>
    ///     Обновить данные сообщения в системе //редактирование
    /// </summary>
    /// <param name="message">Данные обновляемого сообщения</param>
    /// <returns>Данные обновленного сообщения</returns>
    Message? Update(Message message);

    /// <summary>
    ///     Удалить данные сообщения из системы
    /// </summary>
    /// <param name="message">Идентификатор обновляемого сообщения</param>
    /// <returns>Данные удаленного сообщения</returns>
    Message? Delete(long id);
}
