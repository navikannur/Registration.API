using Registration.API.Application.Domain;
using Registration.API.Application.Domain.Common;
using Registration.API.Application.Models.Data;

namespace Registration.API.Application.Mapping;

public static class DtoToDomainMapper
{
    public static User ToUser(this UserDto UserDto)
    {
        return new User
        {
            Id = UserId.From(Guid.Parse(UserDto.Id)),
            Email = EmailAddress.From(UserDto.Email),
            Username = Username.From(UserDto.Username),
            FullName = FullName.From(UserDto.FullName),
            RegistrationDate = RegistrationDate.From(DateOnly.FromDateTime(UserDto.RegistrationDate))
        };
    }
}
