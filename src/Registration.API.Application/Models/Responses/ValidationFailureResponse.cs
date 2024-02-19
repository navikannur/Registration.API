namespace Registration.API.Application.Models.Responses;

public class ValidationFailureResponse
{
    public List<string> Errors { get; init; } = new();
}
