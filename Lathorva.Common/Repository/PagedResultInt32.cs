using System.Collections.Generic;

namespace Lathorva.Common.Repository
{
    public class PagedResult<TModel> : PagedResult<int, TModel> where TModel : IEntity
    {
        public PagedResult(IEnumerable<TModel> data, int totalCount, ISearchModel searchModel) : base(data, totalCount, searchModel)
        {
        }
    }
}
