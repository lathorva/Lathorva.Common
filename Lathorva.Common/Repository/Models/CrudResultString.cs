using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Lathorva.Common.Repository.Models
{
    public class CrudResultString<TModel> : ICrudResult<string, TModel>
        where TModel : class, IEntity<string>
    {
        private CrudResultString(TModel model, HttpStatusCode statusCode, IEnumerable<CrudError> errors)
        {
            Model = model;
            StatusCode = statusCode;
            Errors = errors;
        }

        public TModel Model { get; }
        public HttpStatusCode StatusCode { get; }
        public IEnumerable<CrudError> Errors { get; }

        public bool Ok => (int)StatusCode >= 200 && (int)StatusCode <= 206;

        public static ICrudResult<string, TModel> CreateOk(TModel model)
        {
            return new CrudResultString<TModel>(model, HttpStatusCode.OK, null);
        }

        public static ICrudResult<string, TModel> CreateOk()
        {
            return new CrudResultString<TModel>(default(TModel), HttpStatusCode.OK, null);
        }

        public static ICrudResult<string, TModel> CreateCreated(TModel model)
        {
            return new CrudResultString<TModel>(model, HttpStatusCode.Created, null);
        }

        public static ICrudResult<string, TModel> CreateBadRequest(IEnumerable<CrudError> errors)
        {
            return new CrudResultString<TModel>(default(TModel), HttpStatusCode.BadRequest, errors);
        }

        public static ICrudResult<string, TModel> CreateConflict(IEnumerable<CrudError> errors)
        {
            return new CrudResultString<TModel>(default(TModel), HttpStatusCode.Conflict, errors);
        }
    }
}
