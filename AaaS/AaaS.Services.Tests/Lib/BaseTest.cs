namespace AaaS.Services.Tests.Lib;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
///     Base class for xunit tests.
/// </summary>
/// <typeparam name="T">The type of the service under test.</typeparam>
public class BaseTest<T> : IDisposable
{
    /// <summary>
    ///     The test is run in this dependency injection scope.
    /// </summary>
    private readonly IServiceScope serviceScope;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseTest{T}" /> class.
    /// </summary>
    /// <param name="addDependencies">Functions for adding additional dependencies.</param>
    protected BaseTest(params Func<IServiceCollection, IServiceCollection>[] addDependencies)
    {
        var builder = new HostApplicationBuilder();
        foreach (var addDependency in addDependencies)
        {
            addDependency(builder.Services);
        }

        var host = builder.Build();
        this.serviceScope = host.Services.CreateScope();
        this.Service = this.GetService<T>();
        this.CancellationToken = this.CancellationTokenSource.Token;
    }

    /// <summary>
    ///     Gets a not cancelled <see cref="CancellationToken" />.
    /// </summary>
    protected CancellationToken CancellationToken { get; }

    /// <summary>
    ///     Gets a non cancelled <see cref="CancellationTokenSource" />.
    /// </summary>
    protected CancellationTokenSource CancellationTokenSource => new();

    /// <summary>
    ///     Gets the service under test.
    /// </summary>
    protected T Service { get; }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        this.serviceScope.Dispose();
    }

    /// <summary>
    ///     Gets a service of specified type.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <returns>The requested service.</returns>
    protected TService GetService<TService>()
    {
        var service = this.serviceScope.ServiceProvider.GetService<TService>();
        Assert.NotNull(service);
        return service;
    }
}
