﻿using System;
using Lathorva.Common.Repository.Filtering;
using Lathorva.Common.Repository.Models;

namespace Lathorva.Common.Repository
{
    /// <summary>
    /// For Int32 Identity
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TCreateModel"></typeparam>
    /// <typeparam name="TUpdateModel"></typeparam>
    /// <typeparam name="TSearchModel"></typeparam>
    public interface IRepository<TModel, in TCreateModel, in TUpdateModel, in TSearchModel> : IRepository<int, TModel, TCreateModel, TUpdateModel, TSearchModel>,
        IDisposable
        where TModel : class, IEntity
        where TSearchModel : Filtering.IFilterModel
    {
    }

    public interface IRepository<TModel, in TSearchModel> : IRepository<TModel, TModel, TModel, TSearchModel>,
        IDisposable
        where TModel : class, IEntity
        where TSearchModel : Filtering.IFilterModel
    { }
}
