using System.Collections.Generic;

namespace Lathorva.Common.Repository.Filtering
{
    public interface IFilterModel : ILimitOffset
    {
        string Search { get; set; }
        List<Sorter> Sorters { get; set; }
    }
}
