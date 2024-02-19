namespace Registration.API.Application.Models.Requests;

public class CreateUserRequest
{
    public string Username { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime RegistrationDate { get; init; }
}
