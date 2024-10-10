using  Encuba.Exam.Application.Commands.AuthJwtCommands;

namespace  Encuba.Exam.Api.Dtos.AuthJwtRequests;

public record CreateJwtRequest(string AccessToken)
{
    public CreateJwtCommand ToApplicationRequest(string secret)
    {
        return new CreateJwtCommand(AccessToken, secret);
    }
}