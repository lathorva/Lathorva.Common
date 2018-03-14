using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Repository.Filtering
{
    public interface ILimitOffset
    {
        int Offset { get; set; }

        int Limit { get; set; }
    }
}
