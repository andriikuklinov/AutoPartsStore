using Category.API.Categories.Queries.GetAllCategories;
using Category.API.Models.GetAllCategories;

namespace Category.API.MappingProfiles
{
    public class CategoryMappingProfile: Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<GetCategoriesRequest, GetCategoriesQuery>();
            CreateMap<GetCategoriesResult, GetCategoriesResponse>();

            CreateMap<GetAllCategoriesRequest, GetAllCategoriesQuery>();
            CreateMap<GetAllCategoriesResult, GetAllCategoriesResponse>();
        }
    }
}
