using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lathorva.Common.Repository
{
    public interface IReadOnlyRepository<TKey, TModel, in TSearchModel> : IDisposable
        where TKey : IConvertible 
        where TModel : class, IEntity<TKey>
        where TSearchModel : ISearchModel
    {
        /// <summary>
        /// Gets the entity or nothing if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetByIdOrDefaultAsync(TKey id);

        /// <summary>
        /// Gets all data paged
        /// </summary>
        /// <param name="searchModel">Required params</param>
        /// <param name="expression">Optional expression</param>
        /// <returns></returns>
        Task<PagedResult<TKey, TModel>> GetAllAsync(TSearchModel searchModel, Expression<Func<TModel, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TModel, bool>> expression);

        Task<bool> ExistsAsync(TKey id);
    }
}
