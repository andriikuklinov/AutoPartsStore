using Category.API.Categories.Commands.CreateCategory;
using Category.API.Categories.Commands.DeleteCategory;
using Category.API.Categories.Commands.UpdateCategory;
using Category.API.Categories.Queries.GetAllCategories;
using Category.API.Models.CreateCategory;
using Category.API.Models.DeleteCategory;
using Category.API.Models.GetAllCategories;
using Category.API.Models.UpdateCategory;

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

            CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
            CreateMap<CreateCategoryResult, CreateCategoryResponse>();

            CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
            CreateMap<UpdateCategoryResult, UpdateCategoryResponse>();


            CreateMap<DeleteCategoryRequest, DeleteCategoryCommand>();
            CreateMap<DeleteCategoryResult, DeleteCategoryResponse>();
        }
    }
}
