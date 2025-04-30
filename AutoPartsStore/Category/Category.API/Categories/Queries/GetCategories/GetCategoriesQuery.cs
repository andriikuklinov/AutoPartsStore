namespace Category.API.Categories.Queries.GetCategories
{
    class GetCategoriesQuery: IQuery<GetCategoriesResult>
    {
        public string Filter { get; private set; }
        public string OrderBy { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public GetCategoriesQuery(string filter, string orderBy, int page=0, int pageSize=10)
        {
            Filter = filter;
            OrderBy = orderBy;
            Page = page;
            PageSize = pageSize;
        }
    }
}
