using  Encuba.Exam.Application.Commands.AuthUserCommands;

namespace  Encuba.Exam.Api.Dtos.AuthUserRequests;

public record RefreshTokenRequest(string RefreshToken)
{
    public RefreshTokenCommand ToApplicationRequest()
    {
        return new RefreshTokenCommand(RefreshToken);
    }
}