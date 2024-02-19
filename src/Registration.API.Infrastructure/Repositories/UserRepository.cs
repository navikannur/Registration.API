using Dapper;
using Registration.API.Infrastructure.Database;
using Registration.API.Application.Models.Data;

namespace Registration.API.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UserRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(UserDto User)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Users (Id, Username, FullName, Email, RegistrationDate) 
            VALUES (@Id, @Username, @FullName, @Email, @RegistrationDate)",
            User);
        return result > 0;
    }

    public async Task<UserDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<UserDto>(
            "SELECT * FROM Users WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<UserDto>("SELECT * FROM Users");
    }

    public async Task<bool> UpdateAsync(UserDto User)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Users SET Username = @Username, FullName = @FullName, Email = @Email, 
                 RegistrationDate = @RegistrationDate WHERE Id = @Id",
            User);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Users WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
