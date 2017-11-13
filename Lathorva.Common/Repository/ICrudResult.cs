using System;
using System.Collections.Generic;
using System.Net;

namespace Lathorva.Common.Repository
{
    public interface ICrudResult<out TKey, out TModel> 
        where TModel : class, IEntity<TKey> 
        where TKey : IConvertible
    {
        TModel Model { get; }

        bool Ok { get; }

        HttpStatusCode StatusCode { get; }

        IEnumerable<CrudError> Errors { get; }
    }
}
