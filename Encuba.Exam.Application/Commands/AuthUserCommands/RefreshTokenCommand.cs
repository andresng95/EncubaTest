
using Encuba.Exam.Application.Dtos.Responses;
using MediatR;

namespace  Encuba.Exam.Application.Commands.AuthUserCommands;

public record RefreshTokenCommand(
    string RefreshToken) : IRequest<EntityResponse<PublicAccessTokenResponse>>;