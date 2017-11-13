using System;
using System.Threading.Tasks;

namespace Lathorva.Common.Repository
{
    public interface IUpdateRepository<TKey, TModel, in TUpdateModel> : IDisposable
        where TKey : IConvertible 
        where TModel : class, IEntity<TKey>
    {
        /// <summary>
        /// Updates data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        Task<ICrudResult<TKey, TModel>> UpdateAsync(TKey id, TUpdateModel updateModel);


    }
}
