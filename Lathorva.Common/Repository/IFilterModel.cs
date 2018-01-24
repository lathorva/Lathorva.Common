using System;
using System.Collections.Generic;
using System.Text;
using Lathorva.Common.Repository.Filtering;

namespace Lathorva.Common.Repository
{
    interface IFilterModel
    {
        string Search { get; set; }

        List<Sorter> Sorters { get; set; }
    }
}
