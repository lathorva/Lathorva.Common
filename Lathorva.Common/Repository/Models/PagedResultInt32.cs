using System.Collections.Generic;
using Lathorva.Common.Repository.Filtering;

namespace Lathorva.Common.Repository.Models
{
    public class PagedResult<TModel> : PagedResult<int, TModel> where TModel : IEntity
    {
        public PagedResult(IEnumerable<TModel> data, int totalCount, IFilterModel filterModel) : base(data, totalCount, filterModel)
        {
        }
    }
}
