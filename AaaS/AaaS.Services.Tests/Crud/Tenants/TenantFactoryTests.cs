namespace AaaS.Services.Tests.Crud.Tenants;

using AaaS.Services.Crud.Tenants;
using AaaS.Services.Tests.Lib;

/// <summary>
///     Tests for <see cref="ITenantFactory" />.
/// </summary>
public class TenantFactoryTests() : BaseTest<ITenantFactory>(ServiceCollectionExtensions.TryAddTenantFactory)
{
    /// <summary>
    ///     Test for creating a new tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="name">The name of the tenant.</param>
    /// <param name="isActive">Indicates weather the tenant is active.</param>
    /// <param name="description">A description for the tenant.</param>
    /// [Theory]
    [Theory]
    [MemberData(
        nameof(TenantTestData.ValidData),
        MemberType = typeof(TenantTestData))]
    public void Create(
        string id,
        string name,
        bool isActive,
        string? description
    )
    {
        var tenant = this.Service.Create(
            id,
            name,
            isActive,
            description);

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
