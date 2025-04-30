using Category.API.Data;
using Category.API.Data.Repositories;
using Category.API.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Route options
builder.Services.Configure<RouteOptions>(config =>
{
    config.LowercaseUrls = true;
    config.LowercaseQueryStrings = true;
});
#endregion
#region Dependencies
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion
#region Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new CategoryMappingProfile());
});
#endregion
#region DbContext
builder.Services.AddDbContext<CategoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CategoryDatabase"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Category.API");
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
