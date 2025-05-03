namespace Category.API.Categories.Queries.GetCategories
{
    class GetCategoriesQuery: IQuery<GetCategoriesResult>
    {
        public string Filter { get; private set; }
        public string OrderBy { get; private set; }
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }
        public GetCategoriesQuery(string filter, string orderBy, int? page, int? pageSize)
        {
            Filter = filter;
            OrderBy = orderBy;
            Page = page;
            PageSize = pageSize;
        }
    }
}
