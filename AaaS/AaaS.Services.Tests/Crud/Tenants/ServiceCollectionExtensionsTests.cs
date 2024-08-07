namespace AaaS.Services.Tests.Crud.Tenants;

using AaaS.Services.Crud.Tenants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

/// <summary>
///     Tests for <see cref="ServiceCollectionExtensions" />.
/// </summary>
public class ServiceCollectionExtensionsTests
{
    /// <summary>
    ///     Test for <see cref="ServiceCollectionExtensions.TryAddTenantCrudService" />.
    /// </summary>
    [Fact]
    public void TryAddTenantCrudService()
    {
        this.TestDependency<ITenantCrudService>(
            ServiceCollectionExtensions.TryAddTenantCrudService,
            services => services.AddScoped(_ => new Mock<ITenantFactory>().Object));
    }

    /// <summary>
    ///     Test for <see cref="ServiceCollectionExtensions.TryAddTenantCrudServiceDependencies" />.
    /// </summary>
    [Fact]
    public void TryAddTenantCrudServiceDependencies()
    {
        this.TestDependency<ITenantCrudService>(ServiceCollectionExtensions.TryAddTenantCrudServiceDependencies);
    }

    /// <summary>
    ///     Test for <see cref="ServiceCollectionExtensions.TryAddTenantFactory" />.
    /// </summary>
    [Fact]
    public void TryAddTenantFactory()
    {
        this.TestDependency<ITenantFactory>(ServiceCollectionExtensions.TryAddTenantFactory);
    }

    /// <summary>
    ///     Tests weather a service of <typeparamref name="T" /> is available after adding the given
    ///     <paramref name="addDependencies" />.
    /// </summary>
    /// <typeparam name="T">The type of the service under test.</typeparam>
    /// <param name="addDependencies">A list of dependencies that are added to the service collection.</param>
    private void TestDependency<T>(params Func<IServiceCollection, IServiceCollection>[] addDependencies)
    {
        var builder = new HostApplicationBuilder();
        foreach (var addDependency in addDependencies)
        {
            addDependency(builder.Services);
        }

        var host = builder.Build();
        using var scope = host.Services.CreateScope();
        Assert.NotNull(scope.ServiceProvider.GetService<T>());
    }
}
