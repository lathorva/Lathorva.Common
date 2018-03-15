using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lathorva.Common.Repository.Filtering;

namespace Lathorva.Common.Repository.Models
{
    public class PagedResult<TKey, TModel> where TKey : IConvertible where TModel : IEntity<TKey>
    {
        public PagedResult(IEnumerable<TModel> data, int totalCount, IFilterModel filterModel)
        {
            Data = data;
            TotalCount = totalCount;

            if(filterModel == null) throw new Exception("FilterModel is NULL, it is required");
            Limit = filterModel.Limit;
            Offset = filterModel.Offset;
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

        // TODO, Page, PageSize, TotalPages
    }
}
