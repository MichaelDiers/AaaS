namespace AaaS.Services.Tests.Crud.Tenants;

using AaaS.Services.Crud.Tenants;
using AaaS.Services.Tests.Lib;
using Microsoft.Extensions.DependencyInjection;
using Moq;

/// <summary>
///     Tests the implementation of <see cref="ITenantCrudService" />.
/// </summary>
public class TenantCrudServiceTests() : BaseTest<ITenantCrudService>(
    ServiceCollectionExtensions.TryAddTenantCrudService,
    TenantCrudServiceTests.AddMocks)
{
    /// <summary>
    ///     Add the required service mocks for running tests.
    /// </summary>
    /// <param name="services">Service mocks are added to this <see cref="IServiceCollection" />.</param>
    /// <returns>The given <paramref name="services" />.</returns>
    public static IServiceCollection AddMocks(IServiceCollection services)
    {
        var mock = new Mock<ITenantFactory>();
        mock.Setup(
                factory => factory.Create(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<string?>()))
            .Returns<string, string, bool, string?>(
                (
                    id,
                    name,
                    isActive,
                    description
                ) =>
                {
                    var tenantMock = new Mock<ITenant>();

                    tenantMock.Setup(tenant => tenant.Id).Returns(id);
                    tenantMock.Setup(tenant => tenant.Name).Returns(name);
                    tenantMock.Setup(tenant => tenant.IsActive).Returns(isActive);
                    tenantMock.Setup(tenant => tenant.Description).Returns(description);

                    return tenantMock.Object;
                });

        services.AddScoped(_ => mock.Object);

        return services;
    }

    /// <summary>
    ///     Test for creating a new tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="name">The name of the tenant.</param>
    /// <param name="isActive">Indicates weather the tenant is active.</param>
    /// <param name="description">A description for the tenant.</param>
    [Theory]
    [MemberData(
        nameof(TenantTestData.ValidData),
        MemberType = typeof(TenantTestData))]
    public async Task CreateAsync(
        string id,
        string name,
        bool isActive,
        string? description
    )
    {
        var tenant = await this.Service.CreateAsync(
            id,
            name,
            isActive,
            description,
            this.CancellationToken);

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

    /// <summary>
    ///     Test for deleting a tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    [Theory]
    [InlineData("id")]
    public async Task DeleteAsync(string id)
    {
        await this.Service.DeleteAsync(
            id,
            this.CancellationToken);
    }

    /// <summary>
    ///     Test for reading a tenant by its id.
    /// </summary>
    [Fact]
    public async Task ReadAsyncById()
    {
        const string id = nameof(id);
        var tenant = await this.Service.ReadAsync(
            id,
            this.CancellationToken);

        Assert.Equal(
            id,
            tenant.Id);
    }

    /// <summary>
    ///     Test for reading all tenants.
    /// </summary>
    [Fact]
    public async Task ReadAsyncWithoutId()
    {
        _ = await this.Service.ReadAsync(this.CancellationToken);
    }

    /// <summary>
    ///     Test for updating a tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="name">The name of the tenant.</param>
    /// <param name="isActive">Indicates weather the tenant is active.</param>
    /// <param name="description">A description for the tenant.</param>
    [Theory]
    [MemberData(
        nameof(TenantTestData.ValidData),
        MemberType = typeof(TenantTestData))]
    public async Task UpdateAsync(
        string id,
        string name,
        bool isActive,
        string? description
    )
    {
        var tenantUpdateMock = new Mock<ITenant>();
        tenantUpdateMock.Setup(tenant => tenant.Id).Returns(id);
        tenantUpdateMock.Setup(tenant => tenant.Name).Returns(name);
        tenantUpdateMock.Setup(tenant => tenant.IsActive).Returns(isActive);
        tenantUpdateMock.Setup(tenant => tenant.Description).Returns(description);

        var tenant = await this.Service.UpdateAsync(
            tenantUpdateMock.Object,
            this.CancellationToken);

        Assert.Equal(
            id,
            tenant.Id);
        Assert.Equal(
            name,
            tenant.Name);
        Assert.Equal(
            description,
            tenant.Description);
        Assert.Equal(
            isActive,
            tenant.IsActive);
    }
}
