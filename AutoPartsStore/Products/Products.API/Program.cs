using Microsoft.EntityFrameworkCore;
using Products.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region DbContext
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDatabase"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Products.API");
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
