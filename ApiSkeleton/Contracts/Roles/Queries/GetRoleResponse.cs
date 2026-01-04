namespace RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Queries;

public sealed record class GetRoleResponse
{
    public int? RoleId { get; init; }
    public string? RoleName { get; init; } = string.Empty;
}
