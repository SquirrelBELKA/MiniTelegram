using Npgsql.Replication.PgOutput.Messages;
using UserService.Domain;

namespace UserService.Host.Routes
{
    public static class MessageRouter
    {

        
        /// <summary>
        ///     Добавляем роутер для работы с сообщениями
        /// </summary>
        /// <param name="application">Объект приложения</param>
        /// <returns>Модифицированный объект приложения</returns>
        public static WebApplication AddMessageRouter(this WebApplication application)
        {
            //Производим группировку логики.
            var userGroup = application.MapGroup("/api/messages");

            userGroup.MapGet(pattern: "/", handler: GetAllMessages);
            userGroup.MapGet(pattern: "/{id:long}", handler: GetMessageById);
            userGroup.MapPost(pattern: "/", handler: CreateMessage);
            userGroup.MapPut(pattern: "/", handler: UpdateMessage);
            userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteMessage);

            return application;
        }

        /// <summary>
        ///     Получить все сообщения
        /// </summary>
        /// <returns>Список всех сообщений</returns>
        private static IResult GetAllMessages(IMessageManager messageManager)
        {
            var messages = messageManager.GetAll();
            return Results.Ok(messages);
        }

        /// <summary>
        ///     Получить сообщение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор искомого сообщения</param>
        /// <param name="messageManager"><see cref="IMessageManager"/></param>
        /// <returns>Данные искомого пользователя</returns>
        private static IResult GetMessageById(long id, IMessageManager messageManager)
        {
            var message = messageManager.GetMessageById(id);
            return message is null
                ? Results.NotFound()
                : Results.Ok(message);
        }

        /// <summary>
        ///     Добавить cообщение
        /// </summary>
        /// <param name="message">Данные сообщения</param>
        /// <param name="messageManager"><see cref="IMessageManager"/></param>
        /// <returns>Данные сообщения</returns>
        private static IResult CreateMessage(Message message, IMessageManager messageManager)
        {
            var createdMessage = messageManager.Create(message);
            return Results.Ok(createdMessage);
        }

        /// <summary>
        ///     Обновить сообщение
        /// </summary>
        /// <param name="message">Данные сообщения</param>
        /// <param name="messageManager"><see cref="IMessageManager"/></param>
        /// <returns>Данные осообщения</returns>
        private static IResult UpdateMessage(Message message, IMessageManager messageManager)
        {
            var updatedMessage = messageManager.Update(message);
            return updatedMessage is null
                ? Results.NotFound()
                : Results.Ok(updatedMessage);
        }

        /// <summary>
        ///     Удалить сообщение
        /// </summary>
        /// <param name = "id" > Идентификатор обновляемого сообщения</param>
        /// <param name = "messageManager" >< see cref= "IMessageManager" /></ param >
        /// < returns > Данные удаленного сообщения</returns>
        private static IResult DeleteMessage(long id, IMessageManager messageManager)
        {
            var deletedMessage = messageManager.Delete(id);
            return deletedMessage is null
                ? Results.NotFound()
                : Results.Ok(deletedMessage);
        }

    }
}
