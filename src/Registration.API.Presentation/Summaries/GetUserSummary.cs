using FastEndpoints;
using Registration.API.Presentation.Endpoints;
using Registration.API.Application.Models.Responses;

namespace Registration.API.Presentation.Summaries;

public class GetUserSummary : Summary<GetUserEndpoint>
{
    public GetUserSummary()
    {
        Summary = "Returns a single User by id";
        Description = "Returns a single User by id";
        Response<ListUsersResponse>(200, "Successfully found and returned the User");
        Response(404, "The User does not exist in the system");
    }
}
