using Registration.API.Application.Models.Data;
namespace Registration.API.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(UserDto User);

    Task<UserDto?> GetAsync(Guid id);

    Task<IEnumerable<UserDto>> GetAllAsync();

    Task<bool> UpdateAsync(UserDto User);

    Task<bool> DeleteAsync(Guid id);
}
