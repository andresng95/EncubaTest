

using Encuba.Exam.Application.Dtos.Responses;
using MediatR;

namespace  Encuba.Exam.Application.Commands.UserCommands;

public record CreateUserCommand(
    string UserName,
    string UserType,
    string FirstName,
    string SecondName,
    string FirstLastName,
    string SecondLastName,
    string Password,
    string Email,
    bool AcceptedTermsAndCondition
) : IRequest<EntityResponse<ObjectIdResponse>>;