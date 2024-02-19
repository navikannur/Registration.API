using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Registration.API.Application.Models.Responses;
using Registration.API.Application.Models.Requests;
using Registration.API.Application.Mapping;
using Registration.API.Application;

namespace Registration.API.Presentation.Endpoints;

[HttpPost("Users"), AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUserRequest, UserResponse>
{
    private readonly IUserService _UserService;

    public CreateUserEndpoint(IUserService UserService)
    {
        _UserService = UserService ?? throw new ArgumentNullException(nameof(UserService));
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var User = req.ToUser();

        await _UserService.CreateAsync(User);

        var UserResponse = User.ToUserResponse();
        await SendCreatedAtAsync<GetUserEndpoint>(
            new { Id = User.Id.Value }, UserResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
