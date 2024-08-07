namespace AaaS.Services.Crud.Tenants;

/// <summary>
///     Describes a factory for instances that implement <see cref="ITenant" />.
/// </summary>
public interface ITenantFactory
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ITenant" /> implementing class.
    /// </summary>
    /// <param name="id">The unique id of the tenant.</param>
    /// <param name="name">
    ///     A human-readable id of the tenant. In contrast to the <see cref="ITenant.Id" />, the name is not necessarily
    ///     unique.
    /// </param>
    /// <param name="isActive">A flag that indicates whether a tenant is activated and can use the service.</param>
    /// <param name="description">An arbitrary description of the tenant.</param>
    public ITenant Create(
        string id,
        string name,
        bool isActive,
        string? description
    );
}
