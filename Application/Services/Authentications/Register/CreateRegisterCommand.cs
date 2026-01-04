using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Register;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Register;

public class CreateRegisterCommand(ICreateRegisterRepository _createRegisterRepository) : IRegisterAsync
{
    public async Task<UserDto> RegisterAsync(UserDto request, CancellationToken cancellationToken = default)
    {
        return await _createRegisterRepository.Handle(request, cancellationToken);
    }
}
