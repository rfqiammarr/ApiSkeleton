using Application.Interfaces.Services.Persistance;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GuidGenerator;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Register;
using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Register;

public class CreateRegisterCommand(IAppDbContext _context, IPasswordHasher _hasher) : IRegisterAsync
{
    public async Task<UserDto> RegisterAsync(UserDto request, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(
        u => u.Username == request.Username || u.Email == request.Email,
        cancellationToken);

        if (user != null)
        {
            throw new ConflictException("Username or Email already exists.");
        }

        var hash = _hasher.Hash(request.Password);


        var data = new User
        {
            Id = GuidGenerator.New(),
            Username = request.Username,
            PasswordHash = hash,
            Email = request.Email,
            IsActive = true,
            RoleId = 2, 
            PermissionId = 1,
            CreatedBy = ClaimTypes.Name
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
