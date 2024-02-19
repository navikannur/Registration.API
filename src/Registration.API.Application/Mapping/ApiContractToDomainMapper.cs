using Registration.API.Application.Domain;
using Registration.API.Application.Domain.Common;
using Registration.API.Application.Models.Requests;

namespace Registration.API.Application.Mapping;

public static class ApiContractToDomainMapper
{
    public static User ToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(Guid.NewGuid()),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            RegistrationDate = RegistrationDate.From(DateOnly.FromDateTime(request.RegistrationDate))
        };
    }

    public static User ToUser(this UpdateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(request.Id),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            RegistrationDate = RegistrationDate.From(DateOnly.FromDateTime(request.RegistrationDate))
        };
    }
}
