using Registration.API.Application.Domain;

namespace Registration.API.Application;

public interface IUserService
{
    Task<bool> CreateAsync(User User);

    Task<User?> GetAsync(Guid id);

    Task<IEnumerable<User>> GetAllAsync();

    Task<bool> UpdateAsync(User User);

    Task<bool> DeleteAsync(Guid id);
}
