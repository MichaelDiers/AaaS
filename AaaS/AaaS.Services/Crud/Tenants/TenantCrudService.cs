namespace AaaS.Services.Crud.Tenants;

/// <summary>
///     Provides crud operations for <see cref="ITenant" />.
/// </summary>
internal class TenantCrudService(ITenantFactory tenantFactory) : ITenantCrudService
{
    /// <summary>
    ///     A factory for creating tenants.
    /// </summary>
    private readonly ITenantFactory tenantFactory = tenantFactory;

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
    public async Task<ITenant> CreateAsync(
        string id,
        string name,
        bool isActive,
        string? description,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var tenant = this.tenantFactory.Create(
            id,
            name,
            isActive,
            description);

        return await Task.FromResult(tenant);
    }

    /// <summary>
    ///     Delete a tenant.
    /// </summary>
    /// <param name="id">The id of the tenant.</param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await Task.CompletedTask;
    }

    /// <summary>
    ///     Read all tenants.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>A list of available tenants.</returns>
    public async Task<IEnumerable<ITenant>> ReadAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await Task.FromResult(Enumerable.Empty<ITenant>());
    }

    /// <summary>
    ///     Read a tenant by its id.
    /// </summary>
    /// <param name="id">The unique id of the tenant.</param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>The tenant with the given <paramref name="id"></paramref>.</returns>
    public async Task<ITenant> ReadAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var tenant = this.tenantFactory.Create(
            id,
            nameof(ITenant.Name),
            true,
            nameof(ITenant.Description));

        return await Task.FromResult(tenant);
    }

    /// <summary>
    ///     Update the data of a tenant.
    /// </summary>
    /// <param name="tenant">The updated data of a tenant identified by its <see cref="ITenant.Id" /></param>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    /// <returns>The updated tenant.</returns>
    public async Task<ITenant> UpdateAsync(ITenant tenant, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await Task.FromResult(tenant);
    }
}
