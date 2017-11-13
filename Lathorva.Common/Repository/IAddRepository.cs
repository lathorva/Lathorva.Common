using System;
using System.Threading.Tasks;

namespace Lathorva.Common.Repository
{
    public interface IAddRepository<TKey, TModel, in TCreateModel> : IDisposable
        where TKey : IConvertible 
        where TModel : class ,IEntity<TKey>
    {
        /// <summary>
        /// Adds new data, returns potensial new model with status
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        Task<ICrudResult<TKey, TModel>> CreateAsync(TCreateModel createModel);
    }
}
