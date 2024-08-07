namespace AaaS.Services.Tests.Crud.Tenants;

using AaaS.Services.Crud.Tenants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
///     Tests the implementation of <see cref="ITenantCrudService" />.
/// </summary>
public class TenantCrudServiceTests : IDisposable
{
    /// <summary>
    ///     A source for cancellation tokens.
    /// </summary>
    private readonly CancellationTokenSource cancellationTokenSource = new();

    /// <summary>
    ///     The service under test.
    /// </summary>
    private readonly ITenantCrudService service;

    /// <summary>
    ///     Necessary for scoped dependency injection.
    /// </summary>
    private readonly IServiceScope serviceScope;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TenantCrudServiceTests" /> class.
    /// </summary>
    public TenantCrudServiceTests()
    {
        var builder = new HostApplicationBuilder();
        builder.Services.AddScopedTenantCrudService();

        var host = builder.Build();
        this.serviceScope = host.Services.CreateScope();

        var tenantCrudService = this.serviceScope.ServiceProvider.GetService<ITenantCrudService>();
        Assert.NotNull(tenantCrudService);
        this.service = tenantCrudService;
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        this.serviceScope.Dispose();
    }

    /// <summary>
    ///     Test for creating a new tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="name">The name of the tenant.</param>
    /// <param name="isActive">Indicates weather the tenant is active.</param>
    /// <param name="description">A description for the tenant.</param>
    /// <returns></returns>
    [Theory]
    [InlineData(
        "id",
        "name",
        true,
        null)]
    [InlineData(
        "id",
        "name",
        true,
        "description")]
    [InlineData(
        "id",
        "name",
        false,
        null)]
    [InlineData(
        "id",
        "name",
        false,
        "description")]
    public async Task CreateAsync(
        string id,
        string name,
        bool isActive,
        string? description
    )
    {
        var tenant = await this.service.CreateAsync(
            id,
            name,
            isActive,
            description,
            this.cancellationTokenSource.Token);

        Assert.Equal(
            id,
            tenant.Id);
        Assert.Equal(
            name,
            tenant.Name);
        Assert.Equal(
            isActive,
            tenant.IsActive);
        Assert.Equal(
            description,
            tenant.Description);
    }
}
