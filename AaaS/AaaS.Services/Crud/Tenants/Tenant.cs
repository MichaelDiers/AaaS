namespace AaaS.Services.Crud.Tenants;

/// <summary>
///     Describes the basic data of a tenant.
/// </summary>
internal class Tenant : ITenant
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Tenant" /> class.
    /// </summary>
    /// <param name="id">The unique id of the tenant.</param>
    /// <param name="name">
    ///     A human-readable id of the tenant. In contrast to the <see cref="Id" />, the name is not necessarily
    ///     unique.
    /// </param>
    /// <param name="isActive">A flag that indicates whether a tenant is activated and can use the service.</param>
    /// <param name="description">An arbitrary description of the tenant.</param>
    public Tenant(
        string id,
        string name,
        bool isActive,
        string? description
    )
    {
        this.Id = id;
        this.Name = name;
        this.IsActive = isActive;
        this.Description = description;
    }

    /// <summary>
    ///     Gets or sets an arbitrary description of the tenant.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Gets or sets the unique id of the tenant.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets a flag that indicates whether a tenant is activated and can use the service.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///     Gets or sets a human-readable id of the tenant. In contrast to the <see cref="Id" />, the name is not necessarily
    ///     unique.
    /// </summary>
    public string Name { get; set; }
}
