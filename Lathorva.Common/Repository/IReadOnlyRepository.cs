using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lathorva.Common.Repository.Filtering;
using Lathorva.Common.Repository.Models;

namespace Lathorva.Common.Repository
{
    public interface IReadOnlyRepository<TKey, TModel, in TFilterModel> : IDisposable
        where TKey : IConvertible 
        where TModel : IEntity<TKey>
        where TFilterModel : IFilterModel
    {
        /// <summary>
        /// Gets the entity or NULL if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetByIdOrDefaultAsync(TKey id);

        /// <summary>
        /// Gets all data paged
        /// </summary>
        /// <param name="filterModel">Required params</param>
        /// <returns></returns>
        Task<PagedResult<TKey, TModel>> GetAllAsync(TFilterModel filterModel);

        /// <summary>
        /// Gets the current context count
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync(TFilterModel filterModel);

        /// <summary>
        /// Checks if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(TKey id);

        /// <summary>
        /// If set true, limit offset is never used for GetAll
        /// </summary>
        bool AlwaysDisablePaging { get; }
    }
}
