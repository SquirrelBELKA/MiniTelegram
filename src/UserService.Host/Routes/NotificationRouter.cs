using System;
using UserService.Domain;

namespace UserService.Host.Routes;

/// <summary>
///     Роутер для работы с чатом
/// </summary>
public static class NotificationRouter
{
    /// <summary>
    ///     Добавляем роутер для работы c оповещениями
    /// </summary>
    /// <param name="application">Объект приложения</param>
    /// <returns>Модифицированный объект приложения</returns>
    public static WebApplication AddNotificationRouter(this WebApplication application)
    {
        // Производим группировку логики.
        var userGroup = application.MapGroup("/api/notifications");

        userGroup.MapGet(pattern: "/", handler: GetAllNotifications);
        userGroup.MapGet(pattern: "/{id:long}", handler: GetNotificationById);
        userGroup.MapPost(pattern: "/", handler: CreateNotification);
        userGroup.MapPut(pattern: "/", handler: UpdateNotification);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteNotification);

        return application;
    }

    /// <summary>
    ///     Получить все оповещения
    /// </summary>
    /// <returns>Список всех оповещений</returns>
    private static IResult GetAllNotifications(INotificationManager notificationManager) 
    {
        var notifications = notificationManager.GetAll();
        return Results.Ok(notifications);
    }

    /// <summary>
    ///     Получить оповещение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор искомого оповещения</param>
    /// <param name="notificationManager"><see cref="INotificationManager"/></param>
    /// <returns>Данные искомого оповещения</returns>
    private static IResult GetNotificationById(long id, INotificationManager notificationManager)
    {
        var notification = notificationManager.GetNotificationById(id);
        return notification is null
            ? Results.NotFound()
            : Results.Ok(notification);
    }

    /// <summary>
    ///     Добавить оповещение в систему
    /// </summary>
    /// <param name="notification">Данные добавляемого оповещения</param>
    /// <param name="notificationManager"><see cref="INotificationManager"/></param>
    /// <returns>Данные добавленного оповещения</returns>
    private static IResult CreateNotification(Notification notification, INotificationManager notificationManager)
    {
        var createdNotification = notificationManager.Create(notification);
        return Results.Ok(createdNotification);
    }

    /// <summary>
    ///     Обновить данные оповещения в системе
    /// </summary>
    /// <param name="notification">Данные обновляемого оповещения</param>
    /// <param name="notificationManager"><see cref="INotificationManager"/></param>
    /// <returns>Данные обновленного оповещения</returns>
    private static IResult UpdateNotification(Notification notification, INotificationManager notificationManager)
    {
        var updatedNotification = notificationManager.Update(notification);
        return updatedNotification is null
            ? Results.NotFound()
            : Results.Ok(updatedNotification);
    }

    /// <summary>
    ///     Удалить данные оповещения из системы
    /// </summary>
    /// <param name="id">Идентификатор обновляемого оповещения</param>
    /// <param name="notificationManager"><see cref="INotificationManager"/></param>
    /// <returns>Данные удаленного оповещения</returns>
    private static IResult DeleteNotification(long id, INotificationManager notificationManager)
    {
        var deletedNotification = notificationManager.Delete(id);
        return deletedNotification is null
            ? Results.NotFound()
            : Results.Ok(deletedNotification);
    }


}



