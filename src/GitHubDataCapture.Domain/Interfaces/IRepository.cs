namespace GitHubDataCapture.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        Task AddRangerAsync(IEnumerable<TEntity> entity);
    }
}
