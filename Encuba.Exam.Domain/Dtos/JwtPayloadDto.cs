namespace Encuba.Exam.Domain.Dtos;

public record JwtPayloadDto(
    Guid Id,
    string FullName,
    string Scope
);