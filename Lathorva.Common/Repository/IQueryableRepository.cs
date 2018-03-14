using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lathorva.Common.Repository.Filtering;
using Lathorva.Common.Repository.Models;

namespace Lathorva.Common.Repository
{
    public interface IQueryableRepository<TModel, in TFilterModel> : IRepository<TModel, TFilterModel> where TModel : class, IEntity where TFilterModel : IFilterModel
    {
        IQueryable<TModel> Queryable();
    }
}
