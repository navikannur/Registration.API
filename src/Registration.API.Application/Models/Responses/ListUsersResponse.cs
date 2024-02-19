namespace Registration.API.Application.Models.Responses;

public class ListUsersResponse
{
    public IEnumerable<UserResponse> Users { get; init; } = Enumerable.Empty<UserResponse>();
}
