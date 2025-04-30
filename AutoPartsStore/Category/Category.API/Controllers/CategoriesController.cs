using Category.API.Categories.Queries.GetAllCategories;
using Category.API.Models.GetAllCategories;
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
    }
}
