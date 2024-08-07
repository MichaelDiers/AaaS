namespace AaaS.Services.Crud.Tenants;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
///     An extension to <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the <see cref="ITenantCrudService" />.
    /// </summary>
    /// <param name="services">The dependency is added to the given <see cref="IServiceCollection" />.</param>
    /// <returns>The given <paramref name="services" />.</returns>
    public static IServiceCollection TryAddTenantCrudService(this IServiceCollection services)
    {
        services.TryAddScoped<ITenantCrudService, TenantCrudService>();

        return services;
    }

    /// <summary>
    ///     Adds the <see cref="ITenantCrudService" /> and its dependencies.
    /// </summary>
    /// <param name="services">The dependencies are added to the given <see cref="IServiceCollection" />.</param>
    /// <returns>The given <paramref name="services" />.</returns>
    public static IServiceCollection TryAddTenantCrudServiceDependencies(this IServiceCollection services)
    {
        return services.TryAddTenantFactory().TryAddTenantCrudService();
    }

    /// <summary>
    ///     Adds the <see cref="ITenantFactory" />.
    /// </summary>
    /// <param name="services">The dependency is added to the given <see cref="IServiceCollection" />.</param>
    /// <returns>The given <paramref name="services" />.</returns>
    public static IServiceCollection TryAddTenantFactory(this IServiceCollection services)
    {
        services.TryAddScoped<ITenantFactory, TenantFactory>();

        return services;
    }
}
