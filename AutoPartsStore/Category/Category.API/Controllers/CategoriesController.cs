using Category.API.Categories.Commands.CreateCategory;
using Category.API.Categories.Commands.UpdateCategory;
using Category.API.Categories.Queries.GetAllCategories;
using Category.API.Models.CreateCategory;
using Category.API.Models.GetAllCategories;
using Category.API.Models.UpdateCategory;
using Microsoft.AspNetCore.Mvc;

namespace Category.API.Controllers
{
    [Route("/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public CategoriesController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }
        [HttpGet]
        public async Task<IResult> Get([FromQuery]GetCategoriesRequest request)
        {
            var query = _mapper.Map<GetCategoriesQuery>(request);
            var result = await _sender.Send(query);
            var response = _mapper.Map<GetCategoriesResponse>(result);

            return Results.Ok(response);
        }
        [HttpGet("/getAllCategories")]
        public async Task<IResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _sender.Send(query);
            var response = _mapper.Map<GetAllCategoriesResponse>(result);

            return Results.Ok(response);
        }
        [HttpPost]
        public async Task<IResult> CreateCategory([FromBody]CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateCategoryCommand>(request);
            var result = await _sender.Send(command);
            var response = _mapper.Map<CreateCategoryResponse>(result);

            return Results.Ok(response);
        }
        [HttpPut]
        public async Task<IResult> UpdateCategory([FromBody]UpdateCategoryRequest request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);
            var result = await _sender.Send(command);
            var response = _mapper.Map<UpdateCategoryResponse>(result);

            return Results.Ok(response);
        }
    }
}
