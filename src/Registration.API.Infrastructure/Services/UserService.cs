using FluentValidation;
using FluentValidation.Results;
using Registration.API.Application.Domain;
using Registration.API.Infrastructure.Repositories;
using Registration.API.Application.Mapping;
using Registration.API.Application;

namespace Registration.API.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _UserRepository;

    public UserService(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    public async Task<bool> CreateAsync(User User)
    {
        var existingUser = await _UserRepository.GetAsync(User.Id.Value);
        if (existingUser is not null)
        {
            var message = $"A user with id {User.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(User), message)
            });
        }

        var UserDto = User.ToUserDto();
        return await _UserRepository.CreateAsync(UserDto);
    }

    public async Task<User?> GetAsync(Guid id)
    {
        var UserDto = await _UserRepository.GetAsync(id);
        return UserDto?.ToUser();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var UserDtos = await _UserRepository.GetAllAsync();
        return UserDtos.Select(x => x.ToUser());
    }

    public async Task<bool> UpdateAsync(User User)
    {
        var UserDto = User.ToUserDto();
        return await _UserRepository.UpdateAsync(UserDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _UserRepository.DeleteAsync(id);
    }
}
