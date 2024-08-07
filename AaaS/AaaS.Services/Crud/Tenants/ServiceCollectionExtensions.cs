namespace AaaS.Services.Crud.Tenants;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     An extension to <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds a scoped service of the type specified in <see cref="ITenantCrudService" />.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="ITenantCrudService" /> service is added to the given
    ///     <see cref="IServiceCollection" />.
    /// </param>
    /// <returns>The given <paramref name="services" />.</returns>
    public static IServiceCollection AddScopedTenantCrudService(this IServiceCollection services)
    {
        services.AddScoped<ITenantCrudService, TenantCrudService>();

        return services;
    }
}
