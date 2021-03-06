﻿namespace Lathorva.Common.Repository.Models
{
    /// <summary>
    /// Item can be ordered, value that selects order low to high (asc)
    /// </summary>
    public interface IOrdered
    {
        int OrderSortValue { get; set; }
    }
}
