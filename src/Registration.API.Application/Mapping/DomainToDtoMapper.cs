using Registration.API.Application.Domain;
using Registration.API.Application.Models.Data;

namespace Registration.API.Application.Mapping;

public static class DomainToDtoMapper
{
    public static UserDto ToUserDto(this User User)
    {
        return new UserDto
        {
            Id = User.Id.Value.ToString(),
            Email = User.Email.Value,
            Username = User.Username.Value,
            FullName = User.FullName.Value,
            RegistrationDate = User.RegistrationDate.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
}
