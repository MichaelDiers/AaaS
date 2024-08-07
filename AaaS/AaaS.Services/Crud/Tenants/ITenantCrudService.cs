namespace AaaS.Services.Crud.Tenants;

public interface ITenantCrudService
{
    /// <summary>
    ///     Create a new tenant.
    /// </summary>
    /// <param name="id">The unique id of the tenant.</param>
    /// <param name="name">
    ///     A human-readable id of the tenant. In contrast to the <see cref="id" />, the name is not necessarily
    ///     unique.
    /// </param>
    /// <param name="isActive">A flag that indicates whether a tenant is activated and can use the service.</param>
    /// <param name="description">An arbitrary description of the tenant.</param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    Task<ITenant> CreateAsync(
        string id,
        string name,
        bool isActive,
        string? description,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Delete a tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    Task DeleteAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    ///     Read all tenants.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>A list of available tenants.</returns>
    Task<IEnumerable<ITenant>> ReadAllAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Read a tenant by its id.
    /// </summary>
    /// <param name="id">The unique id of the tenant.</param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>The tenant with the given <paramref name="id"></paramref>.</returns>
    Task<ITenant> ReadAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    ///     Update the data of a tenant.
    /// </summary>
    /// <param name="tenant">The updated data of a tenant identified by its <see cref="ITenant.Id" /></param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>The updated tenant.</returns>
    Task<ITenant> UpdateAsync(ITenant tenant, CancellationToken cancellationToken);
}
