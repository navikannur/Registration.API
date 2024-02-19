namespace Registration.API.Application.Models.Responses;

public class UserResponse
{
    public Guid Id { get; init; }

    public string Username { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime RegistrationDate { get; init; }
}
