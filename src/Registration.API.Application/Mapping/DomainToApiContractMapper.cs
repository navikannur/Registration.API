using Registration.API.Application.Domain;
using Registration.API.Application.Models.Responses;

namespace Registration.API.Application.Mapping;

public static class DomainToApiContractMapper
{
    public static UserResponse ToUserResponse(this User User)
    {
        return new UserResponse
        {
            Id = User.Id.Value,
            Email = User.Email.Value,
            Username = User.Username.Value,
            FullName = User.FullName.Value,
            RegistrationDate = User.RegistrationDate.Value.ToDateTime(TimeOnly.MinValue)
        };
    }

    public static ListUsersResponse ToUsersResponse(this IEnumerable<User> Users)
    {
        return new ListUsersResponse
        {
            Users = Users.Select(x => new UserResponse
            {
                Id = x.Id.Value,
                Email = x.Email.Value,
                Username = x.Username.Value,
                FullName = x.FullName.Value,
                RegistrationDate = x.RegistrationDate.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }
}
