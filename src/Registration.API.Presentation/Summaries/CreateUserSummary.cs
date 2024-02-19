using FastEndpoints;
using Registration.API.Presentation.Endpoints;
using Registration.API.Application.Models.Responses;

namespace Registration.API.Presentation.Summaries;

public class CreateUserSummary : Summary<CreateUserEndpoint>
{
    public CreateUserSummary()
    {
        Summary = "Creates a new User in the system";
        Description = "Creates a new User in the system";
        Response<UserResponse>(201, "User was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
