using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Managers;

namespace UserService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions2
{
    /// <summary>
    ///     Добавляем бизнес-логику приложения
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <param name="connectionString">Строка подключения к Базе Данных</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddBusinessLogic2(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddManagers();
        services.AddDatabase(connectionString);
        return services;
    }

    /// <summary>
    ///     Добавление менеджеров данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IMessageManager, MessageManager>();

        return services;
    }

    /// <summary>
    ///     Добавление Базы Данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="connectionString">Строка подключения к Базе Данных</param>
    /// <returns><see cref="IServiceCollection"/></returns>
    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MessageContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}