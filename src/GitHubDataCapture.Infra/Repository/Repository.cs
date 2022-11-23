using GitHubDataCapture.Domain.Interfaces;

namespace GitHubDataCapture.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly GitHubContext _gitHubContext;

        public Repository(GitHubContext gitHubContext)
        {
            _gitHubContext = gitHubContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _gitHubContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task AddRangerAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _gitHubContext.AddRangeAsync(entities);
                await _gitHubContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"List could not be saved: {ex.Message}");
            }
        }
    }
}
