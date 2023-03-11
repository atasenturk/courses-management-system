namespace LMS.Web.API.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}
