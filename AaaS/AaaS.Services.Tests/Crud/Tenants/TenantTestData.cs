namespace AaaS.Services.Tests.Crud.Tenants;

/// <summary>
///     Test data for tenants.
/// </summary>
public class TenantTestData
{
    /// <summary>
    ///     Data that describes valid tenant data. Used for parameterised xunit tests.
    /// </summary>
    public static IEnumerable<object?[]> ValidData =>
        new List<object?[]>
        {
            new object?[]
            {
                "id",
                "name",
                true,
                null
            },
            new object?[]
            {
                "id",
                "name",
                true,
                "description"
            },
            new object?[]
            {
                "id",
                "name",
                false,
                null
            },
            new object?[]
            {
                "id",
                "name",
                false,
                "description"
            }
        };
}
