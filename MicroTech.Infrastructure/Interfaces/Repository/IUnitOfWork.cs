namespace MicroTech.Infrastructure.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
