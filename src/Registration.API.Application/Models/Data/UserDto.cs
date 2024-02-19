namespace Registration.API.Application.Models.Data;

public class UserDto
{
    public string Id { get; init; } = default!;

    public string Username { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime RegistrationDate { get; init; }
}
