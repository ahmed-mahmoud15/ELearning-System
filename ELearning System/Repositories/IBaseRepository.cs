namespace ELearning_System.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T record);
        void Update(T record);
        Task DeleteAsync(object id);
        Task SaveAsync();
    }
}
