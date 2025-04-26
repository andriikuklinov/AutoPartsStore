using Microsoft.EntityFrameworkCore;

namespace Category.API.Data
{
    public class CategoryContext : DbContext
    {
        public virtual DbSet<Category.API.Data.Entities.Category> Categories { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category.API.Data.Entities.Category>().HasData(
                new Category.API.Data.Entities.Category() { Name="Tires" },
                new Category.API.Data.Entities.Category() { Name="Oil" },
                new Category.API.Data.Entities.Category() { Name="Accumulators" }
            );
        }

    }
}
