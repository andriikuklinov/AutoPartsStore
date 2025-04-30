namespace Category.API.MappingProfiles
{
    public class CategoryMappingProfile: Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<GetCategoriesRequest, GetCategoriesQuery>();
            CreateMap<GetCategoriesResult, GetCategoriesResponse>();
        }
    }
}
