using System;
using Lathorva.Common.Repository.Filtering;
using Lathorva.Common.Repository.Models;

namespace Lathorva.Common.Repository
{
    /// <summary>
    /// Repository implementation for all CRUD interactions
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TCreateModel"></typeparam>
    /// <typeparam name="TUpdateModel"></typeparam>
    /// <typeparam name="TSearchModel"></typeparam>
    public interface IRepository<TKey, TModel, in TCreateModel, in TUpdateModel, in TSearchModel> :
        IReadOnlyRepository<TKey, TModel, TSearchModel>,
        IAddRepository<TKey, TModel, TCreateModel>,
        IUpdateRepository<TKey, TModel, TUpdateModel>,
        IDeleteRepository<TKey, TModel>,
        IDisposable
        where TKey : IConvertible 
        where TModel : class, IEntity<TKey>
        where TSearchModel : Filtering.IFilterModel
    { }

    /// <summary>
    /// Repository implementation with no create/update models
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TSearchModel"></typeparam>
    public interface IRepository<TKey, TModel, in TSearchModel> : IRepository<TKey, TModel, TModel, TModel, TSearchModel>,
        IDisposable
        where TKey : IConvertible
        where TModel : class, IEntity<TKey>
        where TSearchModel : Filtering.IFilterModel
    { }
}
