using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Repository
{
    public interface IBulkInsertResult<out TKey, out TModel> : ICrudResult<TKey, TModel> where TKey : IConvertible where TModel : class, IEntity<TKey>
    {

    }
}
