namespace AaaS.Services.Crud.Tenants;

/// <summary>
///     Describes the basic data of a tenant.
/// </summary>
public interface ITenant
{
    /// <summary>
    ///     Gets or sets an arbitrary description of the tenant.
    /// </summary>
    string? Description { get; set; }

    /// <summary>
    ///     Gets the unique id of the tenant.
    /// </summary>
    string Id { get; }

    /// <summary>
    ///     Gets or sets a flag that indicates whether a tenant is activated and can use the service.
    /// </summary>
    bool IsActive { get; set; }

    /// <summary>
    ///     Gets or sets a human-readable id of the tenant. In contrast to the <see cref="Id" />, the name is not necessarily
    ///     unique.
    /// </summary>
    string Name { get; set; }
}
