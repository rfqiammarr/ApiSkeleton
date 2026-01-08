using RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GuidGenerator;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.RegisterRepository;

public class CreateRegisterRepository : ICreateRegisterRepository
{
    private readonly IAppDbContext _context;

    public CreateRegisterRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(UserDto request, string hasher, CancellationToken cancellationToken = default)
    {
        var data = new User
        {
            Id = GuidGenerator.New(),
            Username = request.Username,
            PasswordHash = hasher,
            Email = request.Email,
            IsActive = true,
            RoleId = 2,
            PermissionId = 1,
        };

        await _context.Users.AddAsync(data, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new UserDto
        {
            UserId = data.Id,
            Username = data.Username,
            Email = data.Email,
            RoleId = data.RoleId,
            PermissionId = data.PermissionId
        };
    }
}
