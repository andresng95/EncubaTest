
using Encuba.Exam.Domain.Entities;
using Encuba.Exam.Domain.Seed;

namespace Encuba.Exam.Domain.Interfaces.Repositories;

public interface IPublicAccessTokenRepository : IRepository<PublicAccessToken>
{
    PublicAccessToken Add(PublicAccessToken publicAccessToken);
    PublicAccessToken Update(PublicAccessToken publicAccessToken);
    Task <PublicAccessToken>  GetByToken(string token);
    Task<PublicAccessToken> GetByRefreshToken(string refreshToken, string client);
}