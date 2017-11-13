using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lathorva.Common.Repository
{
    public class PagedResult<TKey, TModel> where TKey : IConvertible where TModel : IEntity<TKey>
    {
        public PagedResult(IEnumerable<TModel> data, int totalCount, ISearchModel searchModel)
        {
            Data = data;
            TotalCount = totalCount;
            Limit = searchModel.Limit;
            Offset = searchModel.Offset;
        }

        /// <summary>
        /// The listed results
        /// </summary>
        public IEnumerable<TModel> Data { get; set; }

        /// <summary>
        /// True if there is more data
        /// </summary>
        public bool HasMore => Limit + Offset < TotalCount;

        /// <summary>
        /// Total count of data
        /// </summary>
        [Range(0, long.MaxValue)]
        public int TotalCount { get; }

        public int Limit { get; }
        public int Offset { get; }
    }
}
