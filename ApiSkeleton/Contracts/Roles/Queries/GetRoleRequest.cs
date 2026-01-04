namespace RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Queries;

public sealed record class GetRoleRequest
{
    public Guid RoleId { get; init; }
}
