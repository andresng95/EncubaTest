
using Encuba.Exam.Domain.Entities;
using Encuba.Exam.Domain.Seed;

namespace Encuba.Exam.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    User Update(User user);
    Task<User> GetByUserAsync(string username);
}