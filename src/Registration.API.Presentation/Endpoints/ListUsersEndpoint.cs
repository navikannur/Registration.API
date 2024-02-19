using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Registration.API.Application.Models.Responses;
using Registration.API.Application.Mapping;
using Registration.API.Application;

namespace Registration.API.Presentation.Endpoints;

[HttpGet("Users"), AllowAnonymous]
public class ListUsersEndpoint : EndpointWithoutRequest<ListUsersResponse>
{
    private readonly IUserService _UserService;

    public ListUsersEndpoint(IUserService UserService)
    {
        _UserService = UserService ?? throw new ArgumentNullException(nameof(UserService));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var Users = await _UserService.GetAllAsync();
        var UsersResponse = Users.ToUsersResponse();
        await SendOkAsync(UsersResponse, ct);
    }
}
