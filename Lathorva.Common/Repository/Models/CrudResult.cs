using System.Collections.Generic;
using System.Net;

namespace Lathorva.Common.Repository.Models
{
    public class CrudResult<TModel> : ICrudResult<int, TModel>  
        where TModel : class, IEntity
    {
        private CrudResult(TModel model, HttpStatusCode statusCode, IEnumerable<CrudError> errors)
        {
            Model = model;
            StatusCode = statusCode;
            Errors = errors;
        }

        public static CrudResult<TModel> CreateOk(TModel model)
        {
            return new CrudResult<TModel>(model, HttpStatusCode.OK, null);
        }

        public static CrudResult<TModel> CreateOk()
        {
            return new CrudResult<TModel>(default(TModel), HttpStatusCode.OK, null);
        }

        public static CrudResult<TModel> CreateCreated(TModel model)
        {
            return new CrudResult<TModel>(model, HttpStatusCode.Created, null);
        }

        public static CrudResult<TModel> CreateBadRequest(IEnumerable<CrudError> errors)
        {
            return new CrudResult<TModel>(default(TModel), HttpStatusCode.BadRequest, errors);
        }

        public static CrudResult<TModel> CreateConflict(IEnumerable<CrudError> errors)
        {
            return new CrudResult<TModel>(default(TModel), HttpStatusCode.Conflict, errors);
        }

        public TModel Model { get; }

        public bool Ok => (int) StatusCode >= 200 && (int) StatusCode <= 206;

        public HttpStatusCode StatusCode { get; }
        public IEnumerable<CrudError> Errors { get; }

        public static CrudResult<TModel> CreateNotFound()
        {
            return new CrudResult<TModel>(default(TModel), HttpStatusCode.NotFound, null);
        }

        public static CrudResult<TModel> CreateUnauthorized()
        {
            return new CrudResult<TModel>(default(TModel), HttpStatusCode.Unauthorized, null);
        }
    }
}
