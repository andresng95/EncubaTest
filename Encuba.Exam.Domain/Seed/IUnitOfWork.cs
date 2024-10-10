namespace Encuba.Exam.Domain.Seed;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveEntityAsync(CancellationToken cancellationToken = default);
}