
using Encuba.Exam.Domain.Dtos;
using MediatR;

namespace  Encuba.Exam.Application.Commands.AuthJwtCommands;

public record CreateJwtCommand(
    string AccessToken,
    string JwtSecret) : IRequest<EntityResponse<JwtResponse>>;