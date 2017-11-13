namespace Lathorva.Common.Repository
{
    public class SearchModel : ISearchModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
