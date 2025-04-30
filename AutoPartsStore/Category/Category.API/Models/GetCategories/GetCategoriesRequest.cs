namespace Category.API.Models.GetCategories
{
    public class GetCategoriesRequest
    {
        public string Filter { get; set; } = default!;
        public string OrderBy { get; set; } = default!;
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
