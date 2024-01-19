namespace Application.Contracts.UoW
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();        
        Task SaveChangesAsync(CancellationToken token = default);        
    }
}
