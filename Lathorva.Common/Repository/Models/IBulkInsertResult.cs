using System;

namespace Lathorva.Common.Repository.Models
{
    public interface IBulkInsertResult<out TKey, out TModel> : ICrudResult<TKey, TModel> where TKey : IConvertible where TModel : class, IEntity<TKey>
    {

    }
}
