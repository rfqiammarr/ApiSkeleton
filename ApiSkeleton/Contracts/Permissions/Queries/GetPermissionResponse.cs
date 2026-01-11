namespace RifqiAmmarR.ApiSKeleton.Api.Contracts.Permissions.Queries;

public sealed record class GetPermissionResponse
{
    public int PermissionId { get; set; } 
    public string PermissionCode { get; set; } = string.Empty;
}