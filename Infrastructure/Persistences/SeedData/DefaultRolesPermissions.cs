namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.SeedData;

public static class DefaultRolesPermissions
{
    public static readonly string[] Roles =
    {
        "Admin",
        "User"
    };

    public static readonly string[] Permissions =
    {
        "USER.READ",
        "USER.CREATE",
        "USER.UPDATE",
        "USER.DELETE",
        //"MODULE.ACTION",
        //"ORDER.APPROVE",
        //"PAYMENT.REFUND",
    };

    public static readonly Dictionary<string, string[]> RolePermissions =
        new()
        {
            ["Admin"] = new[]
            {
                "USER.READ",
                "USER.CREATE",
                "USER.UPDATE",
                "USER.DELETE"
            },
            ["User"] = new[]
            {
                "USER.READ"
            }
        };
}
