namespace UserService.Domain;

/// <summary>
///     Интерфейс взаимодействия с чатом
/// </summary>
public interface IChatManager
{
    /// <summary>
    ///     Вернуть список всех чатов
    /// </summary>
    /// <returns>Список всех чатов</returns>
    List<Chat> GetAll();

    /// <summary>
    ///     Получить чат по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Данные искомого чата</returns>
    Chat? GetChatById(long id);

    /// <summary>
    ///     Добавить чат в систему
    /// </summary>
    /// <param name="user">Данные добавляемого чата</param>
    /// <returns>Данные добавленного чата</returns>
    Chat? Create(Chat chat);

    /// <summary>
    ///     Обновить данные чата в системе
    /// </summary>
    /// <param name="user">Данные обновляемого чата</param>
    /// <returns>Данные обновленного чата</returns>
    Chat? Update(Chat chat);

    /// <summary>
    ///     Удалить данные чатов из системы
    /// </summary>
    /// <param name="id">Идентификатор обновляемого чата</param>
    /// <returns>Данные удаленного чата</returns>
    Chat? Delete(long id);
   


}