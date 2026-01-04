using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GuidGenerator;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.RegisterRepository;

public class CreateRegisterRepository : ICreateRegisterRepository
{
    private readonly IAppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPasswordHasher _hasher;

    public CreateRegisterRepository(IAppDbContext context, IHttpContextAccessor httpContextAccessor, IPasswordHasher hasher)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _hasher = hasher;
    }

    public async Task<UserDto> Handle(UserDto request, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(
        u => u.Username == request.Username || u.Email == request.Email,
        cancellationToken);

        if (user != null)
        {
            throw new ConflictException("Username or Email already exists.");
        }

        var hash = _hasher.Hash(request.Password);

        var CreatedBy = _httpContextAccessor.HttpContext?
         .User
         .FindFirstValue(ClaimTypes.Name);

        var data = new User
        {
            Id = GuidGenerator.New(),
            Username = request.Username,
            PasswordHash = hash,
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
