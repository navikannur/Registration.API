using FastEndpoints;
using Registration.API.Presentation.Endpoints;

namespace Registration.API.Presentation.Summaries;

public class DeleteUserSummary : Summary<DeleteUserEndpoint>
{
    public DeleteUserSummary()
    {
        Summary = "Deleted a User the system";
        Description = "Deleted a User the system";
        Response(204, "The User was deleted successfully");
        Response(404, "The User was not found in the system");
    }
}
