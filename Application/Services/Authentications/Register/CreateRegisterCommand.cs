using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.UserRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Register;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Register;

public class CreateRegisterCommand(ICreateRegisterRepository _createRegisterRepository, IUserRepository _userRepository, IPasswordHasher _hasher) : IRegisterAsync
{
    public async Task<UserDto> Handle(UserDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.IsUsernameOrEmailHasAlreadyExist(request.Username, request.Email, cancellationToken);

        if (user)
            throw new ConflictException("Username or Email already exists.");

        var hash = _hasher.Hash(request.Password);
        return await _createRegisterRepository.Handle(request, hash, cancellationToken);
    }
}
