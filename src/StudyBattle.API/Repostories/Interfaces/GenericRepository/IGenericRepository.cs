namespace StudyBattle.API.Repostories.Interfaces.GenericRepository
{
    public interface IGenericRepository<TKey,TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TKey id, TEntity entity);
        Task<bool> DeleteAsync(TKey id);
    }
}
