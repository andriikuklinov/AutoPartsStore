namespace Category.API.Data
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category.API.Data.Entities.Category> Categories { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category.API.Data.Entities.Category>()
                .ToTable(category => category.HasCheckConstraint("CK_Category_Name_Length", "LEN([Name])>=3 AND LEN([Name])<30"));

            modelBuilder.Entity<Category.API.Data.Entities.Category>().HasData(
                new Category.API.Data.Entities.Category() { Id=1, Name="Tires" },
                new Category.API.Data.Entities.Category() { Id=2, Name="Oil" },
                new Category.API.Data.Entities.Category() { Id=3, Name="Accumulators" }
            );
        }

    }
}
