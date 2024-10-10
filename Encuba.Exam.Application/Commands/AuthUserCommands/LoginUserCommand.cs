
using Encuba.Exam.Application.Dtos.Responses;
using MediatR;

namespace  Encuba.Exam.Application.Commands.AuthUserCommands;

public record LoginUserCommand(
    string Username,
    string Password,
    string UserAgent,
    string ClientIp) : IRequest<EntityResponse<PublicAccessTokenResponse>>;