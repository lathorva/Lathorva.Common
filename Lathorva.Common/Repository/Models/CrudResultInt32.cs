using System.Collections.Generic;
using System.Net;

namespace Lathorva.Common.Repository.Models
{
    public class CrudResultInt32<TModel> : ICrudResult<int, TModel>  
        where TModel : class, IEntity
    {
        private CrudResultInt32(TModel model, HttpStatusCode statusCode, IEnumerable<CrudError> errors)
        {
            Model = model;
            StatusCode = statusCode;
            Errors = errors;
        }

        public static CrudResultInt32<TModel> CreateOk(TModel model)
        {
            return new CrudResultInt32<TModel>(model, HttpStatusCode.OK, null);
        }

        public static CrudResultInt32<TModel> CreateOk()
        {
            return new CrudResultInt32<TModel>(default(TModel), HttpStatusCode.OK, null);
        }

        public static CrudResultInt32<TModel> CreateCreated(TModel model)
        {
            return new CrudResultInt32<TModel>(model, HttpStatusCode.Created, null);
        }

        public static CrudResultInt32<TModel> CreateBadRequest(IEnumerable<CrudError> errors)
        {
            return new CrudResultInt32<TModel>(default(TModel), HttpStatusCode.BadRequest, errors);
        }

        public static CrudResultInt32<TModel> CreateConflict(IEnumerable<CrudError> errors)
        {
            return new CrudResultInt32<TModel>(default(TModel), HttpStatusCode.Conflict, errors);
        }

        public TModel Model { get; }

        public bool Ok => (int) StatusCode >= 200 && (int) StatusCode <= 206;

        public HttpStatusCode StatusCode { get; }
        public IEnumerable<CrudError> Errors { get; }

        public static CrudResultInt32<TModel> CreateNotFound()
        {
            return new CrudResultInt32<TModel>(default(TModel), HttpStatusCode.NotFound, null);
        }

        public static CrudResultInt32<TModel> CreateUnauthorized()
        {
            return new CrudResultInt32<TModel>(default(TModel), HttpStatusCode.Unauthorized, null);
        }
    }
}
