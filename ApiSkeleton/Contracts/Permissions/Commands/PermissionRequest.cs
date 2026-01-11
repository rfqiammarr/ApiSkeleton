namespace RifqiAmmarR.ApiSKeleton.Api.Contracts.Permissions.Commands;

public sealed record class PermissionRequest
{
    public string PermissionCode { get; set; } = string.Empty;
}
