using FastEndpoints;
using Registration.API.Application.Models.Responses;
using Registration.API.Presentation.Endpoints;

namespace Registration.API.Presentation.Summaries;

public class UpdateUserSummary : Summary<UpdateUserEndpoint>
{
    public UpdateUserSummary()
    {
        Summary = "Updates an existing User in the system";
        Description = "Updates an existing User in the system";
        Response<UserResponse>(201, "User was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
