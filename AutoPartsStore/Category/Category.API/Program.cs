using Category.API.Data;
using Category.API.Data.Repositories;
using Category.API.MappingProfiles;
using Common.Exceptions.Handlers;
using Common.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Reflection;

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
#region MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
#endregion
#region Exception handling
builder.Services.AddExceptionHandler<CustomExceptionsHandler>();
#endregion
#region Healthcheck
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("CategoryDatabase"));
#endregion
var app = builder.Build();
app.UseMigration<CategoryContext>();
app.MapControllers();

app.Run();
