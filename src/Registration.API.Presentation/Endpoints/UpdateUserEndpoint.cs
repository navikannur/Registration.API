using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Registration.API.Application.Models.Responses;
using Registration.API.Application.Models.Requests;
using Registration.API.Application.Mapping;
using Registration.API.Application;

namespace Registration.API.Presentation.Endpoints;

[HttpPut("Users/{id:guid}"), AllowAnonymous]
public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
{
    private readonly IUserService _UserService;

    public UpdateUserEndpoint(IUserService UserService)
    {
        _UserService = UserService;
    }

    public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {
        var existingUser = await _UserService.GetAsync(req.Id);

        if (existingUser is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var User = req.ToUser();
        await _UserService.UpdateAsync(User);

        var UserResponse = User.ToUserResponse();
        await SendOkAsync(UserResponse, ct);
    }
}
