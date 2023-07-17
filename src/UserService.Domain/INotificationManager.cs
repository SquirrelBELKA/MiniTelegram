using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    /// <summary>
    ///     Интерфейс для  отправки уведомлений 
    /// </summary>
    public interface INotificationManager
    {
        ///// <summary>
        /////     Отправить оповещение
        ///// </summary>
        ///// <param name="notification">Объект содержащий данные оповещения</param>
        ///// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        ///// <returns><see cref="ValueTask"/></returns>
        ////ValueTask SendAsync(Notification notification, CancellationToken cancellationToken);


        /// <summary>
        ///     Вернуть список всех оповещений
        /// </summary>
        /// <returns>Список всех чатов</returns>
        List<Notification> GetAll();

        /// <summary>
        ///     Получить оповещение по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Данные искомого чата</returns>
        Notification? GetNotificationById(long id);

        /// <summary>
        ///     Добавить оповещение в систему
        /// </summary>
        /// <param name="notification">Данные добавляемого оповещения</param>
        /// <returns>Данные добавленного оповещения</returns>
        Notification? Create(Notification notification);

        /// <summary>
        ///     Обновить данные оповещения в системе
        /// </summary>
        /// <param name="notification">Данные обновляемого чата</param>
        /// <returns>Данные обновленного чата</returns>
        Notification? Update(Notification notification);

        /// <summary>
        ///     Удалить данные оповещения из системы
        /// </summary>
        /// <param name="id">Идентификатор обновляемого чата</param>
        /// <returns>Данные удаленного чата</returns>
        Notification? Delete(long id);
    }
}
