namespace Encuba.Exam.Domain.Seed;

public interface IRepository<T>
    where T : class
{
    IUnitOfWork UnitOfWork { get; }
}