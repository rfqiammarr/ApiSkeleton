namespace RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Commands;

public sealed record class RoleRequest
{
    public string RoleName { get; init; } = null!;
}