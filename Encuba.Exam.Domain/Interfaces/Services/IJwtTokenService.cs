using Encuba.Exam.Domain.Dtos;

namespace Encuba.Exam.Domain.Interfaces.Services;

public interface IJwtTokenService
{
    public string GenerateJwtToken(JwtPayloadDto payload);
}