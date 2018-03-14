using System;
using System.Threading.Tasks;
using Lathorva.Common.Repository.Models;

namespace Lathorva.Common.Repository
{
    public interface IDeleteRepository<TKey, TModel> : IDisposable
        where TKey : IConvertible
        where TModel : class, IEntity<TKey> 
    {
        /// <summary>
        /// Deletes data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ICrudResult<TKey, TModel>> DeleteAsync(TKey id);
    }
}
