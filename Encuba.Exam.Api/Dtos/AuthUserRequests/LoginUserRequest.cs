using  Encuba.Exam.Application.Commands.AuthUserCommands;

namespace  Encuba.Exam.Api.Dtos.AuthUserRequests;

public record LoginUserRequest(
    string Username,
    string Password)
{
    public LoginUserCommand ToApplicationRequest(string userAgent, string clientIp)
    {
        return new LoginUserCommand(Username, Password, userAgent, clientIp);
    }
}