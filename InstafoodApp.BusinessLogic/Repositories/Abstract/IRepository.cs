using System.Linq.Expressions;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        //T GetAsync(Expression<Func<T, bool>> filter);
        //IEnumerable<T> GetAllAsync();
        //IEnumerable<T> GetAllAsync(Expression<Func<T, bool>> filter);
        //void AddAsync(T entity);
        //void RemoveAsync(T entity);
        //void RemoveRangeAsync(IEnumerable<T> entities);
    }
}
