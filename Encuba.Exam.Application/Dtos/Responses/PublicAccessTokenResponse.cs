using MediatR;

namespace  Encuba.Exam.Application.Dtos.Responses;

public record PublicAccessTokenResponse(
    string AccessToken,
    string RefreshToken,
    string Scope,
    DateTime ExpiresIn): IRequest<EntityResponse<PublicAccessTokenResponse>>;