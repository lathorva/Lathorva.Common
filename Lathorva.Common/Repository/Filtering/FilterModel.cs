using System.Collections.Generic;

namespace Lathorva.Common.Repository.Filtering
{
    public class FilterModel : IFilterModel
    {
        public string Search { get; set; }

        public List<Sorter> Sorters { get; set; }

        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
