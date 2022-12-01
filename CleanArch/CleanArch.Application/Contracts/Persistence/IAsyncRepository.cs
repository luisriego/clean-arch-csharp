using CleanArch.Domain.Common;
using System.Linq.Expressions;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync(); /*T representa o tipo de dato retornado*/

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disableTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
