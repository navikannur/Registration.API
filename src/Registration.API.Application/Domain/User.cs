using Registration.API.Application.Domain.Common;

namespace Registration.API.Application.Domain;

public class User
{
    public UserId Id { get; init; } = UserId.From(Guid.NewGuid());

    public Username Username { get; init; } = default!;

    public FullName FullName { get; init; } = default!;

    public EmailAddress Email { get; init; } = default!;

    public RegistrationDate RegistrationDate { get; init; } = default!;
}
