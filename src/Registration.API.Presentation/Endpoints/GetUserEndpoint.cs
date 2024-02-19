using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Registration.API.Application.Models.Requests;
using Registration.API.Application.Models.Responses;
using Registration.API.Application.Mapping;
using Registration.API.Application;

namespace Registration.API.Presentation.Endpoints;

[HttpGet("Users/{id:guid}"), AllowAnonymous]
public class GetUserEndpoint : Endpoint<GetUserRequest, UserResponse>
{
    private readonly IUserService _UserService;

    public GetUserEndpoint(IUserService UserService)
    {
        _UserService = UserService;
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        var User = await _UserService.GetAsync(req.Id);

        if (User is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var UserResponse = User.ToUserResponse();
        await SendOkAsync(UserResponse, ct);
    }
}
