using FastEndpoints;
using Registration.API.Application.Models.Responses;
using Registration.API.Presentation.Endpoints;

namespace Registration.API.Presentation.Summaries;

public class GetAllUsersSummary : Summary<ListUsersEndpoint>
{
    public GetAllUsersSummary()
    {
        Summary = "Returns all the Users in the system";
        Description = "Returns all the Users in the system";
        Response<ListUsersResponse>(200, "All Users in the system are returned");
    }
}
