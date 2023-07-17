using System;
using UserService.Domain;

namespace UserService.Host.Routes;

/// <summary>
///     Роутер для работы с чатом
/// </summary>
public static class ChatRouter
{
    /// <summary>
    ///     Добавляем роутер для работы с чатом
    /// </summary>
    /// <param name="application">Объект приложения</param>
    /// <returns>Модифицированный объект приложения</returns>
    public static WebApplication AddChatRouter(this WebApplication application)
    {
        // Производим группировку логики.
        var userGroup = application.MapGroup("/api/chats");

        userGroup.MapGet(pattern: "/", handler: GetAllChats);
        userGroup.MapGet(pattern: "/{id:long}", handler: GetChatById);
        userGroup.MapPost(pattern: "/", handler: CreateChat);
        userGroup.MapPut(pattern: "/", handler: UpdateChat);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteChat);

        return application;
    }

    /// <summary>
    ///     Получить все чаты
    /// </summary>
    /// <returns>Список всех чатов</returns>
    private static IResult GetAllChats(IChatManager chatManager)
    {
        var chats = chatManager.GetAll();
        return Results.Ok(chats);
    }

    /// <summary>
    ///     Получить чат по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор искомого чата</param>
    /// <param name="chatManager"><see cref="IChatManager"/></param>
    /// <returns>Данные искомого чата</returns>
    private static IResult GetChatById(long id, IChatManager chatManager)
    {
        var chat = chatManager.GetChatById(id);
        return chat is null
            ? Results.NotFound()
            : Results.Ok(chat);
    }

    /// <summary>
    ///     Добавить чат в систему
    /// </summary>
    /// <param name="chat">Данные добавляемого чата</param>
    /// <param name="chatManager"><see cref="IChatManager"/></param>
    /// <returns>Данные добавленного чата</returns>
    private static IResult CreateChat(Chat chat, IChatManager chatManager)
    {
        var createdChat = chatManager.Create(chat);
        return Results.Ok(createdChat);
    }

    /// <summary>
    ///     Обновить данные чата в системе
    /// </summary>
    /// <param name="chat">Данные обновляемого чата</param>
    /// <param name="chatManager"><see cref="IChatManager"/></param>
    /// <returns>Данные обновленного чата</returns>
    private static IResult UpdateChat(Chat chat, IChatManager chatManager)
    {
        var updatedChat = chatManager.Update(chat);
        return updatedChat is null
            ? Results.NotFound()
            : Results.Ok(updatedChat);
    }

    /// <summary>
    ///     Удалить данные чата из системы
    /// </summary>
    /// <param name="id">Идентификатор обновляемого чата</param>
    /// <param name="chatManager"><see cref="IChatManager"/></param>
    /// <returns>Данные удаленного чата</returns>
    private static IResult DeleteChat(long id, IChatManager chatManager)
    {
        var deletedChat = chatManager.Delete(id);
        return deletedChat is null
            ? Results.NotFound()
            : Results.Ok(deletedChat);
    }


}