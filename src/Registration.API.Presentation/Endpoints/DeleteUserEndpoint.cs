using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Registration.API.Application;
using Registration.API.Application.Models.Requests;

namespace Registration.API.Presentation.Endpoints;

[HttpDelete("Users/{id:guid}"), AllowAnonymous]
public class DeleteUserEndpoint : Endpoint<DeleteUserRequest>
{
    private readonly IUserService _UserService;

    public DeleteUserEndpoint(IUserService UserService)
    {
        _UserService = UserService;
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var deleted = await _UserService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
