using Encuba.Exam.Domain.Entities;
using Encuba.Exam.Domain.Seed;

namespace Encuba.Exam.Domain.Interfaces.Repositories;

public interface IUserPublicAccessTokenRepository : IRepository<UserPublicAccessToken>
{
    UserPublicAccessToken Add(UserPublicAccessToken userPublicAccessToken);
    void Delete(List<UserPublicAccessToken> userPublicAccessTokens);
    Task<UserPublicAccessToken> GetByUserIdAsync(Guid userId);
}