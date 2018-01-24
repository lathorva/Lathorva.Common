namespace Lathorva.Common.Repository
{
    public interface ISearchModel// where TModel : IEntity<TKey>
//where TOrder : IOrderedQueryable<TModel>
    {
        //[Range(0, int.MaxValue)]
        int Offset { get; set; }
        //[Range(1, 1000, ErrorMessage = "Limit has to be between 1 and 1000")]
        int Limit { get; set; }

        //TOrder Order { get; set; }
    }
}
