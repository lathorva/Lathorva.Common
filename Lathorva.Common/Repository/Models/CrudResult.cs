using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Lathorva.Common.Repository.Models
{
    public class CrudResult<TKey, TModel> : ICrudResult<TKey, TModel>
        where TKey : IConvertible
        where TModel : class, IEntity<TKey>
    {
        private CrudResult(TModel model, HttpStatusCode statusCode, IEnumerable<CrudError> errors)
        {
            Model = model;
            StatusCode = statusCode;
            Errors = errors;
        }

        public TModel Model { get; }
        public HttpStatusCode StatusCode { get; }
        public IEnumerable<CrudError> Errors { get; }

        public bool Ok => (int)StatusCode >= 200 && (int)StatusCode <= 206;

        public static ICrudResult<TKey, TModel> CreateOk(TModel model)
        {
            return new CrudResult<TKey, TModel>(model, HttpStatusCode.OK, null);
        }

        public static CrudResult<TKey, TModel> CreateOk()
        {
            return new CrudResult<TKey, TModel>(default(TModel), HttpStatusCode.OK, null);
        }

        public static CrudResult<TKey, TModel> CreateCreated(TModel model)
        {
            return new CrudResult<TKey, TModel>(model, HttpStatusCode.Created, null);
        }

        public static CrudResult<TKey, TModel> CreateBadRequest(IEnumerable<CrudError> errors)
        {
            return new CrudResult<TKey, TModel>(default(TModel), HttpStatusCode.BadRequest, errors);
        }

        public static CrudResult<TKey, TModel> CreateConflict(IEnumerable<CrudError> errors)
        {
            return new CrudResult<TKey, TModel>(default(TModel), HttpStatusCode.Conflict, errors);
        }
    }
}
